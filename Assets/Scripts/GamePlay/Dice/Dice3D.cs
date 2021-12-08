using UnityEngine;
namespace Menchestan
{
    namespace GamePlay
    {
        namespace Dice
        {
            public class Dice3D : MDice
            {
                private Rigidbody hurt;
                private DiceSide3D[] diceSides;
                private Material[] materials;
                protected override void OnInit()
                {
                    hurt = GetComponent<Rigidbody>();
                    hurt.maxAngularVelocity = 25;
                    hurt.useGravity = false;
                    diceSides = gameObject.GetComponentsInChildren<DiceSide3D>();
                    materials = GetComponent<Renderer>().materials;
                    materials[0].color = dotColor;
                    materials[1].color = bodyColor;
                }
                private void OnMouseDown()
                {
                    OnRollRequested(-1);
                }
                // Update is called once per frame
                void Update()
                {
                    if (hurt.IsSleeping() && !hasLanded && thrown)
                    {
                        hasLanded = true;
                        hurt.useGravity = false;
                        SideValueCheck();
                    }
                    else if (hurt.IsSleeping() && hasLanded && value == 0)
                    {
                        RollAgain();
                    }
                }
                public override void Roll(int value)
                {
                    if (isStop)
                    {
                        Resets();
                    }
                    else
                    {
                        if (!thrown && !hasLanded)
                        {
                            int minForce = Random.Range(0, 250);
                            int maxForce = Random.Range(300, 800);
                            thrown = true;
                            hurt.useGravity = true;
                            hurt.velocity = Vector3.zero;
                            hurt.angularVelocity = Vector3.zero;
                            hurt.AddForce(Vector3.up * 200);
                            hurt.AddTorque(Random.Range(minForce, maxForce), Random.Range(minForce, maxForce), Random.Range(minForce, maxForce));
                        }
                        else if (thrown && hasLanded)
                        {
                            RollAgain();
                        }
                    }
                }
                private void Resets()
                {
                    value = 0;
                    thrown = false;
                    hasLanded = false;
                    isStop = false;
                    hurt.useGravity = false;
                    transform.position = initPosition;
                    transform.rotation = Random.rotationUniform;
                }
                private void RollAgain()
                {
                    Resets();
                    Roll(-1);
                }
                private void SideValueCheck()
                {
                    value = 0;
                    foreach (var side in diceSides)
                    {
                        if (side.OnGround())
                        {
                            value = side.sideValue;
                            OnDiceRolled(value);
                        }
                    }
                }

                public override void ShowSide(int value)
                {
                    throw new System.NotImplementedException();
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