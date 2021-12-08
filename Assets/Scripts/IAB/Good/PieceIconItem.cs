﻿using UnityEngine;
using UnityEngine.UI;
using Menchestan.Menu;
using Menchestan.Server;
using Menchestan.Server.Model;
using Menchestan.Localization;
using System.Collections.Generic;

namespace Menchestan
{
    namespace IAB
    {
        namespace IABItems
        {
            public class PieceIconItem : GoodItem
            {
                public Image icon;
                public Localize value;
                public Image sourceIcon;
                public RectTransform valueRectTransform;
                private void ChangePieceRing()
                {
                    ServerKit.Instance.UpdateData(GameManager.Instance.user, new Dictionary<string, object>() { { "selectedPieceIcon", good.key } }, OnSelectionChanged);
                }

                private void OnSelectionChanged(bool status, UserSetModel response, string message, int code)
                {
                    if (status)
                    {
                        store.selected?.SetData();
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
                    button.onClick.RemoveAllListeners();
                    if (GameManager.Instance.iabManager.icons.ContainsKey(good.icon))
                    {
                        icon.sprite = GameManager.Instance.iabManager.icons[good.icon];
                    }
                    else
                    {
                        icon.sprite = GameManager.Instance.iabManager.icons["None"];
                    }
                    if (GameManager.Instance.user.pieceIcons.Contains(good.key))
                    {
                        sourceIcon.gameObject.SetActive(false);
                        if (good.key == GameManager.Instance.user.selectedPieceIcon)
                        {
                            button.gameObject.SetActive(false);
                            store.selected = this;
                            ((PieceStore)store).OnSelect(icon.sprite);
                        }
                        else
                        {
                            button.gameObject.SetActive(true);
                            valueRectTransform.offsetMin = new Vector2(8, 4);
                            valueRectTransform.offsetMax = new Vector2(-8, -4);
                            value.SetKey("Choose");
                            button.onClick.AddListener(() => ChangePieceRing());
                        }
                    }
                    else
                    {
                        sourceIcon.gameObject.SetActive(true);
                        value.SetKey(good.value.ToString());
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