using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Menchestan.Server.Model;
using Menchestan.Localization;

namespace Menchestan
{
    namespace NEWS
    {
        namespace NewsItems
        {
            public class FaqItem : MonoBehaviour
            {
                public NewsModel news;
                public NewsBox newsBox;
                public Button button;
                public RectTransform messageBox;
                public RectTransform arrow;
                public Localize message;
                public Localize title;
                public bool isOpen;
                public virtual void SetData()
                {
                    string localizeKey = news.type.ToString() + news.key.ToString("000");
                    title.GetComponent<RTLTMPro.RTLTextMeshPro>().horizontalAlignment = LocalizationManager.Instance.isRTL ? TMPro.HorizontalAlignmentOptions.Right : TMPro.HorizontalAlignmentOptions.Left;
                     
                    title.SetKey("Title" + localizeKey);
                    message.SetKey("Message" + localizeKey);
                    message.GetComponent<RTLTMPro.RTLTextMeshPro>().horizontalAlignment = LocalizationManager.Instance.isRTL ? TMPro.HorizontalAlignmentOptions.Right : TMPro.HorizontalAlignmentOptions.Left;
                }
                public virtual void OnShowDetail()
                {
                    messageBox.DOSizeDelta(new Vector2(820, 96 + (isOpen ? 0 : 1) * 45 * (1 + message.GetNumberOfLines())), 0.25f);
                    arrow.DOLocalRotate((isOpen ? 0 : -1) * 90 * Vector3.forward, 0.25f);
                    isOpen = !isOpen;
                }
            }
        }
    }
}