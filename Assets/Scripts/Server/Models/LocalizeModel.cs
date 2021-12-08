using System;
using System.Collections.Generic;
namespace Menchestan
{
    namespace Server
    {
        namespace Model
        {
            [Serializable]
            public class LocalizeModel
            {
                public string key;
                public List<string> value;
            }
            [Serializable]
            public class LocalizeCollection
            {
                public int version;
                public List<LocalizeModel> items;
            }
        }
    }
}