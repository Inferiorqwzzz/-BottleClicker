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
        toAddFromTime = (startTime - timeWhenClosingGame) * 60 * passiveGain;
        score = PlayerPrefs.GetInt("score", 0);
        score += toAddFromTime;
        PlayerPrefs.SetInt("score", score);
        //6
    }
    public void Start()
    {
        StartCoroutine(toWriteTime());
        print("start time " + startTime);
        print("time lasted" + toAddFromTime);
        print("time when closing a game" + timeWhenClosingGame);
     
    }
    public void Update()
    {
    

        //     print("FurITEM" + curFurnitureItem);
        //     print ("homeSPRITE" + curHomeFurniture);
        //     print("RoomSprite" + curRoomFurniture);
    }

    public void DeleteProgress()
    {
        MainScript mainScript = GetComponent<MainScript>();
        PlayerPrefs.DeleteAll();
        mainScript.DeletePlayer();
        print("deleted");
        SceneManager.LoadScene ("SampleScene");

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

}
