using System;
using UnityEngine;
using Menchestan.GamePlay.Board;
using System.Collections.Generic;
using Menchestan.Audio;
using NativeWebSocket;

namespace Menchestan
{
    namespace GamePlay
    {
        namespace Player
        {
            [Serializable]
            public class MPlayer
            {
                private BrainType brain;
                private PieceType type;
                public GameController controller;
                public List<Piece> pieces = new List<Piece>();
                public List<StartPoint> teamMembers = new List<StartPoint>();
                public float rollTime;
                public float moveTime;
                public delegate bool IntDelegate(int step);
                public delegate void VoidDelegate();
                public delegate void Piece2InDelegate(Piece piece, Piece hitted);
                public delegate void PieceInDelegate(Piece piece);
                public delegate Piece PieceDelegate();
                public delegate void OnPlayerWin(WebSocketCloseCode finishCode, MPlayer player);
                public bool isBot;
                public bool isVir;
  public bool lost;
                public float botWaitTime;
                public readonly int enteranceNumber = 6;
                public string sessionId = "";
  public int piecesInSafePoint = 0;
                private int gemLifeCount;
                public bool isMoveAble => (controller.gameMode == GameMode.Offline && !isBot) || (controller.gameMode == GameMode.Online && controller.sessionId == controller.room.SessionId);

                public MPlayer(GameController gameController, string sessionId, StartPoint start, BrainType brainType, PieceType pieceType, int gemLife, string selectedPieceRing, string selectedPieceIcon, string selectedPieceGem, string nickName, bool isVir)
                {
                    this.isVir = true;
                    controller = gameController;
                    this.sessionId = sessionId;
                    gemLifeCount = Mathf.Max(start.gemLife.Count, gemLife);
                    foreach (var gem in start.gemLife)
                    {
                        gem.enabled = true;
                    }
                    type = pieceType;
                    brain = brainType;
                    isBot = brain != BrainType.Human;
                    SetBrian();
                    botWaitTime = 1.25f;
                    var r = Resources.Load<Piece>("Pieces/" + type.ToString());
                    teamMembers.Add(start);
                    if (string.IsNullOrEmpty(selectedPieceRing))
                        selectedPieceRing = "PieceRing000";
                    if (string.IsNullOrEmpty(selectedPieceIcon))
                        selectedPieceIcon = "PieceIcon000";
                    if (string.IsNullOrEmpty(selectedPieceGem))
                        selectedPieceGem = "PieceGem000";
                    if (string.IsNullOrEmpty(nickName))
                        nickName = sessionId;
                    int i = 0;
                    foreach (var piecePoint in start.piecePoints)
                    {
                        var newPiece = UnityEngine.Object.Instantiate(r, start.transform);
                        newPiece.ring.sprite = GameManager.Instance.iabManager.icons[selectedPieceRing];
                        newPiece.icon.sprite = GameManager.Instance.iabManager.icons[selectedPieceIcon];
                        foreach (var gem in newPiece.gems)
                        {
                            gem.sprite = GameManager.Instance.iabManager.icons[selectedPieceGem];
                        }
                        //newPiece.transform.localScale = 14 * Vector3.one;
                        newPiece.name = (++i).ToString();
                        newPiece.Register(this, piecePoint);
 if (gameController.gameType == GameType.Fast)
                        {
                            if (i == 5)
                            {
                                newPiece.wayPoint = piecePoint.nextPoint;
                                newPiece.onEntrance = true;
                            }

                        }
                        newPiece.OnStepStart += StepStarted;
                        newPiece.OnStepEnd += StepEnded;
                        newPiece.OnHitStart += HitStarted;
                        newPiece.OnHitEnd += HitEnded;
                        newPiece.OnMoveStart += MoveStarted;
                        newPiece.OnMoveEnd += MoveEnded;
                        pieces.Add(newPiece);
                    }
                    rollTime = 10;
                    moveTime = 10;
                    teamMembers[0].iconBack.transform.parent.gameObject.SetActive(true);
                    teamMembers[0].playerName.text = nickName;
                    teamMembers[0].ring.sprite = GameManager.Instance.iabManager.icons[selectedPieceRing];
                    teamMembers[0].icon.sprite = GameManager.Instance.iabManager.icons[selectedPieceIcon];
                }

                public void OnGrabTurnWithTime(float value)
                {
                    controller.board.timeBar.maxValue = value;
                    controller.board.fillBar.color = teamMembers[0].timeBarColor;
                }
                public void OnTimeChange(float value)
                {
                    controller.board.timeBar.value = value;
                }
                void SetBrian()
                {
                    switch (brain)
                    {
                        case BrainType.Human:
                            break;
                        case BrainType.AlphaBot:
                            ThinkEngine += AlphaBotBrian;
                            break;
                        case BrainType.BetaBot:
                            ThinkEngine += BetaBotBrian;
                            break;
                        case BrainType.GammaBot:
                            ThinkEngine += GammaBotBrian;
                            break;
                        default:
                            break;
                    }
                }

                private Piece AlphaBotBrian()
                {
                    throw new NotImplementedException();
                }
                private Piece BetaBotBrian()
                {
                    List<Piece> movablePieces = pieces.FindAll(x => x.isUnocked);
                    Piece mPiece = movablePieces[0];
                    foreach (Piece piece in movablePieces)
                    {
                        if (piece.deltaSafe > mPiece.deltaSafe)
                            mPiece = piece;
                    }
                    return mPiece;
                }
                private Piece GammaBotBrian()
                {
                    botWaitTime = 1.25f;

                    List<Piece> movablePieces = pieces.FindAll(x => x.isUnocked);
                    int index = UnityEngine.Random.Range(0, movablePieces.Count);
                    return movablePieces[index];
                }
                public float GetHitProbablity(WayPoint point)
                {
                    float p = 0;
                    //int startIndex = controller.players.IndexOf(this);
                    //for (int i = startIndex; i < controller.players.Count + startIndex; i++)
                    //{
                    //    string playerplayerSessionId = "Player" + (i % controller.players.Count);
                    //    if (teamMembers.Contains(controller.players[playerplayerSessionId].teamMembers[0]))
                    //        continue;
                    //    p += controller.players[playerplayerSessionId].HitThePieceProbablity(point, p);
                    //}
                    return p;
                }
                //احتمال اینکه این بازیکن مهره ای که در خانه قرار گزفته است را بزند
                private float HitThePieceProbablity(WayPoint point, float prevProbablity)
                {
                    float p = 0.0f;
                    foreach (var piece in pieces)
                    {
                        int distance = piece.GetDistanceTo(point);
                        int step = (distance / 6) + 1;
                        p += (1.0f - prevProbablity) / Mathf.Pow(enteranceNumber, step);
                    }
                    return p;
                }
                public event PieceDelegate ThinkEngine;
                public Piece Think()
                {
                    return ThinkEngine?.Invoke();
                }
                public Piece GetPieceById(int id)
                {
                    return pieces.Find(x => x.name == id.ToString());
                }
                public Piece GetPieceById(string id)
                {
                    return pieces.Find(x => x.name == id);
                }
                public event IntDelegate OnUnlock;
                public bool UnLocked(int step)
                {
                    bool haveMove = false;
                    OnUnlock?.Invoke(step);
                    foreach (var piece in pieces)
                    {
                        haveMove |= piece.isUnocked;
                    }
                    if (isBot && haveMove)
                        Think()?.Invoke("Move", 1.25f);
                    return haveMove;
                }
                public event VoidDelegate OnLock;
                public void Locked()
                {
                    OnLock?.Invoke();
                }
                public event Piece2InDelegate OnMoveStart;
                public void MoveStarted(Piece piece, Piece hitted)
                {
                    OnMoveStart?.Invoke(piece, hitted);
                }
                public event PieceInDelegate OnMoveEnd;
                public void MoveEnded(Piece piece)
                {
                    OnMoveEnd?.Invoke(piece);
                }

                public void TurnPassed()
                {
                    controller.dice.SetEffect(default);
                }

                public void OnTurnRecived()
                {
                    AudioManager.Instance.PlayAudio(Audio.AudioType.SFX_HumanTurn);
                    if (isMoveAble)
                        controller.dice.SetEffect(teamMembers[0].startPointColor);
                }
                public event VoidDelegate OnReachSafePoint;
                public bool ReachSafePoint()
                {
                    bool isWin = true;
                    foreach (var item in teamMembers[0].endPoint.endSafePoints)
                    {
                        if (item.piece == null)
                        {
                            isWin = false;
                            break;
                        }
                    }
                    if (isWin)
                    {
                        OnGameFinished(WebSocketCloseCode.Normal, this);
                    }
                    else
                    {
                        piecesInSafePoint++;
                        OnReachSafePoint?.Invoke();
                    }
                    return isWin;
                }
                public void StepStarted()
                {
                }
                public void StepEnded()
                {
                }
                public void HitStarted()
                {
                }
                public void HitEnded()
                {
                }
                public void LostDiceTime()
                {
                    GemGrabber();
                }
                public void LostMoveTime()
                {
                    GemGrabber();
                }
                private void GemGrabber()
                {
                    controller.virCount -= 1;
                    gemLifeCount--;
                    teamMembers[0].gemLife[gemLifeCount].enabled = false;
                    if (gemLifeCount == 0)
                    {
                        UnRegister();
                    }
                }
                public event OnPlayerWin OnGameFinish;
                public void OnGameFinished(WebSocketCloseCode finishCode, MPlayer player)
                {
                    OnGameFinish?.Invoke(finishCode, player);
                }
                public void UnRegister()
                {
                    for (int i = pieces.Count - 1; i >= 0; i--)
                    {
                        pieces[i].UnRegister();
                    }
                     lost = true;
                    controller.PlayerUnRegistered(sessionId);
                }
            }
        }
    }
}