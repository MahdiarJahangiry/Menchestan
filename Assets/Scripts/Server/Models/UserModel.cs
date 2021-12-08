using System;
using System.Collections.Generic;
namespace Menchestan
{
    namespace Server
    {
        namespace Model
        {
            [Serializable]
            public class DeviceData
            {
                public string id = null;
                public string platform = null;
            }
            [Serializable]
            public class UserModel
            {
                public string token = null;
                public string _id = null;
                public string username = null;
                public int level = 0;
                public int winCont = 0;
                public List<string> dices = null;
                public string selectedDice;
                public List<string> pieceRings = null;
                public string selectedPieceRing;
                public List<string> pieceIcons = null;
                public string selectedPieceIcon;
                public List<string> pieceGems = null;
                public string selectedPieceGem;

                public int coin = 0;
                [NonSerialized]
                public Action<int, int> CoinChanged;
                public void OncoinChanged(int oldValue, int newValue)
                {
                    CoinChanged?.Invoke(oldValue, newValue);
                }
                public int loseCont = 0;
                public string displayName = null;
                public string avatarUrl = null;

                public bool isAnonymous = true;
                public string email = null;

                public string lang = null;
                public string location = null;
                public string timezone = null;
                public object metadata = null;

                public List<DeviceData> devices = null;

                public string facebookId = null;
                public string twitterId = null;
                public string googleId = null;
                public string gameCenterId = null;
                public string steamId = null;

                public List<string> friendIds = null;
                public List<string> blockedUserIds = null;

                public DateTime createdAt = DateTime.MinValue;
                public DateTime updatedAt = DateTime.MinValue;
            }
            [Serializable]
            public class UserCollection
            {
                public List<UserModel> items;
            }
            [Serializable]
            public class UserSetModel
            {
                public bool status;
                public UserModel userData;
                public List<string> parameterName;
            }
        }
    }
}