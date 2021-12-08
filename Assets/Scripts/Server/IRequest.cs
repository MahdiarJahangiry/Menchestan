using System;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.Networking;
using System.Collections.Generic;

namespace Menchestan
{
    namespace Server
    {
        public enum ResponseType
        {
            None,
            TimeOut,
            Client2Server,
            Server,
            Cast,
            Done
        }
        public abstract class IRequest
        {
            protected static int reqIndex = 0;
            public int id;
            public string ErrorMessage = "";
            public UnityWebRequest unitywebRequest;
            public bool forceRetry = true;
            public bool isVirtual = false;
            public AssetInfo assetInfo = null;
            public Stopwatch reqWatch = new Stopwatch();
            public Action<float> OnDownloadProgressChanged;
            public ResponseType responseType = ResponseType.None;
            public int timeOut;
            public AssetBundle loadedBundle;
            public Dictionary<string, object> parameters = new Dictionary<string, object>();
            public Dictionary<string, string> headers = new Dictionary<string, string>();
            public string url;
            public int BundleId;
            public RequestMethod reqMethod;
            public abstract void SetResponse();
            public abstract void RunCallback();
            public abstract void SetUnityWebRequest();
        }
    }
}