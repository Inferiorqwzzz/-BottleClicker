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

    public static int monts = int.Parse(DateTime.Now.ToString("MM"));

    public static int curTime, startTime, toAddFromTime;
  
    public void Awake()
    {
        
    }
      public void Start()
    {
        startTime = minutes + hours * 60 + days * 1440 + monts * 	1296000;
        curTime = PlayerPrefs.GetInt ("curtime", curTime);
        toAddFromTime = (startTime - curTime) * 60 * passiveGain;
        score += toAddFromTime;
        
        
        
    }
    public void Update()
    {
    minutes = int.Parse(DateTime.Now.ToString("mm"));

    hours = int.Parse(DateTime.Now.ToString("HH"));

    days = int.Parse(DateTime.Now.ToString("dd"));

    monts = int.Parse(DateTime.Now.ToString("MM"));

    curTime = minutes  + hours * 60 + days * 1440 + monts * 1296000;
    PlayerPrefs.SetInt ("curtime", curTime);
    print ("start time " + startTime);
    print("time lasted" + (startTime-curTime)*60);
    print("cur time " + curTime);

    //     print("FurITEM" + curFurnitureItem);
    //     print ("homeSPRITE" + curHomeFurniture);
    //     print("RoomSprite" + curRoomFurniture);
    }
    
    public void DeleteProgress ()
    {
      MainScript mainScript = GetComponent<MainScript>();
        PlayerPrefs.DeleteAll();
        mainScript.DeletePlayer();
        print ("deleted");
        SceneManager.LoadScene("SampleScene");
        
       
    }

}
