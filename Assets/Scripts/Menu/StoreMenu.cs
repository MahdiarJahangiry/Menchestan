using Menchestan.IAB.IABItems;
using Menchestan.Server.Model;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Menchestan
{
    namespace Menu
    {
        public class StoreMenu : SimpleMenu<StoreMenu>
        {
            public List<GoodItem> goodItemPrefabs;
            public List<Store> storeTeb;
            public List<Toggle> tabs;

            public bool isInit;
            private int GetStoreTabIndex(GoodType type)
            {
                switch (type)
                {
                    case GoodType.Coin:
                        return 0;
                    case GoodType.Dice:
                        return 1;
                    case GoodType.PieceRing:
                        return 2;
                    case GoodType.PieceIcon:
                        return 3;
                    case GoodType.PieceGem:
                        return 4;
                    case GoodType.FortuneWheel:
                    case GoodType.Video:
                    default:
                        return -1;
                }
            }
            public void ShowTab(int index)
            {
                if (index < storeTeb.Count)
                    tabs[index].isOn = true;
            }
            private void OnEnable()
            {
                if (!isInit)
                {
                    isInit = true;
                    foreach (var item in GameManager.Instance.iabManager.goods.items)
                    {
                        GoodItem goodItemPrefab = goodItemPrefabs.Find(x => x.good.gtype == item.gtype);
                        if (goodItemPrefab != null)
                        {
                            int index = GetStoreTabIndex(goodItemPrefab.good.gtype);
                            GoodItem goodItem = Instantiate(goodItemPrefab, storeTeb[index].grid.transform);
                            goodItem.store = storeTeb[index];
                            goodItem.good = item;
                            goodItem.name = item.key;
                            goodItem.SetData();
                            goodItem.gameObject.SetActive(true);
                            storeTeb[index].goodItems.Add(goodItem);
                        }
                    }
                }
            }
            public void OnPieceDecoratePressed()
            {
                foreach (var tab in storeTeb)
                {
                    if (tab.GetType() == typeof(PieceStore))
                    {
                        ((PieceStore)tab).OnEnable();
                    }
                }
            }
            public override void OnBackPressed()
            {
                Hide();
            }
        }
    }
}