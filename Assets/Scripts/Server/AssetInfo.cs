using System;
using UnityEngine;
namespace Menchestan
{
    namespace Server
    {
        [Serializable]
        public class AssetInfo
        {
            [SerializeField]
            public string name;
            [SerializeField]
            public string hash;
            [SerializeField]
            public string crc;
            [SerializeField]
            public string ver;
            [SerializeField]
            public int Id;
        }
    }
}