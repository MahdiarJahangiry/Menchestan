using System;
using System.Collections.Generic;

namespace Menchestan
{
    namespace Server
    {
        namespace Model
        {
            public enum GoodType
            {
                Coin,
                Dice,
                PieceRing,
                PieceIcon,
                PieceGem,
                FortuneWheel,
                Video
            }
            [Serializable]
            public class GoodModel
            {
                public GoodType gtype;
                public string key;
                public int price;
                public int value;
                public string icon;
                public bool ismarket;
                public bool ptype;
            }
            [Serializable]
            public class GoodCollection
            {
                public int version;
                public List<GoodModel> items;
            }
        }
    }
}
