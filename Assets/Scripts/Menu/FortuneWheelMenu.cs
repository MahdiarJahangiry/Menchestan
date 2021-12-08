using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Menchestan.IAB.IABItems;
using System.Collections.Generic;
using Menchestan.Server.Model;
using Menchestan.Localization;

namespace Menchestan
{
    namespace Menu
    {
        public enum ArrangementType
        {
            None,
            Free,
            Coin,
            Video,
            Random
        }
        public class FortuneWheelMenu : SimpleMenu<FortuneWheelMenu>
        {
            public FortuneWheelItem fortuneWheelPrefab;
            public List<FortuneWheelItem> fortuneWheelItems = new List<FortuneWheelItem>();
            public GameObject indicator;
            public Button spin;
            public Localize spinTitle;
            public Image wheel;
            public int fakeSpin;
            public float duration;
            private GoodModel videoFreeSpinGood;
            private readonly int fortuneCount = 8;
            private float stepDegree;
            private Material mat;
            private int index = 0;
            private bool onSpin;
            private float emission = 1;
            private readonly float maxGlow = 1.4f;
            private ArrangementType wheelType = ArrangementType.None;
            private readonly string videoFreeSpinKey = "freespinvideo";

            private void OnEnable()
            {
                if (videoFreeSpinGood == null)
                    videoFreeSpinGood = GameManager.Instance.iabManager.goods.items.Find(g => g.key == videoFreeSpinKey);
                stepDegree = 360.0f / fortuneCount;
                if (SetBoardType())
                    ResetBoard();

                mat = wheel.materialForRendering;
                mat.SetFloat("_Glow", maxGlow);
                InvokeRepeating("BeforeSpin", 0, 0.1f);
            }
            private void ClearBoard()
            {
                wheel.transform.localRotation = Quaternion.Euler(Vector3.zero);
                foreach (var item in fortuneWheelItems)
                {
                    Destroy(item.gameObject);
                }
                fortuneWheelItems.Clear();
            }
            private bool SetBoardType()
            {
                ArrangementType oldWheelType = wheelType;
                if (GameManager.Instance.remainingFreeFortuneWheel > 0)
                {
                    wheelType = ArrangementType.Free;
                }
                else
                {
                    if (GameManager.Instance.user.coin < videoFreeSpinGood.value)
                    {
                        wheelType = ArrangementType.Video;
                    }
                    else
                    {
                        wheelType = ArrangementType.Coin;
                    }
                }
                return (oldWheelType != wheelType);
            }
            private void ResetBoard()
            {
                ClearBoard();
                List<GoodModel> fortuneGoodItems = new List<GoodModel>();
                if (wheelType == ArrangementType.Free || wheelType == ArrangementType.Video)
                {
                    if (wheelType == ArrangementType.Free)
                    {
                        spinTitle.SetKey("SpinFree");
                    }
                    else
                    {
                        spinTitle.SetKey("SpinVideo");
                    }
                    fortuneGoodItems = GameManager.Instance.iabManager.goods.items.FindAll(g => g.gtype == GoodType.FortuneWheel && g.value < 700);
                }
                else if (wheelType == ArrangementType.Coin)
                {
                    spinTitle.SetKey("SpinCoin", new List<string>() { videoFreeSpinGood.value.ToString() });
                    fortuneGoodItems = GameManager.Instance.iabManager.goods.items.FindAll(g => g.gtype == GoodType.FortuneWheel && g.value >= 700);
                }
                else
                {
                    spinTitle.SetKey("SpinFree");
                    for (int index = 0; index < fortuneCount; index++)
                    {
                        int c = UnityEngine.Random.Range(0, GameManager.Instance.iabManager.goods.items.Count);
                        fortuneGoodItems.Add(GameManager.Instance.iabManager.goods.items[c]);
                    }
                }
                int itemCount = Mathf.Min(fortuneCount, fortuneGoodItems.Count);
                for (int i = 0; i < itemCount; i++)
                {
                    FortuneWheelItem goodItem = Instantiate(fortuneWheelPrefab, wheel.transform.position, Quaternion.Euler(new Vector3(0, 0, stepDegree * i)), wheel.transform);
                    goodItem.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, stepDegree * i));
                    goodItem.good = fortuneGoodItems[i];
                    goodItem.name = fortuneGoodItems[i].key;
                    goodItem.SetData();
                    goodItem.gameObject.SetActive(true);
                    fortuneWheelItems.Add(goodItem);
                }
            }
            private void OnDisable()
            {
                onSpin = false;
                CancelInvoke("BeforeSpin");
            }
            private void BeforeSpin()
            {
                mat.SetInt("_GlowIndex", ++index % fortuneCount);
            }
            private void Update()
            {
                if (onSpin)
                    mat.SetFloat("_Glow", emission);
            }
            public void OnSpinPressed()
            {
                switch (wheelType)
                {
                    case ArrangementType.None:
                        break;
                    case ArrangementType.Random:
                    case ArrangementType.Free:
                        PlayerPrefs.SetInt("FortuneWheelTicket", --GameManager.Instance.remainingFreeFortuneWheel);
                        SpinWheel();
                        break;
                    case ArrangementType.Coin:
                        GameManager.Instance.iabManager.PurchaseByServer(videoFreeSpinGood, null, OnGoodSpinByCoin, null);
                        break;
                    case ArrangementType.Video:
                        spin.interactable = false;
                        GameManager.Instance.videoAdManager.RequestVideoAdd("5f5fdb49b081620001cc876d", true, VideoReward);
                        break;
                    default:
                        break;
                }

            }
            private void VideoReward(bool status, string message)
            {
                if (status)
                {
                    SpinWheel();
                }
                else
                {
                    spin.interactable = true;
                    DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "Error", message);
                }
            }
            private void OnGoodSpinByCoin(bool status, UserSetModel response, string message, int code)
            {
                if (status)
                {
                    SpinWheel();
                }
                else
                {
                    DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "Error", "ConnectionError");
                }
            }

            private void SpinWheel()
            {
                onSpin = true;
                spin.interactable = false;
                mat.SetFloat("_Glow", 1);
                CancelInvoke("BeforeSpin");
                int random = UnityEngine.Random.Range(0, fortuneCount);
                float s = UnityEngine.Random.Range(0, stepDegree);
                Sequence tween = DOTween.Sequence();
                tween.Append(wheel.transform.DOLocalRotate(new Vector3(0, 0, fakeSpin * 360 - random * stepDegree - s), duration, RotateMode.FastBeyond360));
                if (s >= stepDegree / 2.0f)
                {
                    random = ++random % fortuneCount;
                    s = stepDegree - s;
                }
                Debug.Log(random);
                tween.Append(wheel.transform.DOLocalRotate(new Vector3(0, 0, -random * stepDegree), 1).SetDelay(.1f).SetEase(Ease.OutBounce).OnComplete(() =>
                {
                    mat.SetInt("_GlowIndex", random);
                }));
                tween.Append(DOTween.To(() => emission, x => emission = x, maxGlow, 0.25f).SetEase(Ease.Flash).SetLoops(6, LoopType.Yoyo));
                tween.Append(DOTween.To(() => emission, x => emission = x, emission, 1).OnComplete(() =>
                {
                    GameManager.Instance.iabManager.PurchaseByServer(fortuneWheelItems[random].good, null, OnWinGood, null);
                }));
                tween.Play();
            }

            private void OnWinGood(bool status, UserSetModel response, string message, int code)
            {
                if (!status)
                {
                    PlayerPrefs.SetInt("FortuneWheelTicket", ++GameManager.Instance.remainingFreeFortuneWheel);
                    DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "Error", "ConnectionError");
                }
                spin.interactable = true;
                onSpin = false;
                if (SetBoardType())
                    ResetBoard();

                mat.SetFloat("_Glow", maxGlow);
                InvokeRepeating("BeforeSpin", 0, 0.1f);
            }

            public override void OnBackPressed()
            {
                if (!onSpin)
                    Hide();
            }
        }
    }
}