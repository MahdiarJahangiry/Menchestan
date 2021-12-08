using TMPro;
using UnityEngine;
using Menchestan.Menu.Motion;
namespace Menchestan
{
    namespace Menu
    {
        namespace HUD
        {
            public class CountDown : MonoBehaviour
            {
                public int iterateFrom;
                public int iterateTo;
                private RectScaleMotion rectScaleMotion;
                public TextMeshPro textMexhPro;
                public BWEffect bWEffect;
                private int iterate;
                private int sign;
                public bool goToColor;
                private float stepToColor;
                public bool canIterate = true;
                public void Start()
                {
                    stepToColor = ((goToColor ? -1.0f : 1.0f) / Mathf.Abs(iterateTo - iterateFrom));
                    iterate = iterateFrom;
                    sign = iterateTo > iterateFrom ? 1 : -1;
                    bWEffect = Camera.main.gameObject.AddComponent<BWEffect>();
                    bWEffect.intensity = goToColor ? 1 : 0;
                    textMexhPro.text = iterate.ToString();
                    rectScaleMotion = GetComponent<RectScaleMotion>();
                    rectScaleMotion.RunAction(OnMotionComplete);
                }
                public void OnMotionComplete()
                {
                    iterate += sign;
                    if (canIterate)
                    {
                        bWEffect.intensity += stepToColor;
                        textMexhPro.text = iterate.ToString();
                        rectScaleMotion.RunAction(OnMotionComplete);
                        if (iterate == iterateTo)
                            canIterate = false;
                    }
                    else
                    {
                        Destroy(bWEffect);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
