using UnityEngine;
namespace Menchestan
{
    namespace GamePlay
    {
        namespace Dice
        {
            public class DiceSide3D : MonoBehaviour, IDiceSide
            {
                public bool onGround;
                public int sideValue;
                void OnTriggerStay(Collider col)
                {
                    if (col.tag == "Ground")
                    {
                        onGround = true;
                    }
                }
                private void OnTriggerExit(Collider col)
                {
                    if (col.tag == "Ground")
                    {
                        onGround = false;
                    }
                }
                public bool OnGround()
                {
                    return onGround;
                }

                public void OnAwake()
                {
                }
            }
        }
    }
}
