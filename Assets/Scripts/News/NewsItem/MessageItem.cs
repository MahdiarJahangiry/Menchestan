using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Menchestan.Localization;
using Menchestan.Server.Model;

namespace Menchestan
{
    namespace NEWS
    {
        namespace NewsItems
        {
            public class MessageItem : FaqItem
            {
                public Localize date;
                public Button actionButton;
                private bool hasData;
                public override void SetData()
                {
                    base.SetData();
                    date.SetKey(news.date);
                    hasData = news.action != null && news.action.type != ActionType.NONE;
                    actionButton.gameObject.SetActive(hasData);
                    if (hasData)
                    {
                        switch (news.action.type)
                        {
                            case ActionType.OpenURL:
                                actionButton.onClick.AddListener(() => Application.OpenURL(news.action.actionData));
                                break;
                            default:
                                break;
                        }
                    }
                }
                public override void OnShowDetail()
                {
                    messageBox.DOSizeDelta(new Vector2(820, 144 + (isOpen ? 0 : 1) * 45 * ((hasData ? 3 : 0) + 1 + message.GetNumberOfLines())), 0.25f);
                    arrow.DOLocalRotate((isOpen ? 0 : -1) * 90 * Vector3.forward, 0.25f);
                    actionButton.GetComponent<RectTransform>().localPosition = (isOpen ? 1 : -1) * 64 * Vector3.up;
                    isOpen = !isOpen;
                }
            }
        }
    }
}