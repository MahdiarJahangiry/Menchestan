using UnityEngine;
using UnityEngine.UI;
using Menchestan.Menu;
using Menchestan.Server;
using Menchestan.Localization;
using Menchestan.Server.Model;
using System.Collections.Generic;

namespace Menchestan
{
    namespace IAB
    {
        namespace IABItems
        {
            public class DiceItem : GoodItem
            {
                public Image back;
                public Image boarder;
                public Image icon;
                public Image btnImage;
                public Localize title;
                public Localize price;
                public List<Material> backMat;
                public List<Sprite> butonBackground;
                public List<Sprite> borderImages;
                static DiceItem selected;
                private void ChangeDice()
                {
                    ServerKit.Instance.UpdateData(GameManager.Instance.user, new Dictionary<string, object>() { { "selectedDice", good.key } }, OnSelectionChanged);
                }

                private void OnSelectionChanged(bool status, UserSetModel response, string message, int code)
                {
                    if (status)
                    {
                        selected?.SetData();
                        SetData();
                    }
                    else
                    {
                        DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "Error", message);
                    }
                }

                private void PurchaseByMarket()
                {
                    GameManager.Instance.iabManager.PurchaseByMarket(good, OnBurchaseByServer, PurchaseByMarket);
                }
                private void PurchaseByServer()
                {
                    if (good.value <= GameManager.Instance.user.coin)
                    {
                        GameManager.Instance.iabManager.PurchaseByServer(good, null, OnBurchaseByServer, PurchaseByServer);
                    }
                    else
                    {
                        DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.OkCancel, "NotEnoughCoin", "MsgNotEnoughCoin", () =>
                        {
                            DialogBoxMenu.Hide();
                            StoreMenu.Instance.ShowTab(0);
                        });
                    }
                }
                private void OnBurchaseByServer(bool status, UserSetModel response, string message, int code)
                {
                    if (status)
                    {
                        SetData();
                        DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "Success", message);
                    }
                    else
                    {
                        DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "Error", message);
                    }
                }
                public override void SetData()
                {
                    title.SetKey(good.key);
                    button.onClick.RemoveAllListeners();
                    if (GameManager.Instance.iabManager.icons.ContainsKey(good.icon))
                    {
                        icon.sprite = GameManager.Instance.iabManager.icons[good.icon];
                    }
                    if (GameManager.Instance.user.dices.Contains(good.key))
                    {
                        if (good.key == GameManager.Instance.user.selectedDice)
                        {
                            button.interactable = false;
                            back.material = backMat[1];
                            btnImage.sprite = butonBackground[1];
                            btnImage.rectTransform.sizeDelta = new Vector2(224, 76);
                            boarder.sprite = borderImages[1];
                            price.SetKey("Chosen");
                            selected = this;
                        }
                        else
                        {
                            button.interactable = true;
                            back.material = backMat[0];
                            btnImage.sprite = butonBackground[0];
                            boarder.sprite = borderImages[0];
                            btnImage.rectTransform.sizeDelta = new Vector2(193, 88);
                            price.SetKey("Choose");
                            button.onClick.AddListener(() => ChangeDice());
                        }
                    }
                    else
                    {
                        button.interactable = true;
                        back.material = backMat[2];
                        btnImage.sprite = butonBackground[2];
                        boarder.sprite = borderImages[2];
                        btnImage.rectTransform.sizeDelta = new Vector2(193, 88);
                        price.formatValues  = new List<string>
                        {
                            good.price.ToString()
                        };
                        if (good.ismarket)
                        {
                            button.onClick.AddListener(() => PurchaseByMarket());
                        }
                        else
                        {
                            button.onClick.AddListener(() => PurchaseByServer());
                        }
                    }
                }
            }
        }
    }
}
