using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Menchestan
{
    namespace NEWS
    {
        namespace NewsItems
        {
            public class NewsBox : MonoBehaviour
            {
                public VerticalLayoutGroup grid;
                public ScrollRect scrollRect;
                public List<FaqItem> newsItems;
            }
        }
    }
}