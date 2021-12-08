﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Menchestan.GamePlay;
namespace Menchestan
{
    namespace Menu
    {
        public class OnlineMenu : SimpleMenu<OnlineMenu>
        {
            private int maxClients = 2;
 public GameType Gtype;
            public List<int> roomEntrance = new List<int>();
            public int currentEntranceIndex = 0;
            public RTLTMPro.RTLTextMeshPro entrance;
            public Button increaseButton;
            public Button decreaseButton;

            public void PlayOnline()
            {
                if (GameManager.Instance.isOnline)
                {
                    if (roomEntrance[currentEntranceIndex] <= GameManager.Instance.user.coin)
                    {
                        Hide();
                        BoardMenu.Show();
                        BoardMenu.Instance.PlayOnline(Gtype,roomEntrance[currentEntranceIndex], maxClients, "Default", "Classic");
                    }
                    else
                    {
                        //not enough money
                        DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.OkCancel, "NotEnoughCoin", "MsgNotEnoughCoin", () =>
                        {
                            DialogBoxMenu.Hide();
                            StoreMenu.Show();
                        });
                    }
                }
                else
                {
                    // must be online
                    DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.TryCancel, "Error", "ConnectionError", () =>
                    {
                        DialogBoxMenu.Hide();
                        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                    });
                }
            }
            public void IncreaseEntrance()
            {
                decreaseButton.interactable = true;
                currentEntranceIndex = Mathf.Clamp(++currentEntranceIndex, 0, roomEntrance.Count - 1);
                entrance.text = roomEntrance[currentEntranceIndex].ToString();
                if (currentEntranceIndex == roomEntrance.Count - 1)
                    increaseButton.interactable = false;
            }
            public void DecreaseEntrance()
            {
                increaseButton.interactable = true;
                currentEntranceIndex = Mathf.Clamp(--currentEntranceIndex, 0, roomEntrance.Count - 1);
                entrance.text = roomEntrance[currentEntranceIndex].ToString();
                if (currentEntranceIndex == 0)
                    decreaseButton.interactable = false;
   if (Gtype == GameType.Fast && currentEntranceIndex == 4)
                    decreaseButton.interactable = false;
            }

            public void OnGameTypeChange(int value)
            {
                if (value == 0)
                {
                    Gtype = GameType.Classic;
                    currentEntranceIndex = 0;
                    decreaseButton.interactable = false;
                    increaseButton.interactable = true;
                    entrance.text = roomEntrance[currentEntranceIndex].ToString();
                }
                else
                {
                    Gtype = GameType.Fast;
                    currentEntranceIndex = 4;
                    entrance.text = roomEntrance[currentEntranceIndex].ToString();
                }
            }

            public void OnPlayerCountChanged(int value)
            {
                maxClients = value;
            }
            public override void OnBackPressed()
            {
                Hide();
            }
        }
    }
}