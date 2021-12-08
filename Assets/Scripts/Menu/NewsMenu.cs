using System;
using UnityEngine;
using Menchestan.Server.Model;
using Menchestan.NEWS.NewsItems;
using System.Collections.Generic;
using Menchestan.Localization;

namespace Menchestan
{
    namespace Menu
    {
        public class NewsMenu : SimpleMenu<NewsMenu>
        {
            public List<FaqItem> newstemPrefabs;
            public List<NewsBox> newsTab;
            public Language initLanguage;
            public bool isInit;

            private int GetNewsTabIndex(NewsType type)
            {
                switch (type)
                {
                    case NewsType.FAQ:
                        return 0;
                    case NewsType.Message:
                        return 1;
                    case NewsType.News:
                        return 2;
                    default:
                        return -1;
                }
            }
            private void OnEnable()
            {
                if (!isInit || initLanguage != LocalizationManager.Instance.language)
                {
                    isInit = true;
                    initLanguage = LocalizationManager.Instance.language;
                    foreach (var tab in newsTab)
                    {
                        foreach (var item in tab.newsItems)
                        {
                            Destroy(item.gameObject);
                        }
                        tab.newsItems.Clear();
                    }
                    foreach (var item in GameManager.Instance.newsManager.news.items)
                    {
                        FaqItem newsItemPrefab = newstemPrefabs.Find(x => x.news.type == item.type);
                        if (newsItemPrefab != null)
                        {
                            int index = GetNewsTabIndex(newsItemPrefab.news.type);
                            FaqItem newsItem = Instantiate(newsItemPrefab, newsTab[index].grid.transform);
                            newsItem.newsBox = newsTab[index];
                            newsItem.news = item;
                            newsItem.name = item.type.ToString() + item.key.ToString();
                            newsItem.SetData();
                            newsItem.gameObject.SetActive(true);
                            newsTab[index].newsItems.Add(newsItem);
                        }
                        else
                        {
                            DebugX.Log("Can not find good item of type {0}.", item.type.ToString());
                        }
                    }
                }
            }
            public void ContactUs()
            {
                Application.OpenURL("mailto:support@gmail.com" + "?subject=Support Jomenchi");
            }
            void RateUs()
            {
                try
                {
                    AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
                    AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
                    AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
                    intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_EDIT"));
                    intentObject.Call<AndroidJavaObject>("setData", uriClass.CallStatic<AndroidJavaObject>("parse", "bazaar://details?id=com.tech.jomenchi"));
                    intentObject.Call<AndroidJavaObject>("setPackage", "com.farsitel.bazaar");
                    AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                    AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
                    currentActivity.Call("startActivity", intentObject);
                }
                catch (Exception)
                {
                    DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "CheckCafebazaar", "MsgCheckCafebazaar", () =>
                    {
                        DialogBoxMenu.Hide();
                    });
                }
            }
            public override void OnBackPressed()
            {
                Hide();
            }
        }
    }
}