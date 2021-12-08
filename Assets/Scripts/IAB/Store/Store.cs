using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Menchestan
{
    namespace IAB
    {
        namespace IABItems
        {
            public class Store : MonoBehaviour
            {
                public GridLayoutGroup grid;
                public ScrollRect scrollRect;
                public List<GoodItem> goodItems;
                public GoodItem selected;
                public virtual void OnSelect(object data)
                {
                }
            }
        }
    }
}