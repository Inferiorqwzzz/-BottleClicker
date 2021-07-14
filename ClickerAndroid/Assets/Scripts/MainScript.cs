using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainScript : MonoBehaviour
{
    public Text activeScoreValue, passiveScoreValue;
    public GameObject Street, Room, Home, FurnitureShop, Bums, UpgradeShop, BumsBuying, Settings, Bonus;
    public Sprite[] roomFurniture, homeFurniture, shopSprites;
    public string[] shopItemsNames;
    public GameObject changeRoomObj, changeHomeObj;

    public GameObject[] changeMarketItem;

    public int curRoomFurniture = 0;
    public int curHomeFurniture = 0;
    public int curMarketItem = 0;
    string suffix;
    public void Incriment()
    {

        GameManager.score += GameManager.gainOnClick;
        PlayerPrefs.SetInt("score", GameManager.score);
    }
    IEnumerator ScorePerSec()
    {
        yield return new WaitForSeconds(1f);
        GameManager.score += GameManager.passiveGain;
        PlayerPrefs.SetInt("score", GameManager.score);
        StartCoroutine(ScorePerSec());

    }
    public double toShortNumber(int number)
    {
        int mag = (int)(Math.Floor(Math.Log10(number)) / 3); // Truncates (усекать,округлять) to 6, divides to 2
        double divisor = Math.Pow(10, mag * 3);

        double shortNumber = number / divisor;

        Console.WriteLine(shortNumber);
        Console.WriteLine(mag);
        return shortNumber;
    }
    public int toGetSuffix(int number)
    {
        int mag = (int)(Math.Floor(Math.Log10(number)) / 3); // Truncates (усекать,округлять) to 6, divides to 2
        double divisor = Math.Pow(10, mag * 3);

        double shortNumber = number / divisor;

        Console.WriteLine(shortNumber);
        Console.WriteLine(mag);
        return mag;
    }
    public void goingToLocation(int num)

    {
        if (num == 1) //go to street
        {
            Street.SetActive(true);
            Room.SetActive(false);
            Home.SetActive(false);
            FurnitureShop.SetActive(false);
            Bums.SetActive(false);
            UpgradeShop.SetActive(false);
            //.SetActive(false);
            BumsBuying.SetActive(false);
            Settings.SetActive(false);

            Bonus.SetActive(false);
        }
        if (num == 2) // go to home
        {
            Street.SetActive(false);
            Room.SetActive(false);
            Home.SetActive(true);
            FurnitureShop.SetActive(false);
            Bums.SetActive(false);
            UpgradeShop.SetActive(false);
            //.SetActive(false);
            BumsBuying.SetActive(false);
            Settings.SetActive(false);
            Bonus.SetActive(false);
        }
        if (num == 3) // go to room
        {
            Street.SetActive(false);
            Room.SetActive(true);
            Home.SetActive(false);
            FurnitureShop.SetActive(false);
            Bums.SetActive(false);
            UpgradeShop.SetActive(false);
            //.SetActive(false);
            BumsBuying.SetActive(false);
            Settings.SetActive(false);
            Bonus.SetActive(false);
        }
        if (num == 4) //go to shop
        {
            Street.SetActive(false);
            Room.SetActive(false);
            Home.SetActive(false);
            FurnitureShop.SetActive(true);
            Bums.SetActive(false);
            UpgradeShop.SetActive(false);
            //.SetActive(false);
            BumsBuying.SetActive(false);
            Settings.SetActive(false);
            Bonus.SetActive(false);
        }
        if (num == 5) //go to bums
        {
            Street.SetActive(false);
            Room.SetActive(false);
            Home.SetActive(false);
            FurnitureShop.SetActive(false);
            Bums.SetActive(true);
            UpgradeShop.SetActive(false);
            //.SetActive(false);
            BumsBuying.SetActive(false);
            Settings.SetActive(false);
            Bonus.SetActive(false);
        }
        if (num == 6) //go to upgradeShop
        {
            Street.SetActive(false);
            Room.SetActive(false);
            Home.SetActive(false);
            FurnitureShop.SetActive(false);
            Bums.SetActive(false);
            UpgradeShop.SetActive(true);
            //.SetActive(false);
            BumsBuying.SetActive(false);
            Settings.SetActive(false);
            Bonus.SetActive(false);
        }
        if (num == 7) //go to UpgradeShop
        {
            Street.SetActive(false);
            Room.SetActive(false);
            Home.SetActive(false);
            FurnitureShop.SetActive(false);
            Bums.SetActive(false);
            UpgradeShop.SetActive(true);
            //.SetActive(false);
            BumsBuying.SetActive(false);
            Settings.SetActive(false);
            Bonus.SetActive(false);
        }
        if (num == 8) //go to BumsBuying
        {
            Street.SetActive(false);
            Room.SetActive(false);
            Home.SetActive(false);
            FurnitureShop.SetActive(false);
            Bums.SetActive(false);
            UpgradeShop.SetActive(false);
            //.SetActive(false);
            BumsBuying.SetActive(true);
            Settings.SetActive(false);
            Bonus.SetActive(false);
        }
        if (num == 9) //go to Setting
        {
            Street.SetActive(false);
            Room.SetActive(false);
            Home.SetActive(false);
            FurnitureShop.SetActive(false);
            Bums.SetActive(false);
            UpgradeShop.SetActive(false);
            //.SetActive(false);
            BumsBuying.SetActive(false);
            Settings.SetActive(true);
            Bonus.SetActive(false);
        }
        if (num == 10) //go to bonus
        {
            Street.SetActive(false);
            Room.SetActive(false);
            Home.SetActive(false);
            FurnitureShop.SetActive(false);
            Bums.SetActive(false);
            UpgradeShop.SetActive(false);
            BumsBuying.SetActive(false);
            Settings.SetActive(false);
            Bonus.SetActive(true);
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

        StartCoroutine(ScorePerSec());

    }
    public void LoadLocations()
    {
        Street.SetActive(true);
        Room.SetActive(false);
        Home.SetActive(false);
        FurnitureShop.SetActive(false);
        Bums.SetActive(false);
        UpgradeShop.SetActive(false);
        BumsBuying.SetActive(false);
        Settings.SetActive(false);
        Bonus.SetActive(false);
    }
    public void LoadInformation()
    {
        GameManager.score = PlayerPrefs.GetInt("score", 0);
        GameManager.gainOnClick = PlayerPrefs.GetInt("gainOnClick", 100);
        GameManager.passiveGain = PlayerPrefs.GetInt("passiveGain", 1);
        GameManager.canBuyFurniture = PlayerPrefs.GetInt("canBuyFurniture", 1);

    }
    public void Update()

    {
        passiveScoreValue.text = "Бомжи приносят:" + GameManager.passiveGain;
        switch (toGetSuffix(GameManager.score))
        {
            case 0:
                suffix = string.Empty;
                activeScoreValue.text = "Бутылачки: " + toShortNumber(GameManager.score) + suffix;
                break;
            case 1:
                suffix = "k";
                activeScoreValue.text = "Бутылачки: " + toShortNumber(GameManager.score).ToString("N1") + suffix;
                break;
            case 2:
                suffix = "m";
                activeScoreValue.text = "Бутылачки: " + toShortNumber(GameManager.score).ToString("N1") + suffix;
                break;
            case 3:
                suffix = "b";
                activeScoreValue.text = "Бутылачки: " + toShortNumber(GameManager.score).ToString("N1") + suffix;
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
    public void BuyRoom()
    {
        changeRoomObj.GetComponent<Image>().sprite = roomFurniture[curRoomFurniture];
        curRoomFurniture++;
    }
    public void ChangeTheIconAndText()
    {
    //changeMarketItem[curMarketItem].GetComponentInChildren<Image>().sprite = shopSprites[curMarketItem];
    //changeMarketItem[curMarketItem].GetComponentInChildren<Text>().text = shopItemsNames[curMarketItem];
    changeMarketItem[curMarketItem].transform.Find("Text").GetComponent<Text>().text = shopItemsNames[curMarketItem];
    changeMarketItem[curMarketItem].transform.Find("Image").GetComponent<Image>().sprite = shopSprites[curMarketItem];
    curMarketItem++;
    }
    
    //TODO: 1) Moving on locations 2) Buying upgrades 3) Buying furniture 4) Buying + cost * 1.07
}   //TODO: SHOP - loading the furniture - loading icons - change icons onclick - block icons until
