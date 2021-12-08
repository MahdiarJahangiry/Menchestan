using UnityEngine;
using UnityEngine.UI;
using Menchestan.Localization;
using System.Collections.Generic;

namespace Menchestan
{
    namespace Menu
    {
        public class HelpMenu : SimpleMenu<HelpMenu>
        {
            public Toggle prefabPage;
            public ToggleGroup toggleGroup;
            public List<Toggle> pages = new List<Toggle>();
            public List<Sprite> pictures;
            public Image pagePicture;
            public Localize pageContent;
            bool isInit;
            int pageIndex = 0;
            int Mod(int a, int b)
            {
                return (a % b + b) % b;
            }
            private void OnEnable()
            {
                if (!isInit)
                {
                    isInit = true;
                    foreach (var page in pictures)
                    {
                        Toggle newPage = Instantiate(prefabPage, toggleGroup.transform);
                        newPage.group = toggleGroup;
                        int i = pages.Count;
                        newPage.onValueChanged.AddListener((status) => { if (status) OnTogglePressed(i); });
                        pages.Add(newPage);
                    }
                }
                SelectPage();
            }
            private void OnTogglePressed(int index)
            {
                pageIndex = index % pages.Count;
                SelectPage();
            }
            private void SelectPage()
            {
                pages[pageIndex].isOn = true;
                pagePicture.sprite = pictures[pageIndex];
                pageContent.SetKey(pictures[pageIndex].name);
            }
            public void OnNextPressed()
            {
                pageIndex = ++pageIndex % pages.Count;
                SelectPage();
            }
            public void OnPreviousPressed()
            {
                pageIndex = Mod(--pageIndex, pages.Count);
                SelectPage();
            }
            public override void OnBackPressed()
            {
                Hide();
            }
        }
    }
}