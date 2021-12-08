using System;
using System.Web;
using UnityEngine;
using System.Collections.Generic;
using Menchestan.Server.Model;
using System.Collections.Specialized;
using UnityEngine.Networking;
using System.Collections;
using System.Reflection;
using Menchestan.IAB;

namespace Menchestan
{
    namespace Server
    {
        public delegate void GenericCallback<T>(bool status, T response, string message, int code);
        public class ServerKit : MonoSingleton<ServerKit>
        {
            public bool isDebug;
            public string BaseUrl;
            public string AssetBundleHostsUrl;
            public Dictionary<string, string> serverHeaders = new Dictionary<string, string>();

            static int BundleId;
            public static DateTime LastServerTime;
            static List<RequestBundle> BundleRequests = new List<RequestBundle>();
            public List<string> assetBundlesOnDownloadPool = new List<string>();
            public Dictionary<string, AssetBundle> assetBundles = new Dictionary<string, AssetBundle>();

            public void UnloadAllBundle(bool unloadAllLoadedObjects)
            {
                foreach (var hash in assetBundles.Keys)
                {
                    assetBundles[hash].Unload(unloadAllLoadedObjects);
                }
                assetBundles.Clear();
            }
            public void UnloadBundle(AssetInfo assetInfo, bool unloadAllLoadedObjects)
            {
                if (assetBundles.ContainsKey(assetInfo.hash))
                    assetBundles[assetInfo.hash].Unload(unloadAllLoadedObjects);
                assetBundles.Remove(assetInfo.hash);
            }
            public void SendBatchRequest(RequestBundle bundleRequest)
            {
                BundleRequests.Add(bundleRequest);
                BundleRequests[BundleRequests.Count - 1].id = BundleId;
                int reqCount = BundleRequests[BundleRequests.Count - 1].requests.Count;
                bundleRequest.bundleWatch.Start();
                for (int i = 0; i < reqCount; i++)
                {
                    BundleRequests[BundleRequests.Count - 1].requests[i].BundleId = BundleId;
                    // check that is this a new request or is intuptes in last call. 
                    // In new request "responseType = ResponseType.None"
                    if (BundleRequests[BundleRequests.Count - 1].requests[i].responseType != ResponseType.None)
                    {
                        // When a request successfully done then "responseType = ResponseType.Done"
                        // else request is intrupted. so if the forceRetry = ture then only this request in the bundle fired
                        if (BundleRequests[BundleRequests.Count - 1].requests[i].responseType != ResponseType.Done && BundleRequests[BundleRequests.Count - 1].requests[i].forceRetry)
                        {
                            BundleRequests[BundleRequests.Count - 1].requests[i].SetUnityWebRequest();
                            StartCoroutine(HttpRequest(bundleRequest.requests[i]));
                        }
                    }
                    else
                    {
                        StartCoroutine(HttpRequest(bundleRequest.requests[i]));
                    }
                }
                BundleId++;
            }
            void OnResponse(IRequest response)
            {
                int bundleIndex = BundleRequests.FindIndex(x => x.id == response.BundleId);
                if (bundleIndex >= 0)
                {
                    // Check that all request in this bundle responsed
                    //All request in bundle answered and this is answer of last request

                    if (BundleRequests[bundleIndex].activeReqCount == 1)
                    {
                        // Check that all response of the requests in this bundle successfully doned
                        foreach (IRequest request in BundleRequests[bundleIndex].requests)
                        {
                            request.SetResponse();
                            if (request.responseType != ResponseType.Done && request.forceRetry == true)
                            {
                                BundleRequests[bundleIndex].resStaus = false;
                                break;
                            }
                        }
                        BundleRequests[bundleIndex].bundleWatch.Stop();
                        DebugX.Log("Bundle Request {0} Overall Time: {1}", bundleIndex, BundleRequests[bundleIndex].bundleWatch.ElapsedMilliseconds / 1000.0f);
                        if (BundleRequests[bundleIndex].resStaus)
                        {
                            foreach (IRequest request in BundleRequests[bundleIndex].requests)
                            {
                                request.RunCallback();
                                request.unitywebRequest.Dispose();
                            }
                            if (BundleRequests[bundleIndex].ChildReqBundle.activeReqCount == 0)
                            {
                                RequestBundle tmpRBC = BundleRequests[bundleIndex];
                                //Recusively call all childs main callback until there is no parent([parent == null] equal [tmpRBC.Requests.Count == 0])

                                while (tmpRBC.requests.Count != 0)
                                {
                                    tmpRBC.callback?.Invoke(tmpRBC.resStaus, tmpRBC);
                                    int rbcIndex = BundleRequests.FindIndex(x => x.id == tmpRBC.requests[0].BundleId);
                                    tmpRBC = BundleRequests[rbcIndex].Parent;
                                    BundleRequests.RemoveAt(rbcIndex);
                                }
                            }
                            else
                            {
                                Instance.SendBatchRequest(BundleRequests[bundleIndex].ChildReqBundle);
                            }
                        }
                        else
                        {
                            BundleRequests[bundleIndex].callback?.Invoke(BundleRequests[bundleIndex].resStaus, BundleRequests[bundleIndex]);
                            BundleRequests.RemoveAt(bundleIndex);
                        }
                    }
                    else
                    {
                        BundleRequests[bundleIndex].activeReqCount--;
                    }
                }
            }

            IEnumerator HttpRequest(IRequest request)
            {
                float deltaProgressValue = 0.0f;
                float currentValue = 0.0f;

                if (request.assetInfo != null)
                {
                    while (!Caching.ready || assetBundlesOnDownloadPool.Contains(request.assetInfo.hash))
                    {
                        yield return new WaitForSeconds(0.05f);
                    }
                    assetBundlesOnDownloadPool.Add(request.assetInfo.hash);
                    if (assetBundles.ContainsKey(request.assetInfo.hash))
                    {
                        request.OnDownloadProgressChanged?.Invoke(1.0f - currentValue);
                        request.loadedBundle = assetBundles[request.assetInfo.hash];
                        assetBundlesOnDownloadPool.Remove(request.assetInfo.hash);
                        OnResponse(request);
                        yield break;
                    }
                    else if (AssetBundleController.Instance.IsLocal(request.assetInfo))
                    {
                        request.OnDownloadProgressChanged?.Invoke(1.0f - currentValue);
                        request.loadedBundle = AssetBundle.LoadFromFile(request.url);
                        assetBundles.Add(request.assetInfo.hash, request.loadedBundle);
                        assetBundlesOnDownloadPool.Remove(request.assetInfo.hash);
                        OnResponse(request);
                        yield break;
                    }
                    if (Caching.IsVersionCached(request.url, Hash128.Parse(request.assetInfo.hash)))
                        DebugX.Log("Cached");
                }

                //using (request.request)
                {
                    request.reqWatch.Start();
                    request.unitywebRequest.SendWebRequest();
                    while (!request.unitywebRequest.isDone)
                    {
                        if (request.reqWatch.ElapsedMilliseconds / 1000 > request.timeOut)
                        {
                            DebugX.Warning("Request {0} Aborted", request.id);
                            request.responseType = ResponseType.TimeOut;
                            request.unitywebRequest.Abort();
                            break;
                        }
                        deltaProgressValue = currentValue;
                        currentValue = request.unitywebRequest.downloadProgress;
                        request.OnDownloadProgressChanged?.Invoke(currentValue - deltaProgressValue);
                        yield return new WaitForSeconds(0.05f);
                    }
                    string size = request.unitywebRequest.GetResponseHeader("Content-Length");
                    request.reqWatch.Stop();
                    request.OnDownloadProgressChanged?.Invoke(1.0f - currentValue);
                    DebugX.Log("request {0} >> {1}  << size >>  {2} << request.reqElapsedMilliseconds >> {3} <<< request.timeOut >>> {4}", request.id, request.url, size, request.reqWatch.ElapsedMilliseconds, request.timeOut);
                    if (request.assetInfo != null)
                    {
                        if (Caching.IsVersionCached(request.url, Hash128.Parse(request.assetInfo.hash)))
                        {
                            assetBundles.Add(request.assetInfo.hash, DownloadHandlerAssetBundle.GetContent(request.unitywebRequest));
                        }
                        assetBundlesOnDownloadPool.Remove(request.assetInfo.hash);
                    }
                    if (request.unitywebRequest != null && !string.IsNullOrEmpty(request.unitywebRequest.GetResponseHeader("date")) && request.unitywebRequest.url.Contains("/game?"))
                    {
                        LastServerTime = DateTime.Parse(request.unitywebRequest.GetResponseHeader("date"));
                    }
                    OnResponse(request);
                }
            }

            public Request<T> Build<T>(string reqUrl, RequestMethod reqMethod, NameValueCollection query, Dictionary<string, object> reqParameters, bool autoFire, bool forceRetry, bool isVirtual, GenericCallback<T> callback, AssetInfo assetInfo, int timeOut = 20, Action<T> gameraCallBack = null)
            {
                Request<T> request = new Request<T>()
                {
                    reqCallback = new RequestCallback<T>(),
                    reqMethod = reqMethod,
                    headers = new Dictionary<string, string>(serverHeaders)
                };
                if (query == null)
                {
                    query = HttpUtility.ParseQueryString(string.Empty);
                }

                if (reqParameters != null)
                {
                    request.headers.Add("Content-Type", "application/json");
                    request.parameters = new Dictionary<string, object>(reqParameters);
                }
                 
                request.forceRetry = forceRetry;
                request.isVirtual = isVirtual;
                request.assetInfo = assetInfo;
                request.timeOut = assetInfo != null ? 1000 : timeOut;

                request.reqCallback.Success = (res, message, status) =>
                {
                    gameraCallBack?.Invoke(res);
                    callback?.Invoke(true, res, message, status);
                };
                request.reqCallback.Error = (res, status) =>
                {
                    callback?.Invoke(false, default, res, status);
                };

                // Append auth token, if it exists
                if (HasToken) query["token"] = Token;

                UriBuilder uriBuilder = new UriBuilder();

                request.headers.Add("Accept", "application/json");
                if (reqUrl.Contains("://"))
                {
                    uriBuilder = new UriBuilder(reqUrl);
                }
                else
                {
                    uriBuilder = new UriBuilder(BaseUrl + reqUrl);
                    //if (reqMethod == RequestMethod.GET)
                    //{
                    //    int i = 0;
                    //    foreach (var item in request.parameters.Keys)
                    //    {
                    //        request.url += item + "=" + request.parameters[item];
                    //        if (i != request.parameters.Keys.Count - 1)
                    //        {
                    //            request.url += "&";
                    //        }
                    //        i++;
                    //    }
                    //}
                }
                uriBuilder.Query = query.ToString();
                request.url = uriBuilder.Uri.ToString();
                request.SetUnityWebRequest();

                if (autoFire)
                {
                    Action<bool, RequestBundle> mainCallback = null;
                    mainCallback = (reqStatus, bundleReqres) =>
                    {
                        if (reqStatus)
                        {
                            DebugX.Log("Bundle Id {0} Succed!", bundleReqres.id.ToString());
                        }
                        else
                        {
                            request.reqCallback.Error("Error", -1);
                        }
                    };
                    RequestBundle bndleReq = new RequestBundle(request, mainCallback);
                    SendBatchRequest(bndleReq);
                    return null;
                }
                return request;
            }
            public Request<T> GetFile<T>(string url, GenericCallback<T> callback, AssetInfo assetInfo = null, bool autoFire = true, bool forceRetry = true, bool isVirtual = true)
            {
                return Build(url, RequestMethod.GET, null, null, autoFire, forceRetry, isVirtual, callback, null);
            }
            public Request<LocalizeCollection> GetLocalization(int version, GenericCallback<LocalizeCollection> callback, bool autoFire = true, bool forceRetry = true, bool isVirtual = true)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query["version"] = version.ToString();
                return Build("/localization", RequestMethod.GET, query, null, autoFire, forceRetry, isVirtual, callback, null);
            }
            public Request<GameModel> GetGame(GenericCallback<GameModel> callback, bool autoFire = true, bool forceRetry = true, bool isVirtual = true)
            {
                return Build("/game", RequestMethod.GET, null, null, autoFire, forceRetry, isVirtual, callback, null);
            }
            public Request<NewsCollection> GetNews(int version, GenericCallback<NewsCollection> callback, bool autoFire = true, bool forceRetry = true, bool isVirtual = true)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query["version"] = version.ToString();
                return Build("/news", RequestMethod.GET, query, null, autoFire, forceRetry, isVirtual, callback, null);
                //HttpUtility.ParseQueryString
            }
            #region Good
            public Request<GoodCollection> GetGoods(int version, GenericCallback<GoodCollection> callback, bool autoFire = true, bool forceRetry = true, bool isVirtual = true)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query["version"] = version.ToString();
                return Build("/good/all", RequestMethod.GET, query, null, autoFire, forceRetry, isVirtual, callback, null);
            }
            public Request<UserSetModel> Purchase(UserModel playerData, GoodModel good, Purchase purchase, GenericCallback<UserSetModel> callback, bool autoFire = true, bool forceRetry = true, bool isVirtual = false)
            {
                string Token = PlayerPrefs.GetString("Token", string.Empty);
                NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
                if (HasToken) query["token"] = Token;
                query["key"] = good.key;
                if (purchase != null)
                {
                    if (!good.ismarket)
                    {
                        DebugX.Error("You try buy a market that is not market type. please check {0} item definition", good.key);
                    }
                    query["purchaseTime"] = purchase.purchaseTime;
                    query["purchaseToken"] = purchase.purchaseToken;
                    query["orderId"] = purchase.orderId;
                }
                return Build("/good/purchase", RequestMethod.PUT, query, null, autoFire, forceRetry, isVirtual, callback, null, 20, (response) =>
                {
                    OnUserDataRecived(playerData, response);
                });
            }
            #endregion
            #region Login
            /// <summary>
            ///  anonymous login
            /// </summary>
            public Request<UserModel> Login(GenericCallback<UserModel> callback, bool autoFire = true, bool forceRetry = true, bool isVirtual = true)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);

                return Login(query, callback, autoFire, forceRetry, isVirtual);
            }
            /// <summary>
            ///  login by facebook
            /// </summary>
            public Request<UserModel> Login(string facebookAccessToken, GenericCallback<UserModel> callback, bool autoFire = true, bool forceRetry = true, bool isVirtual = true)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query["accessToken"] = facebookAccessToken;
                return Login(query, callback, autoFire, forceRetry, isVirtual);
            }
            /// <summary>
            ///  login by email
            /// </summary>
            public Request<UserModel> Login(string email, string password, GenericCallback<UserModel> callback, bool autoFire = true, bool forceRetry = true, bool isVirtual = true)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                query["password"] = password;
                query["email"] = email;
                return Login(query, callback, autoFire, forceRetry, isVirtual);
            }
            private Request<UserModel> Login(NameValueCollection query, GenericCallback<UserModel> callback, bool autoFire = true, bool forceRetry = true, bool isVirtual = true)
            {
                string Token = PlayerPrefs.GetString("Token", string.Empty);
                if (query == null)
                    query = HttpUtility.ParseQueryString(string.Empty);
                query["deviceId"] = SystemInfo.deviceUniqueIdentifier;
                query["platform"] = Application.platform.ToString();
                if (HasToken) query["token"] = Token;
                return Build("/auth", RequestMethod.POST, query, null, autoFire, forceRetry, isVirtual, callback, null, 20, (user) =>
                {
                    PlayerPrefs.SetString("Token", user.token);
                });
            }
            private string Token => PlayerPrefs.GetString("Token", string.Empty);
            private bool HasToken => !string.IsNullOrEmpty(Token);
            public void Logout()
            {
                PlayerPrefs.SetString("Token", string.Empty);
            }
            #endregion
            #region User

            public Request<UserSetModel> UpdateData(UserModel playerData, Dictionary<string, object> userData, GenericCallback<UserSetModel> callback, bool autoFire = true, bool forceRetry = true, bool isVirtual = true)
            {
                return Build("/auth", RequestMethod.PUT, null, userData, autoFire, forceRetry, isVirtual, callback, null, 20, (response) =>
                {
                    OnUserDataRecived(playerData, response);
                });
            }
            public Request<UserSetModel> GetData(UserModel playerData, Dictionary<string, object> userData, GenericCallback<UserSetModel> callback, bool autoFire = true, bool forceRetry = true, bool isVirtual = true)
            {
                return Build("/auth/get", RequestMethod.PUT, null, userData, autoFire, forceRetry, isVirtual, callback, null, 20, (response) =>
                {
                    OnUserDataRecived(playerData, response);
                });
            }
            private void OnUserDataRecived(UserModel playerData, UserSetModel response)
            {
                if (response.status)
                {
                    foreach (var paramName in response.parameterName)
                    {
                        Type parameterType = playerData.GetType();
                        FieldInfo paramField = parameterType.GetField(paramName);
                        if (paramField != null)
                        {
                            object oldValue = paramField.GetValue(playerData);
                            object newValue = paramField.GetValue(response.userData);
                            paramField.SetValue(playerData, paramField.GetValue(response.userData));
                            //var c = parameterType.GetField("On" + paramName + "Changed").GetValue(playerData);
                            //MethodInfo parameterOnChangeMethod = c.GetType().GetMethod("Invoke", new Type[] { paramField.FieldType, paramField.FieldType });
                            MethodInfo parameterOnChangeMethod = parameterType.GetMethod("On" + paramName + "Changed", new Type[] { paramField.FieldType, paramField.FieldType });
                            if (parameterOnChangeMethod != null)
                            {
                                parameterOnChangeMethod?.Invoke(playerData, new object[] { oldValue, newValue });
                            }
                        }
                        else
                        {
                            DebugX.Warning("Field {0} not found!", paramName);
                        }
                    }
                }
            }
            #endregion
            #region Friend
            public Request<UserCollection> GetFriends(GenericCallback<UserCollection> callback, bool autoFire = true, bool forceRetry = true, bool isVirtual = true)
            {
                return Build("/friends/all", RequestMethod.GET, null, null, autoFire, forceRetry, isVirtual, callback, null);
            }
            public Request<UserCollection> GetOnlineFriends(GenericCallback<UserCollection> callback, bool autoFire = true, bool forceRetry = true, bool isVirtual = true)
            {
                return Build("/friends/online", RequestMethod.GET, null, null, autoFire, forceRetry, isVirtual, callback, null);
            }
            public Request<UserCollection> GetFriendRequests(GenericCallback<UserCollection> callback, bool autoFire = true, bool forceRetry = true, bool isVirtual = true)
            {
                return Build("/friends/requests", RequestMethod.GET, null, null, autoFire, forceRetry, isVirtual, callback, null);
            }
            public Request<StatusModel> SendFriendRequest(string friendId, GenericCallback<StatusModel> callback, bool autoFire = true, bool forceRetry = true, bool isVirtual = true)
            {
                NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
                query["userId"] = friendId;
                return Build("/friends/requests", RequestMethod.POST, query, null, autoFire, forceRetry, isVirtual, callback, null);
            }
            public Request<StatusModel> AcceptFriendRequest(string friendId, GenericCallback<StatusModel> callback, bool autoFire = true, bool forceRetry = true, bool isVirtual = true)
            {
                NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
                query["userId"] = friendId;
                return Build("/friends/requests", RequestMethod.PUT, query, null, autoFire, forceRetry, isVirtual, callback, null);
            }
            public Request<StatusModel> DeclineFriendRequest(string friendId, GenericCallback<StatusModel> callback, bool autoFire = true, bool forceRetry = true, bool isVirtual = true)
            {
                NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
                query["userId"] = friendId;
                return Build("/friends/requests", RequestMethod.DELETE, query, null, autoFire, forceRetry, isVirtual, callback, null);
            }
            public Request<StatusModel> BlockUser(string friendId, GenericCallback<StatusModel> callback, bool autoFire = true, bool forceRetry = true, bool isVirtual = true)
            {
                NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
                query["userId"] = friendId;
                return Build("/friends/block", RequestMethod.POST, query, null, autoFire, forceRetry, isVirtual, callback, null);
            }
            public Request<StatusModel> UnblockUser(string friendId, GenericCallback<StatusModel> callback, bool autoFire = true, bool forceRetry = true, bool isVirtual = true)
            {
                NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
                query["userId"] = friendId;
                return Build("/friends/block", RequestMethod.PUT, query, null, autoFire, forceRetry, isVirtual, callback, null);
            }
            #endregion
            private void Awake()
            {
                if (isDebug)
                    BaseUrl = "127.0.0.1:2567";
                DebugX.RegisterPalette("Menchestan.Server", new DebugX.LogPalette(DebugX.ColorPalette.Seashell, DebugX.ColorPalette.Blue_Jeans, "SRVR"));
            }
        }
    }
}
