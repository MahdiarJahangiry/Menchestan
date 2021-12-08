using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using RTLTMPro;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Menchestan
{
    namespace Menu
    {
        namespace Motion
        {
            public class ColorMotion : MenuMotion
            {
                public Color outPoint;
                private Color inPoint;
                public Ease inEase = Ease.Linear;
                public Ease outEase = Ease.Linear;
                private Image image;
                private Text text;
                private RTLTextMeshPro rtlTextMeshPro;
                private TextMeshPro textMeshPro;
                private TweenerCore<Color, Color, ColorOptions> tweener;

                protected override void Init()
                {
                    image = GetComponent<Image>();
                    text = GetComponent<Text>();
                    textMeshPro = GetComponent<TextMeshPro>();
                    rtlTextMeshPro = GetComponent<RTLTextMeshPro>();

                    inPoint = image!= null ? image.color : Color.white;
                    inPoint = text != null ? text.color : Color.white;
                    inPoint = textMeshPro != null ? textMeshPro.color : Color.white;
                    inPoint = rtlTextMeshPro != null ? rtlTextMeshPro.color : Color.white;
                }
                protected override void Revert()
                {
                    DOTween.Kill(GetInstanceID());
                }
                protected override void InitInAction()
                {
                    gameObject.SetActive(true);
                    if (image != null)
                        image.color = outPoint;
                    else if (text != null)
                        text.color = outPoint;
                    else if (textMeshPro != null)
                        textMeshPro.color = outPoint;
                    else if (rtlTextMeshPro != null)
                        rtlTextMeshPro.color = outPoint;
                }
                protected override void InAction()
                {
                    gameObject.SetActive(true);
                    if (image != null)
                        tweener = image.DOColor(inPoint, duration).SetDelay(delay).OnComplete(() => { OnComplete?.Invoke(); }).SetTarget(GetInstanceID()).SetEase(inEase);
                    else if (text != null)
                        tweener = text.DOColor(inPoint, duration).SetDelay(delay).OnComplete(() => { OnComplete?.Invoke(); }).SetTarget(GetInstanceID()).SetEase(inEase);
                    else if (textMeshPro != null)
                        tweener = textMeshPro.DOColor(inPoint, duration).SetDelay(delay).OnComplete(() => { OnComplete?.Invoke(); }).SetTarget(GetInstanceID()).SetEase(inEase);
                    else if (rtlTextMeshPro != null)
                        tweener = rtlTextMeshPro.DOColor(inPoint, duration).SetDelay(delay).OnComplete(() => { OnComplete?.Invoke(); }).SetTarget(GetInstanceID()).SetEase(inEase);
                }
                protected override void OutAction()
                {
                    if (image != null)
                        tweener = image.DOColor(outPoint, duration).SetDelay(delay).OnComplete(() => { OnComplete?.Invoke(); }).SetTarget(GetInstanceID()).SetEase(outEase);
                    else if (text != null)
                        tweener = text.DOColor(outPoint, duration).SetDelay(delay).OnComplete(() => { OnComplete?.Invoke(); }).SetTarget(GetInstanceID()).SetEase(outEase);
                    else if (textMeshPro != null)
                        tweener = textMeshPro.DOColor(outPoint, duration).SetDelay(delay).OnComplete(() => { OnComplete?.Invoke(); }).SetTarget(GetInstanceID()).SetEase(outEase);
                    else if (rtlTextMeshPro != null)
                        tweener = rtlTextMeshPro.DOColor(outPoint, duration).SetDelay(delay).OnComplete(() => { OnComplete?.Invoke(); }).SetTarget(GetInstanceID()).SetEase(outEase);
                }
                protected override void InitOutAction()
                {
                    if (image != null)
                        image.color = inPoint;
                    else if (text != null)
                        text.color = inPoint;
                    else if (textMeshPro != null)
                        textMeshPro.color = inPoint;
                    else if (rtlTextMeshPro != null)
                        rtlTextMeshPro.color = inPoint;
                }
                private void OnDestroy()
                {
                    tweener?.Kill();
                }
            }
        }
    }
}
