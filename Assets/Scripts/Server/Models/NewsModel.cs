using System;
using System.Collections.Generic;
namespace Menchestan
{
    namespace Server
    {
        namespace Model
        {
            public enum NewsType
            {
                FAQ,
                Message,
                News
            }
            public enum ActionType
            {
                NONE,
                OpenURL
            }
            [Serializable]
            public class NewsAction
            {
                public ActionType type;
                public string actionData;
            }
            [Serializable]
            public class NewsModel
            {
                public NewsType type;
                public int key;
                public NewsAction action;
                public string date;
            }
            [Serializable]
            public class NewsCollection
            {
                public int version;
                public List<NewsModel> items;
            }
        }
    }
}