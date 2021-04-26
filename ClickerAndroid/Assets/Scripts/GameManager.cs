using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static int gainOnClick;
    public static int passiveGain;
    public static int passiveScore;
      void Start()
    {
        
        score = PlayerPrefs.GetInt("score",0); 
        gainOnClick = PlayerPrefs.GetInt("gainOnClick",1);
        passiveGain = PlayerPrefs.GetInt("passiveGain",1);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }
    }

}
