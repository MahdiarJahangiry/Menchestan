using System;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Menchestan
{
    namespace Server
    {
        public enum RequestMethod
        {
            POST,
            GET,
            UPLOAD,
            PUT,
            DELETE
        }
        class AcceptAllCertificatesSignedWithASpecificKeyPublicKey : CertificateHandler
        {
            protected override bool ValidateCertificate(byte[] certificateData)
            {
                return true;
            }
        }
        public class Request<T> : IRequest
        {
            public Response<T> Response;
            public RequestCallback<T> reqCallback;
            public Request()
            {
                id = reqIndex++;
            }
            public override void SetUnityWebRequest()
            {
                if (responseType != ResponseType.None)
                    DebugX.Log("Retry {0}=> Method: {1} | URL: {2} | PARAMETERS: {3} | Headers: {4}", id, reqMethod, url, parameters, headers);

                reqWatch = new System.Diagnostics.Stopwatch();
                responseType = ResponseType.None;
                if (headers.ContainsKey("UniqueIdentify"))
                    headers["UniqueIdentify"] = Guid.NewGuid().ToString().ToLower();
                else
                    headers.Add("UniqueIdentify", Guid.NewGuid().ToString().ToLower());
                switch (reqMethod)
                {
                    case RequestMethod.POST:
                        byte[] bodyRaw =Encoding.UTF8.GetBytes(MiniJSON.Json.Serialize(parameters));
                        unitywebRequest = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST)
                        {
                            uploadHandler = new UploadHandlerRaw(bodyRaw),
                            downloadHandler = new DownloadHandlerBuffer()
                        };
                        break;
                    case RequestMethod.GET:

                        if (assetInfo == null)
                        {
                            if (typeof(T) == typeof(Texture2D) | typeof(T) == typeof(Sprite))
                            {
                                unitywebRequest = UnityWebRequestTexture.GetTexture(url);
                            }
                            else
                            {
                                unitywebRequest = new UnityWebRequest(url, UnityWebRequest.kHttpVerbGET)
                                {
                                    downloadHandler = new DownloadHandlerBuffer()
                                };
                            }
                        }
                        else
                        {
                            Hash128 hash = Hash128.Parse(assetInfo.hash);
                            unitywebRequest = UnityWebRequestAssetBundle.GetAssetBundle(url, hash, 0);
                        }
                        unitywebRequest.certificateHandler = new AcceptAllCertificatesSignedWithASpecificKeyPublicKey();
                        break;
                    case RequestMethod.PUT:
                        byte[] putData = Encoding.UTF8.GetBytes(MiniJSON.Json.Serialize(parameters));
                        unitywebRequest = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPUT, new DownloadHandlerBuffer(), new UploadHandlerRaw(putData));
                        break;
                    case RequestMethod.DELETE:
                        unitywebRequest = new UnityWebRequest(url, UnityWebRequest.kHttpVerbDELETE)
                        {
                            downloadHandler = new DownloadHandlerBuffer()
                        };
                        break;
                    case RequestMethod.UPLOAD:
                        break;
                    default:
                        break;
                }
                foreach (var header in headers)
                {
                    unitywebRequest.SetRequestHeader(header.Key, header.Value);
                }
                unitywebRequest.timeout = timeOut;
                unitywebRequest.useHttpContinue = false;
            }
            public override void SetResponse()
            {
                if (responseType != ResponseType.None)
                {
                    if (responseType == ResponseType.TimeOut)
                        ErrorMessage = id + "=> " + responseType.ToString() + " Error : Request take " + reqWatch.Elapsed.ToString() + " Milliseconds.";
                    DebugX.Error("{0}=> {1} Error: Request take {2} Milliseconds.", id, responseType, reqWatch.Elapsed);
                }
                if (unitywebRequest.isNetworkError || unitywebRequest.error != null)
                {
                    responseType = ResponseType.Client2Server;
                    ErrorMessage = id + "=> " + responseType.ToString() + " Error : " + unitywebRequest.error;
                    DebugX.Error("{0} => {1} Error: {2}", id, responseType, unitywebRequest.error);
                }
                else
                {
                    if (unitywebRequest.responseCode == 200 || (unitywebRequest.responseCode == 0 && assetInfo != null))
                    {
                        responseType = ResponseType.Done;
                        try
                        {
                            if (assetInfo != null)
                            {
                                AssetBundle bundle = loadedBundle ?? DownloadHandlerAssetBundle.GetContent(unitywebRequest);
                                Response = new Response<T>
                                {
                                    data = (T)(object)bundle,
                                    status = 200,
                                    totalpage = 0,
                                    message = ""
                                };
                            }
                            else
                            {
                                if (typeof(T) == typeof(Texture2D) | typeof(T) == typeof(Sprite))
                                {
                                    Texture2D texture = DownloadHandlerTexture.GetContent(unitywebRequest);
                                    Response = new Response<T>
                                    {
                                        data = ((typeof(T) == typeof(Texture2D) ? (T)(object)texture : (T)(object)(Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f))))),
                                        status = 200,
                                        totalpage = 0,
                                        message = "Virtual Response"
                                    };
                                }
                                else
                                {
                                    // Server answered
                                    string strResponse = unitywebRequest.downloadHandler.text;
                                    if (strResponse.StartsWith("[", StringComparison.CurrentCulture))
                                    {
                                        strResponse = "{\"items\": " + strResponse + "}";
                                    }
                                    DebugX.Log("{0}=> {1}", id, strResponse);

                                    if (isVirtual)
                                    {
                                        Response = new Response<T>
                                        {
                                            data = JsonUtility.FromJson<T>(strResponse),
                                            status = 200,
                                            totalpage = 0,
                                            message = "Virtual Response"
                                        };
                                        if (typeof(byte[]).IsAssignableFrom(typeof(T)))
                                        {
                                            Response.data = (T)((object)unitywebRequest.downloadHandler.data);
                                        }
                                    }
                                    else
                                    {
                                        Response = JsonUtility.FromJson<Response<T>>(strResponse);
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            responseType = ResponseType.Cast;
                            ErrorMessage = id + "=> " + responseType.ToString() + " Error : Cannot cast " + typeof(T) + ". " + e.Message;
                            DebugX.Error("{0}=> {1} Error: Cannot cast {2}. {3}", id, responseType, typeof(T), e.Message);
                        }
                    }
                    else
                    {
                        responseType = ResponseType.Server;
                        ErrorMessage = id + " => " + responseType.ToString() + " Error : Game Server Status is " + unitywebRequest.responseCode + ". " + unitywebRequest.downloadHandler.text;
                        DebugX.Error("{0}=> {1} Error: Game Server Status is {2}. {3}", id, responseType, unitywebRequest.responseCode, unitywebRequest.downloadHandler.text);
                    }
                }
            }
            public override void RunCallback()
            {
                if (responseType != ResponseType.Done)
                {
                    reqCallback.Error(ErrorMessage, -1);
                }
                else
                {
                    if (Response.IsSuccessfull)
                    {
                        reqCallback.Success(Response.data, Response.message, Response.status);
                    }
                    else
                    {
                        reqCallback.Error(Response.message, Response.status);
                    }
                }
            }
        }
    }
}
