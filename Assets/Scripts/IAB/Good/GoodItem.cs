using UnityEngine;
using UnityEngine.UI;
using Menchestan.Server.Model;
using Menchestan.Menu;
using System;

namespace Menchestan
{
    namespace IAB
    {
        namespace IABItems
        {
            public abstract class GoodItem : MonoBehaviour
            {
                public Button button;
                public GoodModel good;
                public Store store;
                public virtual void SetData()
                {
                    if (good.ismarket)
                    {
                        button.onClick.AddListener(() => PurchaseByMarket());
                    }
                    else
                    {
                        button.onClick.AddListener(() => PurchaseByServer());
                    }
                }
                private void PurchaseByMarket()
                {
                    GameManager.Instance.iabManager.PurchaseByMarket(good, OnBurchaseByServer, PurchaseByMarket);
                }
                private void PurchaseByServer()
                {
                    GameManager.Instance.iabManager.PurchaseByServer(good, null, OnBurchaseByServer, PurchaseByServer);
                }
                private void OnBurchaseByServer(bool status, UserSetModel response, string message, int code)
                {
                    if (status)
                    {
                        DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "Success", message);
                    }
                    else
                    {
                        DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "Error", message);
                    }
                }
            }
        }
    }
}