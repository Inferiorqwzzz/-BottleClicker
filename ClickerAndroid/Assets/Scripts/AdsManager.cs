﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public static int bonusNum; 

    public GameManager gm;
    void Start()
    {
        gm = GetComponent<GameManager>();
        Advertisement.Initialize("4248703");
        Advertisement.AddListener(this);
    }


    public void PlayRewardedAdd(int num)
    {
        bonusNum = num;
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
        switch (bonusNum)
        {
            case 0:
                if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
                {
                    Debug.Log("DOUBLEFROMADD");
                    gm.DoubleFromAdd();
                }
                break;
            case 1:
                if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
                {
                    Debug.Log("DOUBLECOLLECT");
                    gm.DoubleCollect();
                }
                break;

            case 2:
                {
                    if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
                    {
                        Debug.Log("DOUBLECLICK");
                        gm.DoubleClick();
                    }
                    break;
                }
            case 3:
                {
                    if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
                    {
                        Debug.Log("PLUSFROMADD");
                        gm.PlusFromAdd();
                    }
                    break;
                }
        }

    }

}