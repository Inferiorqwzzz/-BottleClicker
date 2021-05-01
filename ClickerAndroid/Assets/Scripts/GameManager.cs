using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static int gainOnClick;
    public static int passiveGain;
    public static int canBuyFurniture;
      public void Start()
    {
        canBuyFurniture = 1;
        // score = PlayerPrefs.GetInt("score", 0); 
        // gainOnClick = PlayerPrefs.GetInt("gainOnClick",100000);
        // passiveGain = PlayerPrefs.GetInt("passiveGain",1);
    }
    
    public void DeleteProgress ()
    {
        PlayerPrefs.DeleteAll();
        print ("deleted");
        SceneManager.LoadScene("SampleScene");

    }

   
}
