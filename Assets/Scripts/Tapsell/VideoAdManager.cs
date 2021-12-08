using System;
using TapsellSDK;
using Menchestan.Menu;
using System.Collections.Generic;

namespace Menchestan
{
    namespace VideoAD
    {
        public class CahcedVideoAd
        {
            public bool mustShow;
            public TapsellAd cachedAd;
            public Action<bool, string> callback;
        }
        public class VideoAdManager
        {
            public string TAPSELL_KEY;
            public Dictionary<string, CahcedVideoAd> cachedAds;
            // Start is called before the first frame update
            public void Initialize()
            {
                Tapsell.initialize(TAPSELL_KEY);
                CacheVideos();
                //jpprfehdbmqkqljobpmqgilgojcbpbhqslgsqpqrnaeshmbrcfaiptjiqtiblfpqpghdik
                //5f5fdb49b081620001cc876d
            }
            private void CacheVideos()
            {
                foreach (var ads in cachedAds)
                {
                    if (ads.Value.cachedAd == null)
                        RequestVideoAdd(ads.Key, false, null);
                }
            }
            // Update is called once per frame
            public void RequestVideoAdd(string zoneId, bool mustShow, Action<bool, string> callback)
            {
                cachedAds[zoneId].mustShow = mustShow;

                if (mustShow)
                {
                    cachedAds[zoneId].callback = callback;
                    if (cachedAds[zoneId].cachedAd != null)
                    {
                        onAdAvailableAction(cachedAds[zoneId].cachedAd);
                    }
                    else
                    {
                        Tapsell.requestAd(zoneId, true, onAdAvailableAction, onNoAdAvailableAction, onErrorAction, onNoNetworkAction, onExpiringAction);
                    }
                }
                else
                {
                    Tapsell.requestAd(zoneId, false, onAdAvailableAction, onNoAdAvailableAction, onErrorAction, onNoNetworkAction, onExpiringAction);
                }
            }

            private void onExpiringAction(TapsellAd obj)
            {
                cachedAds[obj.zoneId].callback?.Invoke(false, "AdExpiring");
                cachedAds[obj.zoneId].cachedAd = null;
                DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "Error", "AdExpiring");
            }

            private void onNoNetworkAction(string obj)
            {
                DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "Error", "NoAdNetwork");
            }

            private void onErrorAction(TapsellError obj)
            {
                cachedAds[obj.zoneId].callback?.Invoke(false, obj.error);
                cachedAds[obj.zoneId].cachedAd = null;
                DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "Error", obj.error);
            }

            private void onNoAdAvailableAction(string obj)
            {
                DialogBoxMenu.Instance.ShowDialog(DialogBoxButtonType.Ok, "Error", "NoAdAvailable");
            }

            private void onAdAvailableAction(TapsellAd ad)
            {
                TapsellShowOptions showOptions = new TapsellShowOptions
                {
                    backDisabled = false,
                    immersiveMode = false,
                    rotationMode = TapsellShowOptions.ROTATION_UNLOCKED,
                    showDialog = true
                };
                if (cachedAds[ad.zoneId].mustShow)
                {
                    Tapsell.setRewardListener((TapsellAdFinishedResult result) =>
                    {
                        cachedAds[ad.zoneId].cachedAd = null;
                        if (result.rewarded)
                        {
                            cachedAds[ad.zoneId].callback?.Invoke(result.completed, result.completed ? "VideoCompleted" : "VideoNotCompleted");
                        }
                        else
                        {
                            cachedAds[ad.zoneId].callback?.Invoke(true, "VideoNotCompleted");
                        }
                        CacheVideos();
                    });
                    Tapsell.showAd(ad, showOptions);
                }
                else
                {
                    cachedAds[ad.zoneId].cachedAd = ad;
                }
            }
        }
    }
}
