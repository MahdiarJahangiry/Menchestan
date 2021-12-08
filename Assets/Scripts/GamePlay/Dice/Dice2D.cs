using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Menchestan
{
    namespace GamePlay
    {
        namespace Dice
        {
            public class Dice2D : MDice
            {
 public Animator anim;
                private Image hurt;
                private DiceSide2D[] diceSides;
                protected override void OnInit()
                {
                    hurt = GetComponent<Image>();
                    diceSides = gameObject.GetComponentsInChildren<DiceSide2D>();
                    anim = GetComponent<Animator>();
                    if (string.IsNullOrEmpty(GameManager.Instance.user.selectedDice))
                        hurt.sprite = GameManager.Instance.iabManager.icons["dice001"];
                    else
                        hurt.sprite = GameManager.Instance.iabManager.icons[GameManager.Instance.user.selectedDice];
                    hurt.color = bodyColor;
                    foreach (var side in diceSides)
                    {
                        side.OnAwake();
                        side.dot.color = dotColor;
                    }
                }
                // If you left click over the dice then RollTheDice coroutine is started
                public override void Roll(int value)
                {
                    if (!thrown)
                    {
                        anim.SetBool("Play", true);
                        foreach (DiceSide2D v in diceSides)
                        {
                            v.gameObject.SetActive(false);
                        }
                        StartCoroutine(RollTheDice(value));
                    }
                }
                private void OnMouseDown()
                {
                    OnRollRequested(-1);
                }
                // Coroutine that rolls the dice
                private IEnumerator RollTheDice(int value)
                {
                   
                    thrown = true;
                    Debug.Log("dice pre value " + value);
                   
                    int randomDiceSide = 0;

                    //    yield return new WaitForSeconds(0.05f);
                    yield return new WaitForSeconds(1.0f);

                    // Assigning final side so you can use this value later in your game
                    // for player movement for example



                           randomDiceSide = Random.Range(0, 6);
                    if (value != -1)
                         randomDiceSide = value;
                    else
                        randomDiceSide = Random.Range(0, 6) + 1;

                    value = randomDiceSide;
                    Debug.Log("Selected value " + value);
                    anim.SetBool("Play", false);
                    ShowSide(value);


                    thrown = false;
                    OnDiceRolled(value);
                }
                private void SetSide(int value)
                {
                    foreach (DiceSide2D v in diceSides)
                    {
                        v.gameObject.SetActive(false);
                    }
                    for (int j = 0; j <= value; j++)
                    {
                        diceSides[j].transform.localPosition = diceSides[value].positions[j];
                    }
                    for (int j = 0; j <= value; j++)
                    {
                        diceSides[j].gameObject.SetActive(true);
                    }
                }
                public override void ShowSide(int value)
                {
                    SetSide(value - 1);
                }
                public override void Stop()
                {
                    if (thrown)
                        isStop = true;
                }
            }
        }
    }
}