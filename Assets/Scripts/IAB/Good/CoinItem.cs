using UnityEngine.UI;
using Menchestan.Localization;
using System.Collections.Generic;

namespace Menchestan
{
    namespace IAB
    {
        namespace IABItems
        {
            public class CoinItem : GoodItem
            {
                public Image icon;
                public Localize value;
                public Localize price;

                public override void SetData()
                {
                    base.SetData();
                    if (GameManager.Instance.iabManager.icons.ContainsKey(good.icon))
                    {
                        icon.sprite = GameManager.Instance.iabManager.icons[good.icon];
                    }
                    value.formatValues = new List<string>
                    {
                        good.value.ToString()
                    };
                    price.formatValues = new List<string>
                    {
                        good.price.ToString()
                    };
                }
            }
        }
    }
}