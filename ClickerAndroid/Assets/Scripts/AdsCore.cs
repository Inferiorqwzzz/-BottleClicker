using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool _testMode = true;

    private string _gameId = "4248703";

    private string _video = "Interstitial Android";
    private string _rewardedVideo = "Rewarded Android";
    private string _banner = "Banner Android";

    void Start()
    {
        Advertisement.Initialize(_gameId, _testMode);

        #region Banner
        StartCoroutine(ShowBannerWhenInitialized());
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);

        #endregion
    }

    public static void ShowAdsVideo(string placementId)
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show(placementId);
        }
        else
        {
            Debug.Log("Advertisement not ready!");
        }    
         
    }

    IEnumerator ShowBannerWhenInitialized()
    {
       while (!Advertisiment.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisiment.Banner.Show(_banner);
    }

    public void OnUnityAdsReady(string placementId)
    {
        throw new System.NotImplemetedEsception();
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplemetedEsception();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new System.NotImplemetedEsception();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        throw new System.NotImplemetedEsception();
    }
}