using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menchestan
{
    namespace GamePlay
    {
        namespace Board
        {
            public class Timer : MonoBehaviour
            {
                public Text timerTxt;
                public int steps = 300;
                public delegate void TimerCallBack();
                public static event TimerCallBack timeEnd;

                Animator anim;

                private int timerCounter;

                public void StartTimer()
                {
                    anim = GetComponent<Animator>();
                    timerCounter = steps;
                    ShowTime();
                    InvokeRepeating("TimerCount", 1, 1);
                }

                private void TimerCount()
                {
                    timerCounter--;

                    ShowTime();

                    if (timerCounter < 10 && timerCounter > 0)
                        anim.SetBool("Show", true);
                    if (timerCounter <= 0)
                    {
                        anim.SetBool("Show", false);
                        CancelInvoke("TimerCount");
                        timeEnd?.Invoke();
                    }
                }

                private void ShowTime()
                {
                    int m = timerCounter / 60;
                    int s = timerCounter % 60;

                    timerTxt.text = string.Format("{0}:{1:00}", m, s);
                }

            }
        }
    }
}