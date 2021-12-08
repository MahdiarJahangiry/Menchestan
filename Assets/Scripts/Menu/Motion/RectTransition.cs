using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
namespace Menchestan
{
    namespace Menu
    {
        namespace Motion
        {
            [RequireComponent(typeof(RectTransform))]
            public class RectTransition : MenuMotion
            {
                public Vector2 inDefault;
                public Vector2 outPoint;
                private Vector2 inPoint;
                private RectTransform rectTransform;
                public Ease inEase = Ease.OutCubic;
                public Ease outEase = Ease.InCubic;
                private TweenerCore<Vector3, Vector3, VectorOptions> tweener;

                protected override void Init()
                {
                    rectTransform = GetComponent<RectTransform>();
                    if (inDefault == Vector2.zero)
                        inPoint = transform.localPosition;
                    else
                        inPoint = inDefault;
                }
                protected override void Revert()
                {
                    DOTween.Kill(GetInstanceID());
                }
                protected override void InitInAction()
                {
                    transform.localPosition = outPoint;
                }
                protected override void InAction()
                {
                    tweener = transform.DOLocalMove(inPoint, duration).SetDelay(delay).OnComplete(() => { OnComplete?.Invoke(); }).SetTarget(GetInstanceID()).SetEase(inEase);
                }
                protected override void OutAction()
                {
                    tweener = transform.DOLocalMove(outPoint, duration).SetDelay(delay).OnComplete(() => { OnComplete?.Invoke(); }).SetTarget(GetInstanceID()).SetEase(outEase);
                }
                protected override void InitOutAction()
                {
                    transform.localPosition = inPoint;
                }
                private void OnDestroy()
                {
                    tweener?.Kill();
                }
            }
        }
    }
}