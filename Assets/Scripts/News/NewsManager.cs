using UnityEngine;
using Menchestan.IO;
using Menchestan.Server;
using Menchestan.Server.Model;

namespace Menchestan
{
    namespace NEWS
    {
        public class NewsManager
        {
            public NewsCollection news;
            private int sVersion;
            public bool isInit;
            private GenericCallback<UserSetModel> purchaseCallback;
            private bool initFromBuy;
            private bool upToDate => news.version >= sVersion;
            private static readonly string fileName = "news.txt";
            public void Initialize(int sVersion)
            {
                this.sVersion = sVersion;

                if (!isInit || !upToDate)
                {
                    isInit = true;
                    news = new NewsCollection();
                    if (DataIO.IsExist(fileName))
                    {
                        news = DataIO.FromJson<NewsCollection>(fileName);
                    }
                    else
                    {
                        var dataStr = Resources.Load<TextAsset>("Offline/news") as TextAsset;
                        news = JsonUtility.FromJson<NewsCollection>(dataStr.text);
                    }
                    UpdateNews();
                }
            }

            private void UpdateNews()
            {
                if (!upToDate)
                {
                    ServerKit.Instance.GetNews(news.version, (status, response, message, code) =>
                    {
                        if (status)
                        {
                            news.version = sVersion;
                            foreach (var item in response.items)
                            {
                                int index = news.items.FindIndex(i => i.key == item.key);
                                if (index == -1)
                                {
                                    news.items.Add(item);
                                }
                                else
                                {
                                    news.items[index] = item;
                                }
                            }
                            DataIO.ToJson(fileName, news);
                            isInit = false;
                            Initialize(sVersion);
                        }
                        else
                        {
                            //Do Nothing
                        }
                    });
                }
            }
        }
    }
}