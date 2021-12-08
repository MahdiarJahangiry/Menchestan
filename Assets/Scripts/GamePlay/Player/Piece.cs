﻿using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Menchestan.Audio;
using Menchestan.GamePlay.Board;
using System.Collections.Generic;

namespace Menchestan
{
    namespace GamePlay
    {
        namespace Player
        {
            [Serializable]
            public class Piece : MonoBehaviour
            {
                public PieceType type;
                public WayPoint wayPoint;
                private MPlayer mPlayer;
                private int moveStep;
                private BoxCollider colider;
                private bool canHit;
                private PiecePoint piecePoint;
                public float deltaSafe;
                public string sessionId = "";
                public int stepWeight;
                public Image iconBack;
                public Image icon;
                public Image ring;
                public List<Image> gems;
                public ParticleSystem auraEffect;
                public bool isUnocked => moveStep > 0;
                public bool onEntrance;
                private float moveSpeed = 0.1f;
                public delegate void OnVoidPiece();
                public delegate void On2PieceInPiece(Piece piece, Piece hitted);
                public delegate void OnPieceInPiece(Piece piece);
                Color selectionColor;
                public void Register(MPlayer player, PiecePoint _piecePoint)
                {
                    mPlayer = player;
                    sessionId = mPlayer.sessionId;
                    piecePoint = _piecePoint;
                    wayPoint = _piecePoint;
                    transform.position = _piecePoint.transform.position;
if (mPlayer.controller.gameType == GameType.Fast)
                    {
                        moveSpeed /= 4;
                    }
                    //Material pieceModel = GetComponent<Renderer>()?.material;
                    //if(pieceModel != null)
                    //pieceModel.color = mPlayer.teamMembers[0].startPointColor;
                    //else
                    //{
                    //}

                    Color.RGBToHSV(mPlayer.teamMembers[0].startPointColor, out float H, out float S, out float V);
                    selectionColor = Color.HSVToRGB(H, 2 * S, 3 * V);
                    if (auraEffect != null)
                    {
                        ParticleSystem.MainModule main = auraEffect.main;
                        main.startColor = new ParticleSystem.MinMaxGradient(mPlayer.teamMembers[0].startPointColor);
                    }
                    iconBack.color = mPlayer.teamMembers[0].startPointColor;
                    Canvas canvas = gameObject.AddComponent<Canvas>();
                    canvas.overrideSorting = true;
                    canvas.sortingOrder = 2;
                    mPlayer.OnLock += Locked;
                    mPlayer.OnUnlock += UnLocked;
                    if (colider == null)
                        colider = GetComponent<BoxCollider>();
                    if (!mPlayer.isBot)
                        OnMoveRequest += Move;
                }
                public event OnVoidPiece OnStepStart;
                private void StepStarted()
                {
                    if (onEntrance)
                        AudioManager.Instance.PlayInstanciateAudio(Audio.AudioType.SFX_PieceEntrance);
                    else
                        AudioManager.Instance.PlayInstanciateAudio(Audio.AudioType.SFX_PieceStep);
                    OnStepStart?.Invoke();
                    onEntrance = false;
                }
                public event OnVoidPiece OnStepEnd;
                private void StepEnded()
                {
                    OnStepEnd?.Invoke();
                }
                public event OnVoidPiece OnHitStart;
                private void HitStarted()
                {
                    AudioManager.Instance.PlayInstanciateAudio(Audio.AudioType.SFX_PieceHit);
                    OnHitStart?.Invoke();
                }
                public event OnVoidPiece OnHitEnd;
                private void HitEnded()
                {
                    OnHitEnd?.Invoke();
                }
                public event On2PieceInPiece OnMoveStart;
                private void MoveStarted(Piece piece, Piece hitted)
                {
                    Locked();
                    OnMoveStart?.Invoke(piece, hitted);
                }
                public event OnPieceInPiece OnMoveEnd;
                private void MoveEnded(Piece piece)
                {
                    canHit = false;
                    OnMoveEnd?.Invoke(piece);
                }
                private bool UnLocked(int step)
                {
                    canHit = false;
                    moveStep = ValidSteps(step);
                    if (moveStep > 0)
                    {
                        //transform.DOScale(1.1f, 0.2f);
                        //image.DOColor(selectionColor, 0.2f);
                        if (mPlayer.isMoveAble)
                        {
                            if (auraEffect != null)
                            {
                                auraEffect.gameObject.SetActive(true);
                            }

                            colider.enabled = true;
                        }
                        return true;
                    }
                    else
                    {
                        Locked();
                        return false;
                    }
                }
                public event OnVoidPiece OnMoveRequest;
                protected void OnMoveRequested()
                {
                    OnMoveRequest?.Invoke();
                }
                private void OnMouseDown()
                {
                    OnMoveRequested();
                }
                private void Locked()
                {
                    canHit = false;
                    colider.enabled = false;
                    if (auraEffect != null)
                    {
                        auraEffect.gameObject.SetActive(false);
                    }
                    //transform.DOScale(1, 0.2f);
                    //image.DOColor(mPlayer.teamMembers[0].startPointColor, 0.2f);
                }
                private int ValidSteps(int step)
                {
                    if (step != mPlayer.enteranceNumber && wayPoint.type == PointType.PiecePoint)
                    {
                        CheckWeight(null);
                        return 0;
                    }
                    else
                    {
                        if (step == mPlayer.enteranceNumber && wayPoint.type == PointType.PiecePoint)
                        {
                            onEntrance = true;
                            step = 1;
                        }
                        WayPoint movePoint = wayPoint;
                        for (int i = 0; i < step; i++)
                        {
                            movePoint = movePoint.GetNextWayPoint(piecePoint.startPoint);
                            if (movePoint == null)
                            {
                                CheckWeight(null);
                                return 0;
                            }
                        }
                        if (movePoint.piece != null)
                        {
                            if (mPlayer.teamMembers.Contains(movePoint.piece.piecePoint.startPoint) || (movePoint.type== PointType.StartPoint && movePoint.piece.mPlayer.teamMembers[0] == movePoint))
                            {
                                Debug.Log("Point is Full");
                                CheckWeight(null);
                                return 0;
                            }
                            else
                            {
                                canHit = true;
                                Debug.Log("Beat 'em up!");
                                CheckWeight(movePoint);
                                return step;
                            }
                        }
                        else
                        {
                            CheckWeight(movePoint);
                            return step;
                        }
                    }
                }
                private void CheckWeight(WayPoint movedPoint)
                {
                    float beforeMovedWeight = 0, afterMovedWeight = 0;
                    if (mPlayer.isBot && movedPoint != null)
                    {
                        beforeMovedWeight = mPlayer.GetHitProbablity(wayPoint);
                        afterMovedWeight = mPlayer.GetHitProbablity(movedPoint);
                    }
                    deltaSafe = beforeMovedWeight - afterMovedWeight;
                }
                public int GetDistanceFrom(WayPoint from, StartPoint startPoint)
                {
                    return from.Distance(wayPoint, startPoint);
                }
                public int GetDistanceTo(WayPoint to)
                {
                    return wayPoint.Distance(to, piecePoint.startPoint);
                }
                private void Move()
                {
                    Piece hitted = null;
                    wayPoint.piece = null;
                    Sequence tween = DOTween.Sequence();
                    stepWeight += moveStep;
                    if (wayPoint.type == PointType.PiecePoint)
                        stepWeight += mPlayer.enteranceNumber * (mPlayer.enteranceNumber + 1) / 2 - 1;
                    for (int i = 0; i < moveStep; i++)
                    {
                        WayPoint nextPoint = wayPoint.GetNextWayPoint(piecePoint.startPoint);

                        tween.Append(transform.DOMove((wayPoint.transform.position + nextPoint.transform.position) / 2 + 0.2f * Vector3.up, moveSpeed).OnStart(() =>
                        {
                            StepStarted();
                        }));
                        tween.Append(transform.DOMove(nextPoint.transform.position, moveSpeed).OnComplete(() =>
                        {
                            StepEnded();
                        }));
                        wayPoint = nextPoint;
                    }
                    if (canHit)
                    {
                        canHit = false;
                        tween.Append(wayPoint.piece.transform.DOMove((wayPoint.piece.transform.position + wayPoint.piece.piecePoint.transform.position) / 2 + 0.2f * Vector3.up, moveSpeed).OnStart(() =>
                        {
                            HitStarted();
                        }));
                        tween.Append(wayPoint.piece.transform.DOMove(wayPoint.piece.piecePoint.transform.position, moveSpeed).OnComplete(() =>
                        {
                            HitEnded();
                        }));
                        wayPoint.piece.stepWeight = 0;
                        wayPoint.piece.wayPoint = wayPoint.piece.piecePoint;
                        wayPoint.piece.piecePoint.piece = wayPoint.piece;
                        hitted = wayPoint.piece;
                    }
                    wayPoint.piece = this;
                    moveStep = 0;
if (mPlayer.controller.gameType == GameType.Fast)
                    {
                        if (hitted != null)
                            hitted.UnRegister();

                    }
                    MoveStarted(this, hitted);
                    tween.Play().OnComplete(() =>
                    {
                        if (wayPoint.type == PointType.EndSafePoint)
                        {
                            mPlayer.ReachSafePoint();
                        }
                        MoveEnded(this);
                    });
                }

                public void UnRegister()
                {
                    mPlayer.OnLock -= Locked;
                    mPlayer.OnUnlock -= UnLocked;
                    wayPoint = null;
                    mPlayer.pieces.Remove(this);
                    Destroy(gameObject);
                }

                public void Set(short seat)
                {
                    WayPoint point = seat == -1 ? piecePoint : mPlayer.teamMembers[0].GetNthPoint(mPlayer.teamMembers[0], seat);
                    if (point != null)
                    {
                        wayPoint.piece = null;
                        point.piece = this;
                        wayPoint = point;
                        transform.position = wayPoint.transform.position;
                    }
                    else
                    {
                        Debug.unityLogger.Log("Error! Point not found!");
                    }
                }
            }
        }
    }
}