using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;
using Menchestan.Localization;

namespace Menchestan
{
    namespace Menu
    {
        public class OfflineMenu : SimpleMenu<OfflineMenu>
        {
            private int maxPlayers = 2;
            private int maxBotPlayers = 0;
            public RTLTextMeshPro botNumber;
            public Button increaseBotButton;
            public Button decreaseBotButton;
            public Localize remainingQuota;
            private void OnEnable()
            {
                remainingQuota.formatValues = new System.Collections.Generic.List<string>() { GameManager.Instance.remainingQuota.ToString(), GameManager.Instance.maxQuota.ToString() };
            }
            public void PlayOffline()
            {
                if (GameManager.Instance.remainingQuota > 0)
                {
                    Hide();
                    PlayerPrefs.SetInt("OfflineTicket", --GameManager.Instance.remainingQuota);
                    BoardMenu.Show();
                    BoardMenu.Instance.PlayOffline(maxBotPlayers, maxPlayers, "Default", "Classic");
                }
                else
                {
                    DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "Error", "MsgOfflineMatchOver");
                }
            }
            public void OnHumanCountChanged(int value)
            {
                maxPlayers = value;
                maxBotPlayers = Mathf.Clamp(maxBotPlayers, 0, maxPlayers - 1);
                botNumber.text = maxBotPlayers.ToString();
                if (maxBotPlayers == maxPlayers - 1)
                    increaseBotButton.interactable = false;
                else
                    increaseBotButton.interactable = true;
                if (maxBotPlayers == 0)
                    decreaseBotButton.interactable = false;
                else
                    decreaseBotButton.interactable = true;
            }
            public void IncreaseBotPlayer()
            {
                decreaseBotButton.interactable = true;
                maxBotPlayers = Mathf.Clamp(++maxBotPlayers, 0, maxPlayers - 1);
                botNumber.text = maxBotPlayers.ToString();
                if (maxBotPlayers == maxPlayers - 1)
                    increaseBotButton.interactable = false;
            }
            public void DecreaseBotPlayer()
            {
                increaseBotButton.interactable = true;
                maxBotPlayers = Mathf.Clamp(--maxBotPlayers, 0, maxPlayers - 1);
                botNumber.text = maxBotPlayers.ToString();
                if (maxBotPlayers == 0)
                    decreaseBotButton.interactable = false;
            }
            public override void OnBackPressed()
            {
                Hide();
            }
        }
    }
}