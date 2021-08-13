using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static int gainOnClick;
    public static int passiveGain;
    public static int curRoomFurniture;
    public static int curHomeFurniture;
    public static int curFurnitureItem;

    public static int curBumItem;

    public static int curUpgItem;


    public static int minutes = int.Parse(DateTime.Now.ToString("mm"));

    public static int hours = int.Parse(DateTime.Now.ToString("HH"));

    public static int days = int.Parse(DateTime.Now.ToString("dd"));

    public static int months = int.Parse(DateTime.Now.ToString("MM"));

    public static int timeWhenClosingGame, startTime, toAddFromTime;

    

    public void Awake()
    {
        startTime = minutes + hours * 60 + days * 1440 + months * 1296000;
        timeWhenClosingGame = PlayerPrefs.GetInt("curtime", startTime);
        passiveGain = PlayerPrefs.GetInt("passiveGain", 0);
        toAddFromTime = (startTime - timeWhenClosingGame) * 60 * passiveGain / 5;
        PlayerPrefs.SetInt("toAddFromTime", toAddFromTime);
        if (toAddFromTime < 0)
        toAddFromTime = 2000000000;
        StartCoroutine(toWriteTime());
        
    }
     public void Update()
     {
         Debug.Log("cur FUR "+ curFurnitureItem);
         Debug.Log("passive gain" + passiveGain);
     }
    public void DeleteProgressAndReloadScene()
    {
        MainScript mainScript = GetComponent<MainScript>();
        PlayerPrefs.DeleteAll();
        mainScript.DeletePlayer();
        print("deleted");
        SceneManager.LoadScene ("SampleScene");
        
    }
    public void DeleteProgress()
    {
        MainScript mainScript = GetComponent<MainScript>();
        PlayerPrefs.DeleteAll();
        mainScript.DeletePlayer();
        print("deleted");
        
    }
    IEnumerator toWriteTime()
    {
        yield return new WaitForSeconds(1f);

        minutes = int.Parse(DateTime.Now.ToString("mm"));

        hours = int.Parse(DateTime.Now.ToString("HH"));

        days = int.Parse(DateTime.Now.ToString("dd"));

        months = int.Parse(DateTime.Now.ToString("MM"));

        timeWhenClosingGame = minutes + hours * 60 + days * 1440 + months * 1296000;

        PlayerPrefs.SetInt("curtime", timeWhenClosingGame);

        print("start time " + startTime);
        print("time lasted" + (timeWhenClosingGame - startTime) * 60);
        print("time when closing a game " + timeWhenClosingGame);

        StartCoroutine(toWriteTime());
    }
    public void DoubleFromAdd ()
    {
        PlayerPrefs.GetInt("toAddFromTime", toAddFromTime);

        score = PlayerPrefs.GetInt("score", 0);
        score += toAddFromTime;
        score += toAddFromTime;

        PlayerPrefs.SetInt("score", score);
        
    }
    public void PlusFromAdd()
    {
        score = PlayerPrefs.GetInt("score", 0);
        score += 50000;
        PlayerPrefs.SetInt("score", score);
    }

    public void toAddFromTimeMethod ()
    {
        score = PlayerPrefs.GetInt("score", 0);
        score += toAddFromTime;
        PlayerPrefs.SetInt("score", score);
    }

    public void DoubleClick()
    {
            
            gainOnClick = gainOnClick * 2;
            StartCoroutine(WaitForSec(60f, 1));
             
    }

    public void DoubleCollect()
    {
        passiveGain *= 2; 
        StartCoroutine(WaitForSec(60f, 0));

    }
    
    public IEnumerator WaitForSec(float seconds, int whatToDo)
    {
        Debug.Log("waiting");
        yield return new WaitForSeconds(seconds);
        Debug.Log("Waited");

        if (whatToDo == 0)
        {
            passiveGain /=2; 
        }
        else 
        {
            gainOnClick /=2;
        }
    }
}
