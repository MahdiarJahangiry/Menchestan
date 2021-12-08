using UnityEngine;
namespace Menchestan
{
    namespace GamePlay
    {
        namespace Dice
        {
            public enum DiceType
            {
                TwoD,
                ThreeD
            }
            public abstract class MDice : MonoBehaviour
            {
                public delegate void OnDiceRoll(int value);
                public delegate void OnVoidDice();
                protected Color dotColor;
                protected Color bodyColor;
                protected bool thrown;
                protected bool hasLanded;
                protected int value;
                protected Vector3 initPosition;
                protected bool isStop = false;
                public ParticleSystem hallowEffect;
                private Vector3 colorMin;
                private Vector3 colorMax;
                public void SetEffect(Color color)
                {
                    if (hallowEffect != null)
                    {
                        if (color == default)
                        {
                            hallowEffect.gameObject.SetActive(false);
                        }
                        else
                        {
                            Color.RGBToHSV(color, out float H, out float S, out float V);
                            var main = hallowEffect.main;
                            Color min = Color.HSVToRGB(H, colorMin.y, colorMin.z);
                            min.a = main.startColor.colorMin.a;
                            Color max = Color.HSVToRGB(H, colorMin.y, colorMin.z);
                            max.a = main.startColor.colorMax.a;
                            main.startColor = new ParticleSystem.MinMaxGradient(min, max);
                            hallowEffect.gameObject.SetActive(true);
                        }
                    }
                }
                public void Init(Vector3 initPos, Color bColor, Color dColor)
                {
                    bodyColor = bColor;
                    dotColor = dColor;
                    initPosition = initPos;
                    transform.localPosition = initPosition;
                    if (hallowEffect != null)
                    {
                        Color.RGBToHSV(hallowEffect.main.startColor.colorMin, out float minH, out float minS, out float minV);
                        colorMin = new Vector3(minH, minS, minV);
                        Color.RGBToHSV(hallowEffect.main.startColor.colorMax, out float maxH, out float maxS, out float maxV);
                        colorMax = new Vector3(maxH, maxS, maxV);
                    }
                    OnInit();
                }
                protected abstract void OnInit();
                public abstract void Roll(int value);
                public event OnDiceRoll OnRolled;
                protected void OnDiceRolled(int value)
                {
                    OnRolled?.Invoke(value);
                }
                public event OnDiceRoll OnRollRequest;
                protected void OnRollRequested(int value)
                {
                    OnRollRequest?.Invoke(value);
                }
                public abstract void Stop();
                public abstract void ShowSide(int value);
            }
        }
    }
}
