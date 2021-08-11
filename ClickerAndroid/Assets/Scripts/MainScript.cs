using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainScript : MonoBehaviour
{
    #region Variables declaration 
    public Text activeScoreValue, passiveScoreValue, idleInfo;
    public GameObject Street, Room, Home, FurnitureShop, Bums, UpgradeShop, BumsBuying, Settings, Bonus, Idle;
    public Sprite[] roomFurniture, homeFurniture, FurShopSprites, BumShopSprites, UpgShopSprites;
    public string[] FurItemName, UpgItemName, BumItemName;
    public GameObject changeRoomObj, changeHomeObj;
    public int[] pricesFurniture, pricesUpgrades, startingPricesOfUpgrades, startingPricesOfBums;

    public double[] pricesBums; 

    public int[] bumsGains, upgClickGains;
    public GameObject[] changeFurnitureItem, changeUpgradeItem, changeBumItem;

    public int[] bumsLevels = new int[13];
    public int[] upgLevels = new int[13];

    public GameObject buyAudio;

    public GameObject slideShow, startPan;
    
    public int slideShowState, startPanState;

    public GameObject floatingText;
   



    string suffix;
    #endregion
    void Start()
    {
        
        StartCoroutine(ScorePerSec());
        LoadInformation();
        LoadLocations();
        idleInfo.text = "Пока вас не было бомжи принесли " + GameManager.toAddFromTime + " бутылок";

    }
    public void Update()

    {

        passiveScoreValue.text = "В секунду:" + GameManager.passiveGain;
        switch (toGetSuffix(GameManager.score))
        {
            case 0:
                suffix = string.Empty;
                activeScoreValue.text = "" + toShortNumber(GameManager.score) + suffix;
                break;
            case 1:
                suffix = string.Empty;
                activeScoreValue.text = "" + toShortNumber(GameManager.score) + suffix;
                break;
            case 2:
                suffix = "M";
                activeScoreValue.text = "" + toShortNumber(GameManager.score).ToString("N1") + suffix;
                break;
            case 3:
                suffix = "B";
                activeScoreValue.text = "" + toShortNumber(GameManager.score).ToString("N1") + suffix;
                break;
        }
       

    }
    public void LoadInformation()
    {

        LoadPlayer();
        BumShopLoad();
        FurShopLoad();
        UpgShopLoad();
        SlideShowLoad();
        StartPanLoad();
        GameManager.score = PlayerPrefs.GetInt("score", 0);
        GameManager.gainOnClick = PlayerPrefs.GetInt("gainOnClick", 1 );
        GameManager.passiveGain = PlayerPrefs.GetInt("passiveGain", 0);
        startPanState = PlayerPrefs.GetInt("startPanState", 1);
        slideShowState = PlayerPrefs.GetInt("slideShowState", 1);




    }
    public void SlideShowDisable()
    {
        slideShow.SetActive(false);
        slideShowState = 0; 
        PlayerPrefs.SetInt("slideShowState", slideShowState);
    }
    public void startPanDisable()
{
    startPan.SetActive(false); 
    startPanState = 0; 
    PlayerPrefs.SetInt("startPanState", startPanState);
}
public void SlideShowLoad()
{
    if (slideShowState == 1)
    {
    slideShow.SetActive(true);
    }
    else
    {
        slideShow.SetActive(false);
    }
}
public void StartPanLoad()
{
    if (startPanState == 1)
    {
    startPan.SetActive(true);
    }
    else
    {
        startPan.SetActive(false);
    }
}


    public void Incriment()
    {
        
        GameManager.score += GameManager.gainOnClick;
        PlayerPrefs.SetInt("score", GameManager.score);
        ShowClick("" + GameManager.gainOnClick);
    }
    void ShowClick(string text)
{
    if (floatingText)
        {
            GameObject prefab = Instantiate (floatingText, new Vector3(transform.position.x, transform.position.y, -3), Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
        }
}
    IEnumerator ScorePerSec()
    {
        yield return new WaitForSeconds(1f);
        GameManager.score += GameManager.passiveGain;
        PlayerPrefs.SetInt("score", GameManager.score);
        StartCoroutine(ScorePerSec());

    }
    #region SuffixGetting Methods   
    public double toShortNumber(int number)
    {
        int mag = (int)(Math.Floor(Math.Log10(number)) / 3); // Truncates (усекать,округлять) to 6, divides to 2
        double divisor = Math.Pow(10, mag * 3);

        double shortNumber = number / divisor;

        return shortNumber;
    }
    public int toGetSuffix(int number)
    {
        int mag = (int)(Math.Floor(Math.Log10(number)) / 3); // Truncates (усекать,округлять) to 6, divides to 2
        double divisor = Math.Pow(10, mag * 3);

        double shortNumber = number / divisor;

        return mag;
    }
    #endregion

    #region Location menegment methods
    public void goingToLocation(int num)
    {
    switch (num)
    {
        case 1: //go to street screen
        Street.SetActive(true);
            Idle.SetActive(false);
            Room.SetActive(false);
            Home.SetActive(false);
            FurnitureShop.SetActive(false);
            Bums.SetActive(false);
            UpgradeShop.SetActive(false);
            BumsBuying.SetActive(false);
            Settings.SetActive(false);
            Bonus.SetActive(false);
            break;
        case 2: // go to home 
        {
            Street.SetActive(false);
            Room.SetActive(false);
            Home.SetActive(true);
            FurnitureShop.SetActive(false);
            Bums.SetActive(false);
            UpgradeShop.SetActive(false);
          
            BumsBuying.SetActive(false);
            Settings.SetActive(false);
            Bonus.SetActive(false);
            break;
        }
        case 3: // go to room
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
            break;
        }
        case 4: //go to FurShop
        {
            if (Idle.activeSelf == false)
            {  
            FurnitureShop.SetActive(true);
            UpgradeShop.SetActive(false);
            Settings.SetActive(false);
            Bonus.SetActive(false);
            break;
            }
            break;
            
        }
        case 5: //go to bums
        {
            if (Idle.activeSelf == false)
            {
            Street.SetActive(false);
            FurnitureShop.SetActive(false);
            Bums.SetActive(true);
            UpgradeShop.SetActive(false);
            BumsBuying.SetActive(false);
            Settings.SetActive(false);
            Bonus.SetActive(false);
            break;
            }
            break;
        }
        case 7://go to UpgradeShop
        {
           if (Idle.activeSelf == false)
           {
            
            FurnitureShop.SetActive(false);
           
            UpgradeShop.SetActive(true);
            
            Settings.SetActive(false);
            Bonus.SetActive(false);
            break;
           }
           break;
        }
        case 8: //go to BumsBuying
        {
            Street.SetActive(false);
            FurnitureShop.SetActive(false);
            Bums.SetActive(true);
            UpgradeShop.SetActive(false);
            BumsBuying.SetActive(true);
            Settings.SetActive(false);
            Bonus.SetActive(false);
            break;
        }
        case 9: //go to Setting
        {
            if (Idle.activeSelf == false)
            {
            Settings.SetActive(true);
            Bonus.SetActive(false);
            break;
            }
            break;
            
        }
        case 10: //go to bonus
        {
            if (Idle.activeSelf == false)
            {

            if (Street.activeSelf == true)
            {
            Bonus.SetActive(true);
            Street.SetActive(true);
            Room.SetActive(false);
            Home.SetActive(false);
            FurnitureShop.SetActive(false);
            Bums.SetActive(false);
            UpgradeShop.SetActive(false);
            BumsBuying.SetActive(false);
            Settings.SetActive(false);
            break;
            }
            if (Bums.activeSelf == true)
            {
                Bonus.SetActive(true);
            Street.SetActive(false);
            Room.SetActive(false);
            Home.SetActive(false);
            FurnitureShop.SetActive(false);
            Bums.SetActive(true);
            UpgradeShop.SetActive(false);
            BumsBuying.SetActive(false);
            Settings.SetActive(false);
            break;
            }
            }
            break;
        }
        case 11: //to off bonus
        {
            Bonus.SetActive(false);
            break;
        }
        case 12: //to off settings
        {
            Settings.SetActive(false);
            break;
        }
        case 13: //to off furShop
        {
            if (Room.activeSelf == true)
            {
                goto case 3;
            }
            if (Home.activeSelf == true)
            {
                goto case 2;
            }
            if (BumsBuying.activeSelf == true)
            {
               goto case 5;
            }
            if (Bums.activeSelf == true)
            {
                goto case 5;
            }
            if (Street.activeSelf == true)
            {
                goto case 1;
            }
            break;
        }
        }


    }
    public void LoadLocations()
    {
        Idle.SetActive(true);
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
    #endregion

    #region FurnitureShopMethods

    public void BuyFurniture(int home1room2)
    {
        if ((GameManager.score >= pricesFurniture[GameManager.curFurnitureItem]))
        {
        
            buyAudio.GetComponent<AudioSource>().Play();
            GameManager.score = GameManager.score - pricesFurniture[GameManager.curFurnitureItem];
            PlayerPrefs.SetInt("score", GameManager.score);
            changeFurnitureItem[GameManager.curFurnitureItem].transform.Find("Text").GetComponent<Text>().text = FurItemName[GameManager.curFurnitureItem];
            changeFurnitureItem [GameManager.curFurnitureItem].transform.Find("Image").GetComponent<Image>().sprite = FurShopSprites[GameManager.curFurnitureItem];
            changeFurnitureItem[GameManager.curFurnitureItem].transform.Find("Button").gameObject.SetActive(false);
            changeFurnitureItem[GameManager.curFurnitureItem + 1].transform.Find("Button").gameObject.SetActive(true);
            GameManager.curFurnitureItem++;
            PlayerPrefs.SetInt("curFurnitureItem", GameManager.curFurnitureItem);
        
            switch(home1room2)
            {
            case 1:
            
                changeHomeObj.GetComponent<Image>().sprite = homeFurniture[GameManager.curHomeFurniture];
                GameManager.curHomeFurniture++;
                PlayerPrefs.SetInt("curHomeFurniture", GameManager.curHomeFurniture);
                break;
            
            case 2:
            
                changeRoomObj.GetComponent<Image>().sprite = roomFurniture[GameManager.curRoomFurniture];
                GameManager.curRoomFurniture++;
                PlayerPrefs.SetInt("curRoomFurniture", GameManager.curRoomFurniture);
                break;
            
            case 3:
            
                changeRoomObj.GetComponent<Image>().sprite = roomFurniture[GameManager.curRoomFurniture];
                GameManager.curRoomFurniture++;
                PlayerPrefs.SetInt("curRoomFurniture", GameManager.curRoomFurniture);
                changeHomeObj.GetComponent<Image>().sprite = homeFurniture[GameManager.curHomeFurniture];
                GameManager.curHomeFurniture++;
                PlayerPrefs.SetInt("curHomeFurniture", GameManager.curHomeFurniture);
                break;
            }

        }
    }
    public void FurShopLoad()

    {
        GameManager.curFurnitureItem = PlayerPrefs.GetInt("curFurnitureItem", 0);
        GameManager.curRoomFurniture = PlayerPrefs.GetInt("curRoomFurniture", 0);
        GameManager.curHomeFurniture = PlayerPrefs.GetInt("curHomeFurniture", 0);
        if (GameManager.curHomeFurniture != 0)
        {
            for (int i = 0; i <= GameManager.curFurnitureItem - 1; i++)
            {
                changeFurnitureItem[i].transform.Find("Text").GetComponent<Text>().text = FurItemName[i];
                changeFurnitureItem[i].transform.Find("Image").GetComponent<Image>().sprite = FurShopSprites[i];
                changeFurnitureItem[i].transform.Find("Button").gameObject.SetActive(false);
                changeFurnitureItem[i + 1].transform.Find("Button").gameObject.SetActive(true);
            }

        }
        if (GameManager.curHomeFurniture > 0 && GameManager.curRoomFurniture > 0)
        {
            changeHomeObj.GetComponent<Image>().sprite = homeFurniture[GameManager.curHomeFurniture -1];
            changeRoomObj.GetComponent<Image>().sprite = roomFurniture[GameManager.curRoomFurniture -1];
        }
    }
    #endregion

    #region BumShop methods
    public void BuyBum(int bum)
    {
        buyAudio.GetComponent<AudioSource>().Play();
        switch (bum)
        {
            case 0:
                if (bumsLevels[bum] == 0 && pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator1(bum);
                    break;
                }
                else if (pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator2(bum);
                    break;
                }
                else
                {
                    break;
                }
            case 1:
                if (bumsLevels[bum] == 0 && pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator1(bum);
                    break;
                }
                else if (pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator2(bum);
                    break;
                }
                else
                {
                    break;
                }
            case 2:
                if (bumsLevels[bum] == 0 && pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator1(bum);
                    break;
                }
                else if (pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator2(bum);
                    break;
                }
                else
                {
                    break;
                }
            case 3:
                if (bumsLevels[bum] == 0 && pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator1(bum);
                    break;
                }
                else if (pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator2(bum);
                    break;
                }
                else
                {
                    break;
                }
            case 4:
                if (bumsLevels[bum] == 0 && pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator1(bum);
                    break;
                }
                else if (pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator2(bum);
                    break;
                }
                else
                {
                    break;
                }
            case 5:
                if (bumsLevels[bum] == 0 && pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator1(bum);
                    break;
                }
                else if (pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator2(bum);
                    break;
                }
                else
                {
                    break;
                }
            case 6:
                if (bumsLevels[bum] == 0 && pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator1(bum);
                    break;
                }
                else if (pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator2(bum);
                    break;
                }
                else
                {
                    break;
                }
            case 7:
                if (bumsLevels[bum] == 0 && pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator1(bum);
                    break;
                }
                else if (pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator2(bum);
                    break;
                }
                else
                {
                    break;
                }
            case 8:
                if (bumsLevels[bum] == 0 && pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator1(bum);
                    break;
                }
                else if (pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator2(bum);
                    break;
                }
                else
                {
                    break;
                }
            case 9:
                if (bumsLevels[bum] == 0 && pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator1(bum);
                    break;
                }
                else if (pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator2(bum);
                    break;
                }
                else
                {
                    break;
                }
            case 10:
                if (bumsLevels[bum] == 0 && pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator1(bum);
                    break;
                }
                else if (pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator2(bum);
                    break;
                }
                else
                {
                    break;
                }
            case 11:
                if (bumsLevels[bum] == 0 && pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator1(bum);
                    break;
                }
                else if (pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator2(bum);
                    break;
                }
                else
                {
                    break;
                }
            case 12:
                if (bumsLevels[bum] == 0 && pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator1(bum);
                    break;
                }
                else if (pricesBums[bum] <= GameManager.score)
                {
                    BumManipulator2(bum);
                    break;
                }
                else
                {
                    break;
                }

        }

    }
    public void BumManipulator1(int bum)
    {
        GameManager.score = GameManager.score - Convert.ToInt32 (pricesBums[bum]);
        PlayerPrefs.SetInt("score", GameManager.score);
        GameManager.passiveGain = GameManager.passiveGain + bumsGains[bum];
        PlayerPrefs.SetInt("passiveGain", GameManager.passiveGain);
        bumsLevels[bum]++;
        pricesBums[bum] = pricesBums[bum] * 1.3;
        switch (toGetSuffix(Convert.ToInt32(pricesBums[bum])))
        {
            case 0:
                suffix = string.Empty;
                changeBumItem[bum].transform.Find("Text (1)").GetComponent<Text>().text = ("" + Math.Round (pricesBums[bum]) + suffix);                break;
            case 1:
                suffix = string.Empty;
                changeBumItem[bum].transform.Find("Text (1)").GetComponent<Text>().text = ("" + Math.Round (pricesBums[bum]) + suffix);                break;
            case 2:
                suffix = "M";
                changeBumItem[bum].transform.Find("Text (1)").GetComponent<Text>().text = ("" + Math.Round (toShortNumber(Convert.ToInt32 (pricesBums[bum]))) + suffix);                break;
            case 3:
                suffix = "B";
                changeBumItem[bum].transform.Find("Text (1)").GetComponent<Text>().text = ("" + Math.Round (toShortNumber(Convert.ToInt32 (pricesBums[bum]))) + suffix);                break;
        }
        SavePlayer();
        changeBumItem[bum].transform.Find("Text").GetComponent<Text>().text = BumItemName[bum];
        changeBumItem[bum].transform.Find("Texx").GetComponent<Text>().text = ("Ур: " + bumsLevels[bum]);
       
        changeBumItem[bum].transform.Find("Image").GetComponent<Image>().sprite = BumShopSprites[bum];
        changeBumItem[bum + 1].transform.Find("Button").gameObject.SetActive(true);
        GameManager.curBumItem++;
        PlayerPrefs.SetInt("curBumItem", GameManager.curBumItem);
    }
    public void BumManipulator2(int bum)
    {
        GameManager.score = GameManager.score - Convert.ToInt32 (pricesBums[bum]);
        PlayerPrefs.SetInt("score", GameManager.score);
        GameManager.passiveGain = GameManager.passiveGain + bumsGains[bum];
        PlayerPrefs.SetInt("passiveGain", GameManager.passiveGain);
        bumsLevels[bum]++;
        SavePlayer();
        pricesBums[bum] = pricesBums[bum] * 1.3;
        switch (toGetSuffix(Convert.ToInt32(pricesBums[bum])))
        {
            case 0:
                suffix = string.Empty;
                 changeBumItem[bum].transform.Find("Text (1)").GetComponent<Text>().text = ("" + Math.Round (pricesBums[bum]) + suffix);                break;
            case 1:
                suffix = string.Empty;
                 changeBumItem[bum].transform.Find("Text (1)").GetComponent<Text>().text = ("" + Math.Round (pricesBums[bum]) + suffix);                break;
            case 2:
                suffix = "M";
                changeBumItem[bum].transform.Find("Text (1)").GetComponent<Text>().text = ("" +Math.Round (toShortNumber(Convert.ToInt32 (pricesBums[bum]))) + suffix);                break;
            case 3:
                suffix = "B";
                changeBumItem[bum].transform.Find("Text (1)").GetComponent<Text>().text = ("" + Math.Round (toShortNumber(Convert.ToInt32 (pricesBums[bum]))) + suffix);                break;
        }
        SavePlayer();
        changeBumItem[bum].transform.Find("Texx").GetComponent<Text>().text = ("Ур: " + bumsLevels[bum]);
    }
    public void BumShopLoad()
    {

        GameManager.curBumItem = PlayerPrefs.GetInt("curBumItem", 0);

        if (GameManager.curBumItem != 0)
        {
            for (int i = 0; i < GameManager.curBumItem; i++)
            {
                changeBumItem[i].transform.Find("Text").GetComponent<Text>().text = BumItemName[i];
                changeBumItem[i].transform.Find("Text (1)").GetComponent<Text>().text = ($"{pricesBums[i]}");
                changeBumItem[i].transform.Find("Texx").GetComponent<Text>().text = ("Ур: " + bumsLevels[i]);
                changeBumItem[i].transform.Find("Image").GetComponent<Image>().sprite = BumShopSprites[i];
                changeBumItem[i + 1].transform.Find("Button").gameObject.SetActive(true);
            }
        }
    }
    #endregion

    #region UpgradeShop Methods
    public void BuyUpgrades(int upg)
    {
        buyAudio.GetComponent<AudioSource>().Play();
        switch (upg)
        {
            case 0:
                if (upgLevels[upg] == 0 && pricesUpgrades[upg] <= GameManager.score)
                {

                    BuyManipulator1(upg);
                    break;
                }
                else if (pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator2(upg);
                    break;
                }
                else
                {
                    break;
                }
            case 1:
                if (upgLevels[upg] == 0 && pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator1(upg);
                    break;
                }
                else if (pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator2(upg);
                    break;
                }
                else
                {
                    break;
                }
            case 2:
                if (upgLevels[upg] == 0 && pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator1(upg);
                    break;
                }
                else if (pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator2(upg);
                    break;
                }
                else
                {
                    break;
                }
            case 3:
                if (upgLevels[upg] == 0 && pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator1(upg);
                    break;
                }
                else if (pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator2(upg);
                    break;
                }
                else
                {
                    break;
                }
            case 4:
                if (upgLevels[upg] == 0 && pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator1(upg);
                    break;
                }
                else if (pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator2(upg);
                    break;
                }
                else
                {
                    break;
                }
            case 5:
                if (upgLevels[upg] == 0 && pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator1(upg);
                    break;
                }
                else if (pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator2(upg);
                    break;
                }
                else
                {
                    break;
                }
            case 6:
                if (upgLevels[upg] == 0 && pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator1(upg);
                    break;
                }
                else if (pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator2(upg);
                    break;
                }
                else
                {
                    break;
                }
            case 7:
                if (upgLevels[upg] == 0 && pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator1(upg);
                    break;
                }
                else if (pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator2(upg);
                    break;
                }
                else
                {
                    break;
                }
            case 8:
                if (upgLevels[upg] == 0 && pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator1(upg);
                    break;
                }
                else if (pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator2(upg);
                    break;
                }
                else
                {
                    break;
                }
            case 9:
                if (upgLevels[upg] == 0 && pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator1(upg);
                    break;
                }
                else if (pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator2(upg);
                    break;
                }
                else
                {
                    break;
                }
            case 10:
                if (upgLevels[upg] == 0 && pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator1(upg);
                    break;
                }
                else if (pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator2(upg);
                    break;
                }
                else
                {
                    break;
                }
            case 11:
                if (upgLevels[upg] == 0 && pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator1(upg);
                    break;
                }
                else if (pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator2(upg);
                    break;
                }
                else
                {
                    break;
                }
            case 12:
                if (upgLevels[upg] == 0 && pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator1(upg);
                    break;
                }
                else if (pricesUpgrades[upg] <= GameManager.score)
                {
                    BuyManipulator2(upg);
                    break;
                }
                else
                {
                    break;
                }
        }

    }
    public void BuyManipulator1(int upg)
    {
        GameManager.score = GameManager.score - pricesUpgrades[upg];
        PlayerPrefs.SetInt("score", GameManager.score);
        GameManager.gainOnClick = GameManager.gainOnClick + upgClickGains[upg];
        PlayerPrefs.SetInt("gainOnClick", GameManager.gainOnClick);
        pricesUpgrades[upg] = pricesUpgrades[upg] * 130 / 100;
        SavePlayer();
        print(pricesUpgrades[upg]);
        upgLevels[upg]++;
        SavePlayer();
        changeUpgradeItem[upg].transform.Find("Text").GetComponent<Text>().text = UpgItemName[upg];
        changeUpgradeItem[upg].transform.Find("Text (2)").GetComponent<Text>().text = ("Ур: " + upgLevels[upg]);
        changeUpgradeItem[upg].transform.Find("Text (1)").GetComponent<Text>().text = ($"{pricesUpgrades[upg]}");
        changeUpgradeItem[upg].transform.Find("Image").GetComponent<Image>().sprite = UpgShopSprites[upg];
        changeUpgradeItem[upg + 1].transform.Find("Button").gameObject.SetActive(true);
        GameManager.curUpgItem++;
        PlayerPrefs.SetInt("curUpgItem", GameManager.curUpgItem);
    }

    public void BuyManipulator2(int upg)
    {
        GameManager.score = GameManager.score - pricesUpgrades[upg];
        PlayerPrefs.SetInt("score", GameManager.score);
        GameManager.gainOnClick = GameManager.gainOnClick + upgClickGains[upg];
        PlayerPrefs.SetInt("gainOnClick", GameManager.gainOnClick);
        pricesUpgrades[upg] = pricesUpgrades[upg] * 130 / 100;
        SavePlayer();
        upgLevels[upg]++;
        SavePlayer();

        changeUpgradeItem[upg].transform.Find("Text (2)").GetComponent<Text>().text = ("Ур: " + upgLevels[upg]);
        changeUpgradeItem[upg].transform.Find("Text (1)").GetComponent<Text>().text = ($"{pricesUpgrades[upg]}");
    }

    public void UpgShopLoad()
    {

        GameManager.curUpgItem = PlayerPrefs.GetInt("curUpgItem", 0);

        if (GameManager.curUpgItem != 0)
        {
            for (int i = 0; i < GameManager.curUpgItem; i++)
            {
                changeUpgradeItem[i].transform.Find("Text").GetComponent<Text>().text = UpgItemName[i];
                changeUpgradeItem[i].transform.Find("Text (2)").GetComponent<Text>().text = ("Ур: " + upgLevels[i]);
                changeUpgradeItem[i].transform.Find("Text (1)").GetComponent<Text>().text = ($"{pricesUpgrades[i]}");
                changeUpgradeItem[i].transform.Find("Image").GetComponent<Image>().sprite = UpgShopSprites[i];
                changeUpgradeItem[i + 1].transform.Find("Button").gameObject.SetActive(true);
            }
        }
    }

    #endregion

    #region Saving
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        for (int i = 0; i < 13; i++)
        {
            bumsLevels[i] = data.LevelsOfBums[i];
        }

        for (int i = 0; i < 13; i++)
        {
            pricesBums[i] = data.PricesOfBums[i];
        }

        for (int i = 0; i < 13; i++)
        {
            upgLevels[i] = data.LevelsOfUpgrades[i];
        }

        for (int i = 0; i < 13; i++)
        {
            pricesUpgrades[i] = data.pricesOfUpgrades[i];
        }
        
    }
    public void DeletePlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        for (int i = 0; i < 13; i++)
        {
            bumsLevels[i] = 0;
        }

        for (int i = 0; i < 13; i++)
        {
            pricesBums[i] = startingPricesOfBums[i];
        }

        for (int i = 0; i < 13; i++)
        {
            upgLevels[i] = 0;
        }

        for (int i = 0; i < 13; i++)
        {
            pricesUpgrades[i] = startingPricesOfUpgrades[i];
        }

        SavePlayer();
    }


    #endregion

}





