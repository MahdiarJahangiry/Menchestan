using Menchestan.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menchestan
{
    namespace IAB
    {
        namespace IABItems
        {
            public class FortuneWheelItem : GoodItem
            {
                public Image icon;
                public Localize value;
                public override void SetData()
                {
                    if (GameManager.Instance.iabManager.icons.ContainsKey(good.icon))
                    {
                        icon.sprite = GameManager.Instance.iabManager.icons[good.icon];
                        if (good.icon == "coinpack000")
                        {
                            icon.rectTransform.sizeDelta = new Vector2(330, 330);
                        }
                        else if (good.icon == "coinpack001")
                        {
                            icon.rectTransform.sizeDelta = new Vector2(330, 330);
                        }
                        else if (good.icon == "coinpack002")
                        {
                            icon.rectTransform.sizeDelta = new Vector2(330, 330);
                        }
                        else if (good.icon == "coinpack003")
                        {
                            icon.rectTransform.sizeDelta = new Vector2(256, 256);
                        }
                        else if (good.icon == "coinpack004")
                        {
                            icon.rectTransform.sizeDelta = new Vector2(190, 190);
                        }
                        else if (good.icon == "coinpack005")
                        {
                            icon.rectTransform.sizeDelta = new Vector2(175, 175);
                        }
                    }
                    value.formatValues = new List<string>
                    {
                        good.value.ToString()
                    };
                    value.SetKey("PlusPrice");
                }
            }
        }
    }
}