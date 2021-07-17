using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    

      public void Start()
    {
        
    }
    public void Update()
    {
    //     print("FurITEM" + curFurnitureItem);
    //     print ("homeSPRITE" + curHomeFurniture);
    //     print("RoomSprite" + curRoomFurniture);
    }
    
    public void DeleteProgress ()
    {
        PlayerPrefs.DeleteAll();
        print ("deleted");
        SceneManager.LoadScene("SampleScene");

    }

}
