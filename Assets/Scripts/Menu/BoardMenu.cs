using DG.Tweening;
using UnityEngine;
using NativeWebSocket;
using Menchestan.Audio;
using Menchestan.Server;
using Menchestan.GamePlay;
using Menchestan.Menu.HUD;
using Menchestan.Server.Model;
using Menchestan.GamePlay.Player;
using System.Collections.Generic;
using System;
using Colyseus;

namespace Menchestan
{
    namespace Menu
    {
        public class BoardMenu : SimpleMenu<BoardMenu>
        {
            public CountDown countDown;
            public override void Init()
            {
                base.Init();
            }

            public void OnExitPressed()
            {
                OnBackPressed();
            }

            public void OnSettingPressed()
            {
                SettingMenu.Show();
            }

            public void OnHelpPressed()
            {
                HelpMenu.Show();
            }

            public void OnChatPressed()
            {

            }
            private new void OnDestroy()
            {
                if (countDown.bWEffect != null)
                {
                    countDown.bWEffect.intensity = 0;
                    Destroy(countDown.bWEffect);
                }
            }
            public override void OnBackPressed()
            {
                DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.YesNo, "Exit", "MsgExit", () =>
                {
                    if (GameController.Instance.gameMode == GameMode.Offline)
                    {
                        OnCloseOfflineGame();
                    }
                    else
                    {
                        OnCloseOnlineGame();
                    }
                });
            }
            async void OnCloseOnlineGame()
            {
                try
                {
                    await GameController.Instance.room.Leave(true);
                    UpdateUserData();
                }
                catch (Exception)
                {
                    DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.TryOffline, "Error", "ConnectionError", new List<Action>
                    {
                        () =>
                        {
                            DialogBoxMenu.Hide();
                            OnCloseOnlineGame();
                        } ,
                        () =>
                        {
                            GameManager.Instance.isOnline = false;
                            OnCloseOfflineGame();
                        }
                    });
                }
            }
            public void PlayOnline(GameType Gtype,int entrance, int maxClients, string diceName, string mapName)
            {
                void OnAuthError()
                {
                    GameManager.Instance.isOnline = false;
                    DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.TryOffline, "Error", "ConnectionError", new List<Action>
                        {
                            () =>
                            {
                                DialogBoxMenu.Hide();
                                PlayOnline(Gtype,entrance, maxClients, diceName, mapName);
                            } ,
                            () =>
                            {
                                OnCloseOfflineGame();
                            }
                        });
                }
                try
                {
                    if (ServerKit.Instance.isDebug)
                    {
                        GameController.Instance.client = ColyseusManager.Instance.CreateClient("ws://127.0.0.1:2567");
                    }
                    else
                    {
                        GameController.Instance.client = ColyseusManager.Instance.CreateClient("ws://37.152.176.107:2567");
                    }
                    //GameController.Instance.client.Auth.OnAuthError = OnAuthError;
                    //await GameController.Instance.client.Auth.Login();
                    GameController.Instance.InitGame(GameMode.Online, Gtype, entrance, maxClients, diceName, mapName);
                    GameController.Instance.OnGameFinish += OnGameFinished;
                    GameController.Instance.OnGameFinish += OnOnlineGameFinished;
                    GameController.Instance.OnGameStart += OnOnlineGameStarted;
                    countDown.gameObject.SetActive(true);
                }
                catch (Exception)
                {
                    OnAuthError();
                }
            }
            private void OnOnlineGameStarted()
            {
                countDown.gameObject.SetActive(false);
                countDown.canIterate = false;
            }

            public void PlayOffline(int maxBotPlayers, int maxClients, string diceName, string mapName)
            {
                GameController.Instance.InitGame(GameMode.Offline, GameType.Classic, maxBotPlayers, maxClients, diceName, mapName);
                GameController.Instance.OnGameFinish += OnGameFinished;
                GameController.Instance.OnGameFinish += OnOfflineGameFinished;
                countDown.gameObject.SetActive(false);
            }
            private void OnGameFinished(WebSocketCloseCode finishCode, MPlayer player)
            {
                if (player != null)
                {
                    if (!player.isBot)
                    {
                        AudioManager.Instance.PlayAudio(Audio.AudioType.SFX_YouWin);
                    }
                    else
                    {
                        AudioManager.Instance.PlayAudio(Audio.AudioType.SFX_YouLose);
                    }
                }
            }
            private void OnOfflineGameFinished(WebSocketCloseCode finishCode, MPlayer player)
            {
                DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "EndGame", "MsgWin", new List<string> { player.teamMembers[0].colorPalette.ToString() }, OnCloseOfflineGame);
            }
            private void OnOnlineGameFinished(WebSocketCloseCode finishCode, MPlayer player)
            {
                Debug.Log(finishCode.ToString());
                if (finishCode == WebSocketCloseCode.InvalidData)
                {
                    float myProperty = 0;
                    countDown.canIterate = false;
                    DOTween.To(() => myProperty = 0, x => myProperty = x, 1, 1).OnComplete(() =>
                    {
                        DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "EndGame", "MsgWin", null, OnCloseOfflineGame);
                    });
                }
                else if (finishCode == WebSocketCloseCode.Normal)
                {
                    if (player == null)
                    {
                        UpdateUserData();
                    }
                    else
                    {
                        if (player.sessionId == GameController.Instance.room.SessionId)
                        {
                            DialogBoxMenu.Instance.ShowWinnerBox(GameController.Instance.coinInc, UpdateUserData);
                        }
                        else
                        {
                            DialogBoxMenu.Instance.ShowLoserBox(GameController.Instance.coinInc, UpdateUserData);
                        }
                    }
                }
                else if (finishCode == WebSocketCloseCode.PolicyViolation)
                {
                    float myProperty = 0;
                    DOTween.To(() => myProperty = 0, x => myProperty = x, 1, 1).OnComplete(() =>
                    {
                        DialogBoxMenu.Instance.ShowLoserBox(GameController.Instance.coinInc, UpdateUserData);
                    });
                }
            }
            private void UpdateUserData()
            {
                ServerKit.Instance.GetData(GameManager.Instance.user, new Dictionary<string, object>() { { "coin", 1 }, { "loseCont", 1 }, { "winCont", 1 } }, OnUserDataUpdated);
            }

            private void OnUserDataUpdated(bool status, UserSetModel response, string message, int code)
            {
                GameManager.Instance.isOnline = status;
                if (status)
                {
                    OnCloseOfflineGame();
                }
                else
                {
                    DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.TryOffline, "Error", "GameDataError", new List<Action>
                    {
                        () =>
                        {
                            DialogBoxMenu.Hide();
                            OnUserDataUpdated(status, response, message, code);
                        } ,
                        () =>
                        {
                            OnCloseOfflineGame();
                        }
                    });
                }
            }

            private void OnCloseOfflineGame()
            {
                DialogBoxMenu.Hide();
                ForceHide();
            }
        }
    }
}