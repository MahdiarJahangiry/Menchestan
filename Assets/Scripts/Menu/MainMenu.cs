using RTLTMPro;
using UnityEngine;
using DG.Tweening;
using Menchestan.Server.Model;
using System.Collections.Generic;

namespace Menchestan
{
    namespace Menu
    {
        public class MainMenu : SimpleMenu<MainMenu>
        {
            public RTLTextMeshPro coinValue;
            private GoodModel videoFreeCoin;
            private readonly string videoFreeCoinKey = "freecoinvideo";

            private void OnEnable()
            {
                if (GameManager.Instance.isOnline && GameManager.Instance.user != null)
                {
                    GameManager.Instance.user.CoinChanged += OnCoinChanged;
                    GameManager.Instance.user.OncoinChanged(0, GameManager.Instance.user.coin);
                }
                else
                {
                    coinValue.text = "0";
                }
            }
            private void OnDisable()
            {
                if (GameManager.Instance.isOnline && GameManager.Instance.user != null)
                {
                    DOTween.Kill("CoinChanged");
                    GameManager.Instance.user.CoinChanged -= OnCoinChanged;
                }
            }
            private void OnCoinChanged(int oldValue, int newValue)
            {
                DOTween.Kill("CoinChanged");
                DOTween.To(() => oldValue, x => coinValue.text = x.ToString(), newValue, 1.0f).SetTarget("CoinChanged");
            }
            public void OnSettingPressed()
            {
                SettingMenu.Show();
            }
            public void OnNewsPressed()
            {
                NewsMenu.Show();
            }

            public void OnOnlinePressed()
            {
                OnlineMenu.Show();
            }
            public void OnOfflinePressed()
            {
                OfflineMenu.Show();
            }
            public void OnFortuneWheelPressed()
            {
                if (GameManager.Instance.isOnline)
                    FortuneWheelMenu.Show();
                else
                    DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.YesNo, "Error", "MsgOnline", () => UnityEngine.SceneManagement.SceneManager.LoadScene(0));
            }
            public void OnWatchVideoPressed()
            {
                if (GameManager.Instance.isOnline)
                    GameManager.Instance.videoAdManager.RequestVideoAdd("5f5fdb49b081620001cc876d", true, OnVideoReward);
                else
                    DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.YesNo, "Error", "MsgOnline", () => UnityEngine.SceneManagement.SceneManager.LoadScene(0));
            }

            private void OnVideoReward(bool status, string message)
            {
                if (status)
                {
                    Reward();
                }
                else
                {
                    DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "Error", message);
                }
            }
            private void Reward()
            {
                if (videoFreeCoin == null)
                    videoFreeCoin = GameManager.Instance.iabManager.goods.items.Find(g => g.key == videoFreeCoinKey);

                GameManager.Instance.iabManager.PurchaseByServer(videoFreeCoin, null, null, Reward);
            }

            public void OnStorePressed()
            {
                if (GameManager.Instance.isOnline)
                    StoreMenu.Show();
                else
                    DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.YesNo, "Error", "MsgOnline", () => UnityEngine.SceneManagement.SceneManager.LoadScene(0));
            }
            public void OnProfilePressed()
            {
                ProfileMenu.Show();
            }
            public void OnFriendPressed()
            {
                DialogBoxMenu.Instance.ShowLoserBox(3200, null);
            }
            public void OnLeaderBoardPressed()
            {
                //DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.OkCancel, "Help", "Continue", new List<string>() { "Red", "DDF" });
                HelpMenu.Show();
            }
            public void OnFreeCoinPressed()
            {
                DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.OkCancel, "Help", "Continue", new List<string>() { "Red", "DDF" });
            }
            public override void OnBackPressed()
            {
                DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.YesNo, "Exit", "MsgExit", () => Application.Quit());
            }
        }
    }
}