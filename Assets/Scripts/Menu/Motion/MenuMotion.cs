using System;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;
namespace Menchestan
{
    namespace Menu
    {
        namespace Motion
        {
            public enum MotionType
            {
                In,
                Out,
                InOut
            }
            public enum ExecutionOrderType
            {
                OnChildStart,
                OnChildComplete
            }
            public class MotionData
            {
                public bool isOnAction;
                public bool state;
                public int allAction;
                public Action onCompleted;
            }
            
            public abstract class MenuMotion : MonoBehaviour
            {
                private int motionId;
                private static int counterId;
                private static Dictionary<int, MotionData> notCompletedInAllAction = new Dictionary<int, MotionData>();

                public bool motionState;
                public MotionType motionType = MotionType.InOut;
                public ExecutionOrderType orderType = ExecutionOrderType.OnChildStart;
                public float delay;
                public float duration;

                private int numInAction;
                private int numOutAction;
                private int notCompletedAction;
                protected abstract void Revert();
                protected abstract void InitInAction();
                protected abstract void InAction();
                protected abstract void InitOutAction();
                protected abstract void OutAction();
                private Action OnRevertAction;
                private Action<int> OnInAction;
                private Action<int> OnOutAction;
                private Func<int> GetAllInChildNumber;
                private Func<int> GetAllOutChildNumber;
                private bool isDone;
                public Action OnComplete;
                private bool isInit;
                private void Awake()
                {
                    if (!isInit)
                    {
                        isInit = true;
                        OnComplete += OnChildActionCompleted;
                        GetChild(transform);
                        GetAllInChildNumber += () => numInAction;
                        GetAllOutChildNumber += () => numOutAction;
                        Init();
                    }
                }

                protected abstract void Init();
                private void GetChild(Transform parent)
                {
                    for (int ID = 0; ID < parent.childCount; ID++)
                    {
                        Transform child = parent.GetChild(ID);
                        MenuMotion[] menuMotionsInChild = child.GetComponents<MenuMotion>();
                        if (menuMotionsInChild.Length > 0)
                        {
                            bool isAttached = false;
                            foreach (MenuMotion menuMotion in menuMotionsInChild)
                            {
                                if (menuMotion.motionType == motionType || menuMotion.motionType == MotionType.InOut)
                                {
                                    isAttached = true;
                                    //if (orderType == ExecutionOrderType.OnChildComplete)
                                    OnRevertAction += menuMotion.OnRevertAction;
                                    GetAllInChildNumber += menuMotion.AllInChildNumber;
                                    GetAllOutChildNumber += menuMotion.AllOutChildNumber;
                                    menuMotion.OnComplete += OnChildActionCompleted;
                                }
                                if (menuMotion.motionType == MotionType.In || menuMotion.motionType == MotionType.InOut)
                                {
                                    numInAction++;
                                    OnInAction += menuMotion.RunInActions;
                                }
                                if (menuMotion.motionType == MotionType.Out || menuMotion.motionType == MotionType.InOut)
                                {
                                    numOutAction++;
                                    OnOutAction += menuMotion.RunOutActions;
                                }
                            }
                            if (!isAttached)
                            {
                                GetChild(child);
                            }
                        }
                        else
                        {
                            GetChild(child);
                        }
                    }
                }
                [Button]
                public void RunAction(Action onComplete)
                {
                    if (!notCompletedInAllAction.ContainsKey(motionId))
                    {
                        motionId = ++counterId;
                        notCompletedInAllAction[motionId] = new MotionData
                        {
                            state = motionState,
                            onCompleted = onComplete
                        };

                    }
                    if (notCompletedInAllAction[motionId].isOnAction)
                    {
                        notCompletedInAllAction[motionId].onCompleted = null;
                        OnRevertAction?.Invoke();
                        notCompletedInAllAction[motionId].state = !notCompletedInAllAction[motionId].state;
                    }
                    notCompletedInAllAction[motionId].onCompleted = onComplete;
                    //return;
                    notCompletedInAllAction[motionId].isOnAction = true;
                    if (motionType == MotionType.In)
                    {
                        notCompletedInAllAction[motionId].allAction = AllInChildNumber();
                        RunInActions(motionId);
                    }
                    else if (motionType == MotionType.Out)
                    {
                        notCompletedInAllAction[motionId].allAction = AllOutChildNumber();
                        RunOutActions(motionId);
                    }
                    else if (motionType == MotionType.InOut)
                    {
                        if (notCompletedInAllAction[motionId].state)
                        {
                            notCompletedInAllAction[motionId].allAction = AllInChildNumber();
                            RunInActions(motionId);
                        }
                        else
                        {
                            notCompletedInAllAction[motionId].allAction = AllOutChildNumber();
                            RunOutActions(motionId);
                        }
                    }
                }
                private void RunInActions(int id)
                {
                    motionId = id;
                    isDone = false;
                    if (motionType == MotionType.In || motionType == MotionType.InOut)
                    {
                        notCompletedAction = numInAction;
                        InitInAction();
                        InActionProxy();
                    }
                    OnInAction?.Invoke(motionId);
                }
                private void RunOutActions(int id)
                {
                    motionId = id;
                    isDone = false;
                    if (motionType == MotionType.Out || motionType == MotionType.InOut)
                    {
                        notCompletedAction = numOutAction;
                        InitOutAction();
                        OutActionProxy();
                    }
                    OnOutAction?.Invoke(motionId);
                }
                private void OutActionProxy()
                {
                    if (((notCompletedAction == 0) && (orderType == ExecutionOrderType.OnChildComplete)) || (orderType == ExecutionOrderType.OnChildStart))
                    {
                        OutAction();
                    }
                }
                private void InActionProxy()
                {
                    if (((notCompletedAction == 0) && (orderType == ExecutionOrderType.OnChildComplete)) || (orderType == ExecutionOrderType.OnChildStart))
                    {
                        InAction();
                    }
                }
                private int AllInChildNumber()
                {
                    int inActionNumber = 0;
                    foreach (var item in GetAllInChildNumber.GetInvocationList())
                    {
                        inActionNumber += (int)item.DynamicInvoke();
                    }
                    return inActionNumber;
                }
                private int AllOutChildNumber()
                {
                    int outActionNumber = 0;
                    foreach (var item in GetAllOutChildNumber.GetInvocationList())
                    {
                        outActionNumber += (int)item.DynamicInvoke();
                    }
                    return outActionNumber;
                }
                private void CheckIsOver()
                {
                    isDone = true;
                    notCompletedInAllAction[motionId].allAction--;
                    if (notCompletedInAllAction[motionId].allAction == -1)
                    {
                        notCompletedInAllAction[motionId].state = !notCompletedInAllAction[motionId].state;
                        notCompletedInAllAction[motionId].onCompleted?.Invoke();
                        notCompletedInAllAction[motionId].isOnAction = false;
                        //notCompletedInAllAction[motionId].onCompleted = null;
                    }
                }
                private void OnChildActionCompleted()
                {
                    notCompletedAction--;
                    //Debug.Log(" Name " + name + "  >>  ID" + motionId);
                    if (orderType == ExecutionOrderType.OnChildComplete)
                    {
                        if (notCompletedAction == 0)
                        {
                            switch (motionType)
                            {
                                case MotionType.In:
                                    InActionProxy();
                                    break;
                                case MotionType.Out:
                                    OutActionProxy();
                                    break;
                                case MotionType.InOut:
                                    if (notCompletedInAllAction[motionId].state)
                                    {
                                        InActionProxy();
                                    }
                                    else
                                    {
                                        OutActionProxy();
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        else if (notCompletedAction == -1)
                        {
                            CheckIsOver();
                        }
                    }
                    else if (orderType == ExecutionOrderType.OnChildStart)
                    {
                        if (!isDone)
                        {
                            CheckIsOver();
                        }
                    }
                }
            }
        }
    }
}