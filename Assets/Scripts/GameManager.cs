using System;
using UnityEngine;
using Menchestan.IAB;
using Menchestan.Menu;
using Menchestan.Server;
using Menchestan.VideoAD;
using Sirenix.OdinInspector;
using Menchestan.Localization;
using Menchestan.Server.Model;
using System.Collections.Generic;
using Menchestan.NEWS;

public class GameManager : SerializedMonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    instance = new GameObject("GameManager", typeof(GameManager)).AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    public NewsManager newsManager = new NewsManager();
    public IABManager iabManager;
    public UserModel user;
    public VideoAdManager videoAdManager = new VideoAdManager();

    public readonly int maxQuota = 3;
    public int remainingQuota;
    public readonly int maxFreeFortuneWheel = 3;
    public int remainingFreeFortuneWheel;

    public bool isOnline;

    void Start()
    {
        GetGameData();
    }
    private void GetGameData()
    {
        ServerKit.Instance.GetGame(OnGameDataRecived);
    }
    private void OnGameDataRecived(bool status, GameModel response, string message, int code)
    {
        if (status)
        {
            if (!string.IsNullOrEmpty(response.banmsg))
            {
                DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "Error", response.banmsg, () =>
                {
                    DialogBoxMenu.Hide();
                    Application.Quit();
                });
                return;
            }
            if (response.vgame > float.Parse(Application.version))
            {
                DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "NewVersion", "MsgNewVersion", new List<string>() { response.vgame.ToString() }, () =>
                {
                    DialogBoxMenu.Hide();
                    GoToUpdate();
                });
                return;
            }
            LocalizationManager.Instance.Initialize(response.vlocalize);
            iabManager.Initialize(response.vgood, null);
            newsManager.Initialize(response.vnews);
            if (code == 200)
            {
                ServerKit.Instance.Login(OnLogin);
            }
            else
            {
                OfflineUser();
            }
            SetOfflineTicket();
        }
        else
        {
            DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.TryOffline, "Error", "GameDataError", new List<Action>()
            {
                ()=>{
                DialogBoxMenu.Instance.ShowBackground();
                    DialogBoxMenu.Hide();
                    GetGameData();
                },
                ()=>{
                    DialogBoxMenu.Instance.ShowBackground();
                    DialogBoxMenu.Hide();
                    OnGameDataRecived(true, new GameModel(), "Offline", 201);
                }
             });
        }
    }
    private void SetOfflineTicket()
    {
        string strLastOpen = PlayerPrefs.GetString("LastPlayerOnline", string.Empty);
        DateTime currentTime = isOnline ? ServerKit.LastServerTime : DateTime.Now;

        if (!string.IsNullOrEmpty(strLastOpen))
        {
            DateTime lastPlayed = DateTime.Parse(strLastOpen);
            if (currentTime.Subtract(lastPlayed.Date).Days >= 1)
            {
                PlayerPrefs.SetInt("OfflineTicket", maxQuota);
                PlayerPrefs.SetInt("FortuneWheelTicket", 1);
                PlayerPrefs.SetString("LastPlayerOnline", currentTime.ToString());
            }
        }
        else
        {
            PlayerPrefs.SetString("LastPlayerOnline", currentTime.ToString());
        }
        remainingQuota = PlayerPrefs.GetInt("OfflineTicket", maxQuota);
        remainingFreeFortuneWheel = PlayerPrefs.GetInt("FortuneWheelTicket", maxFreeFortuneWheel);
    }
    private void OnLogin(bool status, UserModel response, string message, int code)
    {
        if (status)
        {
            user = response;
            isOnline = true;
            //videoAdManager.Initialize();

            //ServerKit.Instance.GetData(user, new Dictionary<string, object>() { { "level", 0 } }, Ss);
            //ServerKit.Instance.Purchase(user,
            //    new GoodModel() { key = "coinpack000" },
            //    new Purchase()
            //    {
            //        orderId = "KwkfhAmt7jRqameW",
            //        packageName = "com.tech.jomenchi",
            //        productId = "coinpack004",
            //        purchaseTime = "1599304123893",
            //        purchaseState = 0,
            //        developerPayload = "",
            //        purchaseToken = "KwkfhAmt7jRqameW",
            //        itemType = "inapp",
            //        signature = "aDPzuhV+QHWOUgHYHVe9csAn8jVjxmvt20EiVVoU4tM+R4zQinFCghh51gIyWcoKhOUigWqHDU6RpJuPTtpBwoMna5baIJ1ebOOXzm1DtIY4pj7bcXBJnJ8LKC5+x3qHJbkPWg5ipRWliJiHTqgAOEe4dBhI+ovskK7eBOUlNuLzJqnw1QybRIvwRn0TyOz9I\"/jOW3sGqocNUClrcpkiCv+M63JyqrYgRYwzKi0D"
            //    }, Ss);
            MainMenu.Show();
        }
        else
        {
            DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.TryOffline, "Error", "PlayerDataError", new List<Action>()
            {
                ()=>{
                    DialogBoxMenu.Instance.ShowBackground();
                    DialogBoxMenu.Hide();
                    ServerKit.Instance.Login(OnLogin);
                },
                ()=>{
                    DialogBoxMenu.Instance.ShowBackground();
                    DialogBoxMenu.Hide();
                    OfflineUser();
                }
            });
        }
    }

    //private void Ss(bool status, UserSetModel response, string message, int code)
    //{
    //    DebugX.Log("Json = >> {0}", JsonUtility.ToJson(response));
    //}

    private void OfflineUser()
    {
        MainMenu.Show();
    }
    void GoToUpdate()
    {
        try
        {
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_VIEW"));
            intentObject.Call<AndroidJavaObject>("setData", uriClass.CallStatic<AndroidJavaObject>("parse", "bazaar://details?id=" + Application.identifier));
            intentObject.Call<AndroidJavaObject>("setPackage", "com.farsitel.bazaar");
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            currentActivity.Call("startActivity", intentObject);
            Application.Quit();
        }
        catch (Exception)
        {
            DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "CheckCafebazaar", "MsgCheckCafebazaar", () =>
            {
                DialogBoxMenu.Hide();
                Application.Quit();
            });
        }
    }
}