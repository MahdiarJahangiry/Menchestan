using System;
using System.Linq;
using UnityEngine;
using Menchestan.IO;
using Menchestan.Menu;
using Menchestan.Server;
using Sirenix.OdinInspector;
using Menchestan.Server.Model;
using System.Collections.Generic;

namespace Menchestan
{
    namespace IAB
    {
        public class IABManager //: SerializedMonoBehaviour
        {
            //private static IABManager instance;
            //public static IABManager Instance
            //{
            //    get
            //    {
            //        if (instance == null)
            //        {
            //            instance = FindObjectOfType<IABManager>();
            //            if (instance == null)
            //            {
            //                instance = new GameObject("IABManager", typeof(IABManager)).AddComponent<IABManager>();
            //            }
            //            instance.isInit = false;
            //            instance.Initialize(0);
            //        }
            //        return instance;
            //    }
            //}
            public GoodCollection goods;
            public Dictionary<string, Sprite> icons = new Dictionary<string, Sprite>();
            private int sVersion;
            public bool isInit;
            private bool isMarketInit;
            private Action OnInit;
            private GenericCallback<UserSetModel> purchaseCallback;
            private bool initFromBuy;
            private bool upToDate => goods.version >= sVersion;
            private static readonly string fileName = "good.txt";
            public void Initialize(int sVersion, Action onInit)
            {
                StoreHandler.instance.products.Clear();
                if (sVersion != -1)
                {
                    this.sVersion = sVersion;
                }
                else
                {
                    initFromBuy = true;
                    OnInit = onInit;
                }
                if (!isInit)
                {
                    goods = new GoodCollection();
                    if (DataIO.IsExist(fileName))
                    {
                        goods = DataIO.FromJson<GoodCollection>(fileName);
                    }
                    else
                    {
                        var dataStr = Resources.Load<TextAsset>("Offline/good") as TextAsset;
                        goods = JsonUtility.FromJson<GoodCollection>(dataStr.text);
                    }

                    if (upToDate)
                    {
                        IEnumerable<string> filtred = goods.items.Select(o => o.icon).Where(y => !icons.ContainsKey(y)).Distinct();
                        foreach (var item in filtred)
                        {
                            DataIO.CacheUrl<Sprite>("/good/" + item + ".png", (s, r) => { if (s) icons.Add(item, r); });
                        }
                        foreach (var item in goods.items)
                        {
                            StoreHandler.instance.products.Add(new Product() { price = item.price.ToString(), productId = item.key, type = item.ptype ? Product.ProductType.Consumable : Product.ProductType.NonConsumable });
                        }
                        isInit = true;
                    }
                    else
                    {
                        UpdateGood();
                    }
                }
                if (isInit)
                {
                    if (!isMarketInit)
                    {
                        StoreHandler.instance.InitializeBillingService((code, message) =>
                        {
                            isMarketInit = false;
                            if (initFromBuy)
                            {
                                DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.TryCancel, "Error", "ERROR_SERVICE_NOT_INITIALIZED", new List<Action>()
                                    {
                                        ()=>{
                                            DialogBoxMenu.Hide();
                                            Initialize(-1,onInit);
                                        },
                                        ()=>{
                                            DialogBoxMenu.Hide();
                                            initFromBuy = false;
                                        }
                                     });
                            }
                        }, () =>
                        {
                            isMarketInit = true;
                            if (initFromBuy)
                            {
                                initFromBuy = false;
                                onInit?.Invoke();
                            }
                        });
                    }
                }
            }
            private void UpdateGood()
            {
                ServerKit.Instance.GetGoods(goods.version, (status, response, message, code) =>
                {
                    if (status)
                    {
                        goods.version = sVersion;
                        foreach (var item in response.items)
                        {
                            int index = goods.items.FindIndex(i => i.key == item.key);
                            if (index == -1)
                            {
                                goods.items.Add(item);
                            }
                            else
                            {
                                goods.items[index] = item;
                            }
                        }
                        DataIO.ToJson(fileName, goods);
                        Initialize(sVersion, null);
                    }
                    else
                    {
                        if (initFromBuy)
                        {
                            DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.TryCancel, "Error", "ERROR_SERVICE_NOT_INITIALIZED", () =>
                            {
                                DialogBoxMenu.Hide();
                                Initialize(-1, OnInit);
                            });
                        }
                    }
                });
            }

            public void PurchaseByMarket(GoodModel good, GenericCallback<UserSetModel> callback, Action onInit)
            {
                if (!GameManager.Instance.iabManager.isInit)
                {
                    DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.OkCancel, "Error", "GameDataError", () =>
                    {
                        DialogBoxMenu.Hide();
                        Initialize(-1, onInit);
                    });
                }
                if (!GameManager.Instance.iabManager.isMarketInit)
                {
                    DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.OkCancel, "Error", "ERROR_SERVICE_NOT_INITIALIZED", () =>
                    {
                        DialogBoxMenu.Hide();
                        Initialize(-1, onInit);
                    });
                }
                else
                {
                    int productIndex = StoreHandler.instance.products.FindIndex(p => p.productId == good.key);
                    if (productIndex != -1)
                    {
                        StoreHandler.instance.Purchase(productIndex, OnMarketError, OnMarketSuccess);
                    }
                    else
                    {
                        DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "Error", "ERROR_WRONG_PRODUCT_INDEX");
                    }
                }
            }
            public void PurchaseByServer(GoodModel good, Purchase purchase, GenericCallback<UserSetModel> callback, Action onInit)
            {
                if (!isInit)
                {
                    DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.OkCancel, "Error", "ERROR_SERVICE_NOT_INITIALIZED", () =>
                    {
                        DialogBoxMenu.Hide();
                        Initialize(-1, onInit);
                    });
                }
                else
                {
                    ServerKit.Instance.Purchase(GameManager.Instance.user, good, purchase, callback);
                }
            }

            private void OnMarketSuccess(Purchase purchase, int productIndex)
            {
                GoodModel good = goods.items.FindLast(g => g.key == StoreHandler.instance.products[productIndex].productId);
                if (good != null)
                {
                    PurchaseByServer(good, purchase, purchaseCallback, null);
                }
                else
                {
                    purchaseCallback(false, null, "ERROR_WRONG_PRODUCT_INDEX", 400);
                    DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "Error", "ERROR_WRONG_PRODUCT_INDEX");
                }
            }

            private void OnMarketError(int errorCode, string message)
            {
                ErrorType errorType = (ErrorType)errorCode;
                purchaseCallback(false, null, errorType.ToString(), 400);
                DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "Error", errorType.ToString());
            }
        }
    }
}