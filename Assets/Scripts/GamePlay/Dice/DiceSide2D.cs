using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
namespace Menchestan
{
    namespace GamePlay
    {
        namespace Dice
        {
            public class DiceSide2D : MonoBehaviour, IDiceSide
            {
                // Array of dice sides sprites to load from Resources folder
                public Image dot;
                public List<Vector3> positions;

                public void OnAwake()
                {
                    if (dot == null)
                        dot = GetComponent<Image>();
                }
            }
        }
    }
}