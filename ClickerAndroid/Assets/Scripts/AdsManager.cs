using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{

    void Start()
    {
        Advertisement.Initialize("4248703"); 
        Advertisement.AddListener(this);
    }

    public void PlayRewardedAdd()
    {
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
        else
        {
            Debug.Log("Rewarded add is not ready");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("ADS ARE READY");
    }

    public void OnUnityAdsDidError(string message)
    {
       Debug.Log("Error" + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Video started");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        Debug.Log("Video is finished");
        if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            GameManager.DoubleFromAdd();
        }
    }
}
