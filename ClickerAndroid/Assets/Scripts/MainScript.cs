using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainScript : MonoBehaviour
{
    public Text activeScoreValue, passiveScoreValue;
    public GameObject Street, Room, Home, Shop; //Bums
    public Sprite [] roomFurniture, homeFurniture; 
    public GameObject changeRoomObj, changeHomeObj;
    public int curRoomFurniture = 0; 
    public int curHomeFurniture = 0;
    string suffix;
    public void Incriment()
    {
        
        GameManager.score += GameManager.gainOnClick;
        PlayerPrefs.SetInt("score", GameManager.score);
    }
    IEnumerator ScorePerSec()
    {
        yield return new WaitForSeconds (1f);
        GameManager.score += GameManager.passiveGain;
        PlayerPrefs.SetInt("score", GameManager.score);
        StartCoroutine (ScorePerSec());

    }
    public double toShortNumber (int number)
    {
        int mag = (int)(Math.Floor(Math.Log10(number)) / 3); // Truncates (усекать,округлять) to 6, divides to 2
            double divisor = Math.Pow(10, mag * 3);

            double shortNumber = number / divisor;

            Console.WriteLine(shortNumber);
            Console.WriteLine(mag);
            return shortNumber;
    }
    public int toGetSuffix (int number)
    {
        int mag = (int)(Math.Floor(Math.Log10(number)) / 3); // Truncates (усекать,округлять) to 6, divides to 2
            double divisor = Math.Pow(10, mag * 3);

            double shortNumber = number / divisor;

            Console.WriteLine(shortNumber);
            Console.WriteLine(mag);
            return mag;
    }
    public void goingToLocation (int num)
    
    {
        if (num == 1) //go to street
        {
        Street.SetActive(true);
        Room.SetActive(false);
        Home.SetActive(false);
        Shop.SetActive(false);
        //Bums.SetActive(false);
        
        }
        if (num == 2) // go to home
        {
        Street.SetActive(false);
        Room.SetActive(false);
        Home.SetActive(true);
        Shop.SetActive(false);
        //Bums.SetActive(false);
        
        }
        if (num == 3) // go to room
        {
        Street.SetActive(false);
        Room.SetActive(true);
        Home.SetActive(false);
        Shop.SetActive(false);
        //Bums.SetActive(false);
        
        }
        if (num == 4) //go to shop
        {
        Street.SetActive(false);
        Room.SetActive(false);
        Home.SetActive(false);
        Shop.SetActive(true);
        //Bums.SetActive(false);
        
        }
       
    }
     public int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    public bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
    void Start()
    {
        
        LoadInformation();
        LoadLocations();
        
        StartCoroutine (ScorePerSec());
       
    }
    public void LoadLocations ()
    {
        Street.SetActive(true);
        Room.SetActive(false);    
        Home.SetActive(false);
        Shop.SetActive(false);
        //Bums.SetActive(false);
    }
    public void LoadInformation ()
    {
        GameManager.score = PlayerPrefs.GetInt("score", 0); 
        GameManager.gainOnClick = PlayerPrefs.GetInt("gainOnClick",100);
        GameManager.passiveGain = PlayerPrefs.GetInt("passiveGain",1);
        GameManager.canBuyFurniture = PlayerPrefs.GetInt ("canBuyFurniture", 1);

    }
    public void Update()
    
    {
        passiveScoreValue.text = "Бомжи приносят:" + GameManager.passiveGain;
        switch (toGetSuffix(GameManager.score))
        {
            case 0:
            suffix = string.Empty;
            activeScoreValue.text = "Бутылачки: " + toShortNumber (GameManager.score) + suffix;
            break;
            case 1: 
            suffix = "k";
            activeScoreValue.text = "Бутылачки: " + toShortNumber (GameManager.score).ToString("N1") + suffix;
            break;
            case 2:
            suffix = "m";
            activeScoreValue.text = "Бутылачки: " + toShortNumber (GameManager.score).ToString("N1") + suffix;
            break;
            case 3: 
            suffix = "b";
            activeScoreValue.text = "Бутылачки: " + toShortNumber (GameManager.score).ToString("N1") + suffix;
            break;   
        }

    }
   public void BuyHome()
   {   
     changeHomeObj.GetComponent<Image>().sprite = homeFurniture[curHomeFurniture];
     curHomeFurniture++;
     // TODO: Make a starting loader of the furniture 
     //how to fucking do it 
     // firstly we dont do the permission to buy we have just to change images when push da baatton
     // we make an array of images 
     // then we take the component and change an image and can buy true
     //HOW TO SAVE IT
   }
   public void BuyRoom ()
   {
    changeRoomObj.GetComponent<Image>().sprite = roomFurniture[curRoomFurniture];
    curRoomFurniture++;
   }
}
