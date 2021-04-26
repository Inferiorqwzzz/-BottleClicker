using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public Text score, passiveScoreValue;
    public GameObject Street, Room, Home, Bums;
    
    public void Incriment()
    {
        
        GameManager.score += GameManager.gainOnClick;
        
    }
    IEnumerator ScorePerSec()
    {
        GameManager.score += GameManager.passiveGain;
        yield return new WaitForSeconds (1f);
        StartCoroutine (ScorePerSec());

    }
    public void goingToLocation (int num)
    {
        if (num == 1)
        {
        Street.SetActive(true);
        Room.SetActive(false);
        Home.SetActive(false);
        Bums.SetActive(false);
        }
        if (num == 2)
        {
        Street.SetActive(false);
        Room.SetActive(false);
        Home.SetActive(true);
        Bums.SetActive(false);
        }
        if (num == 3)
        {
        Street.SetActive(false);
        Room.SetActive(true);
        Home.SetActive(false);
        Bums.SetActive(false);
        }
       
    }
    void Start()
    {
        StartCoroutine (ScorePerSec()); 
        Street.SetActive(true);
        Room.SetActive(false);    
        Home.SetActive(false);
        Bums.SetActive(false);
       
    }

    
    void Update()
    {
        PlayerPrefs.SetInt("score", GameManager.score);
        score.text = "Бутылачки: " + GameManager.score;
        passiveScoreValue.text = "Бомжи приносят:" + GameManager.passiveGain;
    }
}
