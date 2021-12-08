using System;
using UnityEngine;
using System.Collections.Generic;
namespace Menchestan
{
    namespace Server
    {
        public class AssetBundleController : MonoSingleton<AssetBundleController>
        {
            private bool isInit;
            private int hostIndex;
            public bool clearCache;
            private List<string> hostList;
            private string AssetBundleUrl;
            public List<AssetInfo> assetBundleList;

            private void Start()
            {
                GetHosts();
            }
            public void GetHosts()
            {
                if (clearCache)
                    Caching.ClearCache();
                ServerKit.Instance.GetFile<List<string>>(ServerKit.Instance.AssetBundleHostsUrl, OnHostLoaded, null, true, false, true);
            }

            private void OnHostLoaded(bool status, List<string> response, string message, int code)
            {
                if (status)
                {
                    hostList = response;
                }
                else
                {
                    hostList.Add("http://176.9.235.219");
                }
                GetAssetInfo(null);
            }
            public void GetAssetInfo(Action<bool> action)
            {
                AssetBundleUrl = hostList[hostIndex] + "/" + Application.version + "/" + Application.platform;
                ServerKit.Instance.GetFile<List<AssetInfo>>(AssetBundleUrl + "/BundlesInfo.txt", (status, response, message, code) =>
                {
                    isInit = status;

                    if (status)
                    {
                        assetBundleList = response;
                    }
                    else
                    {
                        hostIndex = ++hostIndex % hostList.Count;
                    }
                    action?.Invoke(status);
                }
                , null, true, false, true);
            }
            public string GetBundleURL(AssetInfo assetInfo)
            {
                if (IsLocal(assetInfo))
                {
                    string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "LocalBundles");
                    filePath = System.IO.Path.Combine(filePath, assetInfo.name);
                    return filePath;
                }
                else
                {
                    return AssetBundleUrl + "/" + assetInfo.name;
                }
            }
            public void Load(Action<float> onProgressChanged, Action<bool> callback, params BundleAction[] bundleActions)
            {
                if (isInit)
                {
                    string assetUrl = "";
                    RequestBundle assetReqBundle = new RequestBundle();
                    foreach (var bundleAction in bundleActions)
                    {
                        Hash128 hash = Hash128.Parse(bundleAction.info.hash);
                        assetUrl = GetBundleURL(bundleAction.info);
                        assetReqBundle.Put(ServerKit.Instance.GetFile<AssetBundle>(assetUrl, (status, bundle, message, code) =>
                        {
                            bundleAction.callBack?.Invoke(status, bundleAction.info, bundle);
                        }, bundleAction.info, isVirtual: true, autoFire: false));
                    }
                    if (callback != null)
                    {
                        assetReqBundle.callback = (status, rb) => { callback(status); };
                    }
                    if (onProgressChanged != null)
                    {
                        assetReqBundle.OnProgressChanged = onProgressChanged;
                    }
                    ServerKit.Instance.SendBatchRequest(assetReqBundle);
                }
                else
                {
                    GetAssetInfo((stat) =>
                    {
                        if (stat)
                        {
                            Load(onProgressChanged, callback, bundleActions);
                        }
                        else
                        {
                            callback(false);
                        }
                    });
                }
            }
            public bool IsLocal(AssetInfo assetInfo)
            {
                return assetInfo.Id == 0;
            }
        }
    }
}
