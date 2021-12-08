using DG.Tweening;
using UnityEngine;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
namespace Menchestan
{
    namespace Menu
    {
        namespace Motion
        {
            public class Transition : MenuMotion
            {
                public Vector3 outPoint;
                private Vector3 inPoint;
                public Ease inEase = Ease.Linear;
                public Ease outEase = Ease.Linear;
                private TweenerCore<Vector3, Vector3, VectorOptions> tweener;

                protected override void Init()
                {
                    inPoint = transform.localPosition;
                }
                protected override void Revert()
                {
                    DOTween.Kill(GetInstanceID());
                }
                protected override void InitInAction()
                {
                    gameObject.SetActive(true);
                    transform.localPosition = outPoint;
                }
                protected override void InAction()
                {
                    gameObject.SetActive(true);
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
