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
            public class RectScaleMotion : MenuMotion
            {
                public Vector3 outPoint;
                private Vector3 inPoint;
                private RectTransform rectTransform;
                public Ease inEase = Ease.OutCubic;
                public Ease outEase = Ease.InCubic;
                private TweenerCore<Vector3, Vector3, VectorOptions> tweener;

                protected override void Init()
                {
                    rectTransform = GetComponent<RectTransform>();
                    inPoint = rectTransform.localScale;
                }
                protected override void Revert()
                {
                    DOTween.Kill(GetInstanceID());
                }
                protected override void InitInAction()
                {
                    rectTransform.localScale = outPoint;
                }
                protected override void InAction()
                {
                    tweener = rectTransform.DOScale(inPoint, duration).SetDelay(delay).OnComplete(() => { OnComplete?.Invoke(); }).SetTarget(GetInstanceID()).SetEase(inEase);
                }
                protected override void OutAction()
                {
                    tweener = rectTransform.DOScale(outPoint, duration).SetDelay(delay).OnComplete(() => { OnComplete?.Invoke(); }).SetTarget(GetInstanceID()).SetEase(outEase);
                }
                protected override void InitOutAction()
                {
                    rectTransform.localScale = inPoint;
                }
                private void OnDestroy()
                {
                    tweener?.Kill();
                }
            }
        }
    }
}