using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Menchestan
{
    namespace IAB
    {
        namespace IABItems
        {
            public class PieceStore : Store
            {
                public Button leftButton;
                public Button rightButton;
                public List<Image> pieceImages;
                private float scrollviewCenterPosition;
                float step;
                public void OnEnable()
                {
                    step = 1.0f / (scrollRect.content.childCount - 1);
                    if (selected == null)
                        return;
                    int index = goodItems.FindIndex(g => g == selected);
                    if (index != -1)
                        scrollRect.horizontalNormalizedPosition = index * step;
                    else
                        scrollRect.horizontalNormalizedPosition = 0;
                    OnScrollValueChanged();
                }
                private void Start()
                {
                    OnEnable();
                }
                public void OnScrollValueChanged()
                {
                    scrollviewCenterPosition = scrollRect.content.localPosition.x;
                    foreach (var item in goodItems)
                    {
                        float distanceFromCenter = item.transform.localPosition.x + scrollviewCenterPosition;
                        float normalizedDistanceFromCenter = Mathf.Abs(distanceFromCenter / (scrollRect.GetComponent<RectTransform>().rect.width * 0.5f));
                        if (normalizedDistanceFromCenter > 1)
                            item.transform.localScale = Vector3.one * 0.75f;
                        else
                            item.transform.localScale = Vector3.one * (0.75f + 0.4f * (1 - normalizedDistanceFromCenter));
                        if (item.transform.localScale.x > 1.05f)
                        {
                            if (item.good.gtype == Server.Model.GoodType.PieceRing)
                                OnSelect(((PieceRingItem)item).icon.sprite);
                            else if (item.good.gtype == Server.Model.GoodType.PieceGem)
                                OnSelect(((PieceGemItem)item).icon0.sprite);
                            else if (item.good.gtype == Server.Model.GoodType.PieceIcon)
                                OnSelect(((PieceIconItem)item).icon.sprite);
                        }
                    }

                    if (scrollRect.horizontalNormalizedPosition <= 0)
                        leftButton.interactable = false;
                    if (scrollRect.horizontalNormalizedPosition > 0)
                        leftButton.interactable = true;
                    if (scrollRect.horizontalNormalizedPosition >= 1)
                        rightButton.interactable = false;
                    if (scrollRect.horizontalNormalizedPosition < 1)
                        rightButton.interactable = true;
                }
                public void OnLeftPressed()
                {
                    scrollRect.horizontalNormalizedPosition -= step;
                }
                public void OnRightPressed()
                {
                    scrollRect.horizontalNormalizedPosition += step;
                }
                public override void OnSelect(object data)
                {
                    foreach (var item in pieceImages)
                    {
                        item.sprite = (Sprite)data;
                    }
                }
            }
        }
    }
}