using Colyseus;
using UnityEngine;
using System.Linq;
using Menchestan.Audio;
using System.Collections;
using Sirenix.OdinInspector;
using Menchestan.GamePlay.Dice;
using Menchestan.GamePlay.Board;
using Menchestan.GamePlay.Player;
using System.Collections.Generic;
using NativeWebSocket;
using System;

namespace Menchestan
{
    namespace GamePlay
    {
        public enum GameMode
        {
            Online,
            Offline
        }
        public enum GameType
        {
            Classic,
            Fast
        }

        public class GameController : SerializedMonoBehaviour
        {
            #region Singleton
            private static GameController instance;
            public static GameController Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = FindObjectOfType<GameController>();
                        if (instance == null)
                        {
                            GameObject tmp = new GameObject();
                            instance = tmp.AddComponent<GameController>();
                        }
                        instance.name = "GameController";
                    }
                    return instance;
                }
            }
            #endregion
            #region Online
            private const string roomName = "demo";
            public Client client;
            public Room<BoardState> room;
            private int pieceId = -1;
            #endregion
            public GameMode gameMode = GameMode.Online;
            public GameType gameType = GameType.Classic;
            public Timer GameTimer;
            public MBoard board;
            private Dictionary<string, MPlayer> players = new Dictionary<string, MPlayer>();
            public MDice dice;
            public int turnNum = -1;
            public int activePlayers;
            public string sessionId = "";
            public float remainigTime = 0.5f;
            public float rollTime = 0;
            public float moveTime = 0;
            public float turnTime = 0;
            public float botWaitTime = 0;

            private bool inRoll;
            private bool inMove;
            private bool canRoll;
            private int diceValue;
            public int coinInc;
            public int virCount = 0;
            private int virRetryCount = 2;
            private bool isGameFinished;
            public delegate void OnVoidChange();
            public delegate void OnFloatChange(float value);
            public delegate void OnStringChange(string value);
            public delegate void OnPlayerWin(WebSocketCloseCode finishCode, MPlayer player);

            public event OnVoidChange OnTurnChange;
            public void TurnChanged()
            {
                OnTurnChange?.Invoke();
                if (!string.IsNullOrEmpty(sessionId))
                {
                    OnLostDiceTime -= players[sessionId].LostDiceTime;
                    OnLostMoveTime -= players[sessionId].LostMoveTime;
                    players[sessionId].Locked();
                    players[sessionId].TurnPassed();
                    TimeChanged(0);
                    OnGrabTurnWithTime = null;
                    OnTimeChange = null;
                }
                if (gameMode == GameMode.Offline)
                {
                    dice.OnRollRequest -= Roll;
                  if (!string.IsNullOrEmpty(sessionId))
                    {
                        Debug.Log("isVir : " + players[sessionId].isVir);
                        Debug.Log("VirCount : " + virCount);
                    }
                    if (diceValue != 6 && !(!string.IsNullOrEmpty(sessionId) && players[sessionId].isVir && virCount != 0))
                    {
                        sessionId = GetNextPlayer();
                        if (players[sessionId].isVir)
                            virCount = virRetryCount;
                    }
                    if (!players[sessionId].isBot)
                    {
                        players[sessionId].OnTurnRecived();
                    }
                    OnLostDiceTime += players[sessionId].LostDiceTime;
                    OnLostMoveTime += players[sessionId].LostMoveTime;
                    botWaitTime = UnityEngine.Random.Range(1, players[sessionId].botWaitTime);
                    moveTime = players[sessionId].moveTime;
                    rollTime = players[sessionId].rollTime;
                    remainigTime = rollTime;
                }
                else if (gameMode == GameMode.Online)
                {
                    dice.OnRollRequest -= OnlineRoll;
                    if (sessionId == room.SessionId)
                    {
                        players[sessionId].OnTurnRecived();
                    }
                }
                OnGrabTurnWithTime += players[sessionId].OnGrabTurnWithTime;
                OnTimeChange += players[sessionId].OnTimeChange;
                turnTime = rollTime;
                GrabTurnWithTime(turnTime);
                inMove = false;
                canRoll = true;
            }
            private void RollTheDice()
            {
                if (gameMode == GameMode.Offline)
                {
                    if (players[sessionId].isBot)
                    {
                        StartCoroutine(BotRoll());
                    }
                    else
                    {
                        dice.OnRollRequest += Roll;
                    }
                }
                else
                {
                    if (sessionId == room.SessionId)
                    {
                        dice.OnRollRequest += OnlineRoll;
                    }
                    else
                    {
                        StartCoroutine(BotOnlineRoll());
                    }
                }
            }
            readonly Dictionary<int, List<int>> playerOrder = new Dictionary<int, List<int>>() {
                { 2, new List<int>() { 0, 1 } },
                { 3, new List<int>() { 0, 2, 1 } },
                { 4, new List<int>() { 0, 2, 1, 3 } }
            };
            private string GetNextPlayer()
            {
                int index = ++turnNum % activePlayers;
              sessionId = "Player" + playerOrder[activePlayers][index].ToString();
                while (players[sessionId].lost && players.Count!=1)
                {
                    index = ++turnNum % activePlayers;
                    sessionId = "Player" + playerOrder[activePlayers][index].ToString();
                }
                return "Player" + playerOrder[activePlayers][index].ToString();
            }
            public event OnFloatChange OnGrabTurnWithTime;
            public void GrabTurnWithTime(float time)
            {
                OnGrabTurnWithTime?.Invoke(time);
            }
            public event OnFloatChange OnTimeChange;
            public void TimeChanged(float time)
            {
                OnTimeChange?.Invoke(time);
            }
            public event OnVoidChange OnLostDiceTime;
            public void LostDiceTime()
            {
                OnLostDiceTime?.Invoke();
            }
            public event OnVoidChange OnLostMoveTime;
            public void LostMoveTime()
            {
                diceValue = 0;
                OnLostMoveTime?.Invoke();
            }
            public event OnVoidChange OnThinkTime;
            public void ThinkTime()
            {
                OnThinkTime?.Invoke();
                if (canRoll)
                {
                    ThinkInDiceTime();
                }
                else
                {
                    ThinkInMoveTime();
                }
            }
            public event OnStringChange OnPlayerUnRegister;
            public void PlayerUnRegistered(string sessionId)
            {
                OnPlayerUnRegister?.Invoke(sessionId);
               // players.Remove(sessionId);
                if (gameMode == GameMode.Offline)
                  {
                    int lostnu = 0;
                    for(int i=0;i<players.Count;i++)
                    {
                        if (players["Player"+i].lost)
                            lostnu++;
                    }
                   
                    if (lostnu ==players.Count-1)
                {
                    GameFinished(WebSocketCloseCode.Normal, players.First().Value);
                }
            }
          }
            public event OnVoidChange OnThinkInDiceTime;
            public void ThinkInDiceTime()
            {
                OnThinkInDiceTime?.Invoke();
            }
            public event OnVoidChange OnThinkInMoveTime;
            public void ThinkInMoveTime()
            {
                OnThinkInMoveTime?.Invoke();
            }
            public event OnVoidChange OnInMoveTime;
            public void InMoveTime()
            {
                OnInMoveTime?.Invoke();
            }
            public event OnVoidChange OnInRollTime;
            public void InRollTime()
            {
                OnInRollTime?.Invoke();
            }
            public event OnVoidChange OnNoMove;
            public void NoMove()
            {
                OnNoMove?.Invoke();
            }
            public event OnPlayerWin OnGameFinish;
            public void GameFinished(WebSocketCloseCode finishCode, MPlayer player)
            {
                isGameFinished = true;
                OnGameFinish?.Invoke(finishCode, player);
            }
            public event OnVoidChange OnGameStart;
            public void GameStarted()
            {
                OnGameStart?.Invoke();
            }

           

            private void BoradInit(bool isfast,string diceName, string mapName)
            {
                board = Instantiate(Resources.Load("Boards/" + mapName, typeof(MBoard)), transform) as MBoard;
                board.Init(isfast);
                dice = Instantiate(Resources.Load("Dices/2D/" + diceName, typeof(MDice)), transform) as MDice;
                dice.Init(board.dice2DPosition, Color.white, Color.black);
            }
            private void OfflineInit(int botNumber, int maxPlayers, string diceName, string mapName)
            {
                BrainType brain = BrainType.Human;
                gameMode = GameMode.Offline;

                BoradInit(false, diceName, mapName);

                OnNoMove += TurnChanged;
                OnNoMove += RollTheDice;

                OnLostDiceTime += TurnChanged;
                OnLostDiceTime += RollTheDice;

                OnLostMoveTime += TurnChanged;
                OnLostMoveTime += RollTheDice;
                dice.OnRolled += OnDiceRolled;
                dice.OnRolled += UpdateVirState;
                activePlayers = Mathf.Clamp(activePlayers, maxPlayers, board.startPoints.Count);
                int humanNumber = activePlayers - botNumber;
                bool lastIsHuman = false;
                for (int i = 0; i < activePlayers; i++)
                {
                    string sessionId = "Player" + i.ToString();
                    if (lastIsHuman && botNumber != 0 || humanNumber == 0)
                    {
                        brain = BrainType.GammaBot;
                        botNumber--;
                        lastIsHuman = false;
                    }
                    else if (botNumber == 0 || !lastIsHuman)
                    {
                        brain = BrainType.Human;
                        humanNumber--;
                        lastIsHuman = true;
                    }
                    MPlayer player = new MPlayer(this, sessionId, board.startPoints[i], brain, PieceType.Default, 3, GameManager.Instance.user.selectedPieceRing, GameManager.Instance.user.selectedPieceIcon, GameManager.Instance.user.selectedPieceGem, i == 0 ? GameManager.Instance.user.displayName : sessionId, true);
                    players.Add(sessionId, player);
                    player.OnMoveStart += MoveStarted;
                    player.OnMoveEnd += MoveEnded;
                    player.OnGameFinish += GameFinished;
                }
                TurnChanged();
                RollTheDice();
            }
            private void UpdateVirState(int value)
            {
                 if(gameType == GameType.Fast)
                    players[sessionId].isVir = false;
                if (value == 6)
                {
                    players[sessionId].isVir = false;
                }

                else
                {
                    virCount -= 1;
                }
            }
            async void OnlineInit(GameType gType,int entrance, int maxClients, string diceName, string mapName)
            {
                gameMode = GameMode.Online;
                gameType = gType;
                string mode = "Classic";
                
                if (gameType == GameType.Fast)
                {
                    mode = "Fast";
                    var go = Instantiate(GameTimer.gameObject, transform);
                    Timer gametimer = go.GetComponent<Timer>();
                    Timer.timeEnd += OnTimerEnd;
                    gametimer.Invoke("StartTimer", 10);
                    BoradInit(true, diceName, mapName);
                   
                }
                else
                {
                    mode = "Classic";
                    BoradInit(false, diceName, mapName);
                }
                Debug.Log("mode: " + mode);
                dice.OnRolled += OnOnlineDiceRolled;
                coinInc = -entrance;
                string roomId = PlayerPrefs.GetString("roomId", "");
                string sessionId = PlayerPrefs.GetString("sessionId", "");
                room = await client.JoinOrCreate<BoardState>(roomName, new Dictionary<string, object>() {{ "mode", mode} , { "map", mapName }, { "entrance", entrance }, { "maxClients", maxClients } });
                canCheck = true;
                lastConnection = true;
                RegisterRoomHandlers();
                await room.Send("state", "sceneLoad");
                InvokeRepeating("CheckConnection", 1, 1);
            }
         void OnTimerEnd()
            {
                Debug.Log("Game Time Ended");

                MPlayer plWin= players.First().Value;
                int winvalue = 0;
                //Chekforwinners;
               foreach (KeyValuePair<string, MPlayer> pl in players)
                {
                    Console.WriteLine(pl.Key + " : " + pl.Value);
                    if (pl.Value.piecesInSafePoint>winvalue)
                    {
                        winvalue = pl.Value.piecesInSafePoint;
                        plWin = pl.Value;
                    }
                     
                }

                GameFinished(WebSocketCloseCode.Normal, plWin);
            }
            private bool lastConnection;
            private bool canCheck;
            private void CheckConnection()
            {
                if (canCheck)
                {
                    if (room.Connection.IsOpen)
                    {
                        //Debug.Log("Connected");
                        if (lastConnection == false)
                        {
                            canCheck = false;
                            string roomId = PlayerPrefs.GetString("roomId", "");
                            string sessionId = PlayerPrefs.GetString("sessionId", "");
                            ReconnectRoom(roomId, sessionId);
                        }
                        lastConnection = true;
                    }
                    else
                    {
                        Debug.Log("DisConnected");
                        if (lastConnection == true)
                        {
                            canCheck = true;
                        }
                        lastConnection = false;
                        PlayerUnRegistered(this.sessionId);
                    }
                }
            }
            private void MoveStarted(Piece piece, Piece hitted)
            {
                players[sessionId].Locked();
                inMove = true;
            }
            private void MoveEnded(Piece piece)
            {
                if (!isGameFinished)
                {
                    TurnChanged();
                    RollTheDice();
                }
            }
            private void FixedUpdate()
            {
                if (isGameFinished)
                {
                }
                else
                {
                    if (inRoll)
                    {
                        InRollTime();
                    }
                    else if (inMove)
                    {
                        InMoveTime();
                    }
                    else
                    {
                        remainigTime -= Time.fixedDeltaTime;
                        TimeChanged(remainigTime);
                        if (remainigTime < 0)
                        {
                            TimeLost();
                        }
                        else
                        {
                            ThinkTime();
                        }
                    }
                }
            }
            private void TimeLost()
            {
                remainigTime = -0.01f;
                if (canRoll)
                {
                    canRoll = false;
                    LostDiceTime();
                }
                else
                {
                    LostMoveTime();
                }
            }
            IEnumerator BotOnlineRoll()
            {
                yield return new WaitForSeconds(botWaitTime);
                OnlineRoll(diceValue);
            }
            private async void OnlineRoll(int value)
            {
                if (canRoll)
                {
                    //Send To the server i start roll the dice
                    value = diceValue;
                    if (sessionId == room.SessionId)
                    {
                        await room.Send("state", "rollStart");
                    }
                    canRoll = false;
                    inRoll = true;
                    AudioManager.Instance.PlayAudio(Audio.AudioType.SFX_DiceRoll);
                    dice.Roll(value);
                }
            }
            IEnumerator BotRoll()
            {
                yield return new WaitForSeconds(botWaitTime);
                Roll(-1);
            }
            private void Roll(int value)
            {
                if (canRoll)
                {
                    canRoll = false;
                    inRoll = true;
                    AudioManager.Instance.PlayAudio(Audio.AudioType.SFX_DiceRoll);
                    dice.Roll(value);
                }
            }
            private async void OnOnlineDiceRolled(int value)
            {
                if (sessionId == room.SessionId)
                {
                    await room.Send("state", "rollEnd");
                }
                Debug.Log(sessionId + "OnlineDiceMove ");
                OnDiceRolled(diceValue);
            }
            private void OnDiceRolled(int value)
            {
                inRoll = false;
                AudioManager.Instance.StopAudio(Audio.AudioType.SFX_DiceRoll);
                diceValue = value;
                if (players[sessionId].UnLocked(value))
                {
                    turnTime = moveTime;
                    remainigTime = turnTime;
                    GrabTurnWithTime(turnTime);
                    if (gameMode == GameMode.Online && sessionId != room.SessionId && pieceId != -1)
                    {
                        players[sessionId].GetPieceById(pieceId).Invoke("Move", 0);
                        pieceId = -1;
                    }
                }
                else
                {
                    //On Not Valid Move
                    NoMove();
                    diceValue = 0;
                    //remainigTime = 0;
                    if (gameMode == GameMode.Online)
                    {
                        OnlineMoveEnd(null);
                    }
                }
            }
            public void JoinOrCreateRoom1()
            {
                //JoinOrCreateRoom();
            }
            private void OnDestroy()
            {
                //if (gameMode == GameMode.Online)
                //{
                //    LeaveRoom();
                //}
                CachedMove.DeleteLastMove();
                PlayerPrefs.SetString("roomId", "");
                PlayerPrefs.SetString("sessionId", "");
            }
            public async void OnTurnEnd()
            {
                await room.Send("state", "turnEnd");
            }
            class PieceMove
            {
                public string movedPieceId;
                public string hittedSessionId;
                public string hittedPieceId;
            }
            static class CachedMove
            {
                public static PieceMove SaveLastMove(Piece piece, Piece hitted)
                {
                    PieceMove piceMove = new PieceMove
                    {
                        movedPieceId = piece.name,
                        hittedSessionId = hitted != null ? hitted.sessionId : "",
                        hittedPieceId = hitted != null ? hitted.name : ""
                    };
                    PlayerPrefs.SetString("LastMove", JsonUtility.ToJson(piceMove));
                    PlayerPrefs.Save();
                    return piceMove;
                }
                public static PieceMove LoadLastMove()
                {
                    string piecMoveStr = PlayerPrefs.GetString("LastMove", "");
                    if (string.IsNullOrEmpty(piecMoveStr))
                        return null;
                    return JsonUtility.FromJson<PieceMove>(piecMoveStr);
                }
                public static bool IsCached => !string.IsNullOrEmpty(PlayerPrefs.GetString("LastMove", ""));
                public static void DeleteLastMove()
                {
                    PlayerPrefs.SetString("LastMove", "");
                    PlayerPrefs.Save();
                }
            }
            public async void OnlineMoveStart(Piece piece, Piece hitted)
            {
                PieceMove pieceMove = CachedMove.SaveLastMove(piece, hitted);
                players[sessionId].Locked();
                await room.Send("moveStart", new
                {
                    pieceMove.movedPieceId,
                    pieceMove.hittedSessionId,
                    pieceMove.hittedPieceId
                });
                CachedMove.DeleteLastMove();
                inMove = true;
            }
            public async void OnlineMoveEnd(Piece piece)
            {
                await room.Send("state", "moveEnd");
            }
            private void OnLeaved(WebSocketCloseCode finishCode)
            {
                if (finishCode == WebSocketCloseCode.PolicyViolation)
                    OnGameFinish(finishCode, null);
            }
            public void RegisterRoomHandlers()
            {
                room.State.players.OnAdd += OnPlayerAdd;
                room.State.players.OnRemove += OnPlayerRemove;
                room.State.players.OnChange += OnPlayerMove;

                room.State.TriggerAll();
                PlayerPrefs.SetString("roomId", room.Id);
                PlayerPrefs.SetString("sessionId", room.SessionId);
                PlayerPrefs.Save();
                room.OnLeave += OnLeaved;
                room.OnError += (code, message) => Debug.LogError("ERROR, code =>" + code + ", message => " + message);
                room.OnStateChange += OnStateChangeHandler;
                room.OnMessage<StateMessage>("state", (message) =>
                {
                    Debug.Log(room.State.players.Count);
                    Debug.Log("Message >> " + message.state);
                    switch (message.state)
                    {
                        case "loading":
                            GameStarted();
                            break;
                        case "TestConn":
                            sessionId = message.sessionId;
                            SendConnected(sessionId);
                            break;
                        case "startTurn":
                            Debug.Log(message.state + ">  <" + message.sessionId + ">  <" + message.diceValue);
                            if (players.ContainsKey(sessionId))
                                players[sessionId].Locked();
                            rollTime = message.rollTime;
                            moveTime = message.moveTime;
                            remainigTime = message.remainigTime;
                            botWaitTime = message.botWaitTime;
                            diceValue = message.diceValue;
                            sessionId = message.sessionId;
                            TurnChanged();
                            RollTheDice();
                            break;
                        case "observer":
                            rollTime = message.rollTime;
                            moveTime = message.moveTime;
                            remainigTime = message.remainigTime;
                            sessionId = message.sessionId;
                            TurnChanged();
                            break;
                        case "rollStart":
                            rollTime = message.rollTime;
                            moveTime = message.moveTime;
                            remainigTime = message.remainigTime;
                            botWaitTime = 0;
                            diceValue = message.diceValue;
                            sessionId = message.sessionId;
                            RollTheDice();
                            break;
                        case "rollTimePassed":
                            players[sessionId].LostDiceTime();
                            TimeLost();
                            break;
                        case "moveTimePassed":
                            if (players.ContainsKey(sessionId))
                            {
                                players[sessionId].Locked();
                                players[sessionId].LostMoveTime();
                            }
                            TimeLost();
                            break;
                        case "moveStart":
                            pieceId = message.diceValue;
                            if (!inRoll)
                            {
                                if (players.ContainsKey(sessionId))
                                    players[sessionId].GetPieceById(pieceId).Invoke("Move", 0);
                                pieceId = -1;
                            }
                            break;
                        case "pending-rollStart":
                            rollTime = message.rollTime;
                            moveTime = message.moveTime;
                            remainigTime = message.remainigTime;
                            diceValue = message.diceValue;
                            sessionId = message.sessionId;
                            TurnChanged();
                            RollTheDice();
                            break;
                        case "pending-rollEnd":
                            rollTime = message.rollTime;
                            moveTime = message.moveTime;
                            remainigTime = message.remainigTime;
                            diceValue = message.diceValue;
                            sessionId = message.sessionId;
                            dice.ShowSide(diceValue);
                            OnOnlineDiceRolled(diceValue);
                            break;
                        case "pending-moveStart":
                            rollTime = message.rollTime;
                            moveTime = message.moveTime;
                            remainigTime = message.remainigTime;
                            diceValue = message.diceValue;
                            sessionId = message.sessionId;
                            dice.ShowSide(diceValue);
                            if (CachedMove.IsCached)
                            {
                                PieceMove pieceMove = CachedMove.LoadLastMove();
                                OnDiceRolled(diceValue);
                                if (players.ContainsKey(sessionId))
                                    players[sessionId].GetPieceById(pieceMove.movedPieceId).Invoke("Move", 0);
                            }
                            else
                            {
                                OnDiceRolled(diceValue);
                            }
                            break;
                        case "pending-moveEnd":
                            rollTime = message.rollTime;
                            moveTime = message.moveTime;
                            remainigTime = message.remainigTime;
                            diceValue = message.diceValue;
                            sessionId = message.sessionId;
                            dice.ShowSide(diceValue);
                            OnlineMoveEnd(null);
                            break;
                        case "PlayerDisconect":
                            sessionId = message.sessionId;
                            PlayerUnRegistered(sessionId);
                            break;
                        case "gameFinished":
                            sessionId = message.sessionId;
                            coinInc = message.coinInc;
                            GameFinished(WebSocketCloseCode.Normal, players[sessionId]);
                            break;
                        default:
                            break;
                    }
                });
            }
            class StateMessage
            {
                public string state = "";
                public string sessionId = "";
                public int diceValue = 0;
                public int coinInc = 0;
                public float remainigTime = 0.0f;
                public float rollTime = 0.0f;
                public float moveTime = 0.0f;
                public float botWaitTime = 0.0f;
            }
            public void UnregisterAll()
            {
                for (int i = players.Keys.Count - 1; i >= 0; i--)
                {
                    string key = players.Keys.ElementAt(i);
                    players[key].UnRegister();
                }
            }
            public void ResetBoard()
            {
                dice.OnRollRequest -= OnlineRoll;
                dice.OnRollRequest -= Roll;
                dice.Stop();
                remainigTime = 0.0f;
                diceValue = 0;
                inMove = false;
                canRoll = true;
                inRoll = false;
                sessionId = "";
                pieceId = -1;
            }

            async void SendConnected(string sid)
            {
                Debug.Log("Connection Tested");

                await room.Send("state", "Connected");
            }

            async void ReconnectRoom(string roomId, string sessionId)
            {
                room = await client.Reconnect<BoardState>(roomId, sessionId);
                ResetBoard();
                UnregisterAll();
                Debug.Log("Reconnected into room successfully.");
                RegisterRoomHandlers();
                await room.Send("state", "Connected");
            }



            public async void LeaveRoom()
            {
                if (room != null)
                {
                    await room.Leave(true);
                }
                // Destroy player entities
                string sessionId = PlayerPrefs.GetString("sessionId");
                players[sessionId].UnRegister();
            }
            void OnStateChangeHandler(BoardState state, bool isFirstState)
            {
                // Setup room first state
                Debug.Log("State has been updated! >> ");
            }

            void OnPlayerAdd(OPlayer entity, string key)
            {
                Debug.Log(entity.sessionId + " Added >>>");
                int i = players.Count;
                MPlayer player = new MPlayer(this, entity.sessionId, board.startPoints[i], entity.isBot ? BrainType.BetaBot : BrainType.Human, PieceType.Default, 3, entity.selectedPieceRing, entity.selectedPieceIcon, entity.selectedPieceGem, entity.nickName, entity.isVir);
                players.Add(entity.sessionId, player);
                player.OnMoveStart += OnlineMoveStart;
                player.OnMoveEnd += OnlineMoveEnd;

                //player.OnGameFinish += GameFinished;
                foreach (string pieceKey in entity.pieces.Keys)
                {
                    players[key].GetPieceById(pieceKey).Set(entity.pieces[pieceKey].seat);
                }

                entity.OnChange += (changes) =>
                {
                    changes.ForEach((obj) =>
                    {
                        Debug.Log(obj.Field);
                        Debug.Log(obj.Value);
                        Debug.Log(obj.PreviousValue);
                    });
                };
            }
            void OnPlayerRemove(OPlayer entity, string key)
            {
                players[key].UnRegister();
            }
            void OnPlayerMove(OPlayer entity, string key)
            {
                //GameObject cube;
                //entities.TryGetValue(entity, out cube);
                Debug.Log(entity + "  " + key);
            }

            public void InitGame(GameMode gameMode, GameType gameType, int entrance, int maxClients, string diceName, string mapName)
            {
                switch (gameMode)
                {
                    case GameMode.Online:
                        OnlineInit(gameType,entrance, maxClients, diceName, mapName);
                        break;
                    case GameMode.Offline:
                        OfflineInit(entrance, maxClients, diceName, mapName);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}