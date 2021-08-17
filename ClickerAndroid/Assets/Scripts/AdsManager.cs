using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using System;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public static int bonusNum; 

    public GameManager gm;

    public MainScript ms;

    public GameObject doubleClick, doublePassive, plusScore; 

        

    double writeTextValue;
    void Start()
    {
        ;
        gm = GetComponent<GameManager>();
        ms = GetComponent<MainScript>();
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
        DisableAllButtons(); 
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
    public IEnumerator GameObjectDisable (float seconds, GameObject [] goArr)
    {
        for (int i = 0; i < 3; i++)
        {
        goArr[i].SetActive(false);
        }
        yield return new WaitForSeconds(seconds);
        for (int i = 0; i < 3; i++)
        {
        goArr[i].SetActive (true);
        }
    }
    public void DisableAllButtons()
    {
           StartCoroutine(GameObjectDisable(15, new GameObject [] {plusScore, doubleClick, doublePassive}));
    }
    

}
