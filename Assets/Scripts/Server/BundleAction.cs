using System;
using UnityEngine;
namespace Menchestan
{
    namespace Server
    {
        public class BundleAction
        {
            public AssetInfo info;
            public Action<bool, AssetInfo, AssetBundle> callBack;
            public BundleAction(AssetInfo info, Action<bool, AssetInfo, AssetBundle> callBack = null)
            {
                this.info = info;
                this.callBack = callBack;
            }
        }
    }
}
