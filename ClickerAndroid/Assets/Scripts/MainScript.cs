using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainScript : MonoBehaviour
{
    #region Variables declaration 
    public Text activeScoreValue, passiveScoreValue;
    public GameObject Street, Room, Home, FurnitureShop, Bums, UpgradeShop, BumsBuying, Settings, Bonus;
    public Sprite[] roomFurniture, homeFurniture, FurShopSprites, BumShopSprites, UpgShopSprites;
    public string[] FurItemName, UpgItemName, BumItemName;
    public GameObject changeRoomObj, changeHomeObj;
    public int[] pricesFurniture, pricesUpgrades, startingPricesOfUpgrades, pricesBums, startingPricesOfBums;

    public int[] bumsGains, upgClickGains;
    public GameObject[] changeFurnitureItem, changeUpgradeItem, changeBumItem;

    public int[] bumsLevels = new int[13];
    public int[] upgLevels = new int[13];

    string suffix;
    #endregion
    void Start()
    {
        StartCoroutine(ScorePerSec());
        LoadInformation();
        LoadLocations();

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
        GameManager.score = PlayerPrefs.GetInt("score", 0);
        GameManager.gainOnClick = PlayerPrefs.GetInt("gainOnClick", 1);
        GameManager.passiveGain = PlayerPrefs.GetInt("passiveGain", 0);





    }
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
    public void BuyHome()
    {
        if ((GameManager.score >= pricesFurniture[GameManager.curFurnitureItem]))
        {
            changeHomeObj.GetComponent<Image>().sprite = homeFurniture[GameManager.curHomeFurniture];
            GameManager.curHomeFurniture++;
            PlayerPrefs.SetInt("curHomeFurniture", GameManager.curHomeFurniture);
        }
    }
    public void BuyRoom()
    {
        if ((GameManager.score >= pricesFurniture[GameManager.curFurnitureItem]))
        {
            changeRoomObj.GetComponent<Image>().sprite = roomFurniture[GameManager.curRoomFurniture];
            GameManager.curRoomFurniture++;
            PlayerPrefs.SetInt("curRoomFurniture", GameManager.curRoomFurniture);
        }

    }
    public void BuyFurniture()
    {
        if ((GameManager.score >= pricesFurniture[GameManager.curFurnitureItem]))
        {
            GameManager.score = GameManager.score - pricesFurniture[GameManager.curFurnitureItem];
            PlayerPrefs.SetInt("score", GameManager.score);
            changeFurnitureItem[GameManager.curFurnitureItem].transform.Find("Text").GetComponent<Text>().text = FurItemName[GameManager.curFurnitureItem];
            changeFurnitureItem[GameManager.curFurnitureItem].transform.Find("Image").GetComponent<Image>().sprite = FurShopSprites[GameManager.curFurnitureItem];
            changeFurnitureItem[GameManager.curFurnitureItem].transform.Find("Button").gameObject.SetActive(false);
            changeFurnitureItem[GameManager.curFurnitureItem + 1].transform.Find("Button").gameObject.SetActive(true);
            GameManager.curFurnitureItem++;
            //changeFurnitureItem[GameManager.curFurnitureItem].transform.Find("Text (1)").gameObject.SetActive(false);
            //changeFurnitureItem[GameManager.curFurnitureItem].transform.Find("Image (1)").gameObject.SetActive(false);
            PlayerPrefs.SetInt("curFurnitureItem", GameManager.curFurnitureItem);
        }
    }
    public void FurShopLoad()

    {
        GameManager.curFurnitureItem = PlayerPrefs.GetInt("curFurnitureItem", 0);
        GameManager.curRoomFurniture = PlayerPrefs.GetInt("curRoomFurniture", 0);
        GameManager.curHomeFurniture = PlayerPrefs.GetInt("curHomeFurniture", 0);
        if (GameManager.curHomeFurniture != 0)
        {
            for (int i = 0; i <= GameManager.curFurnitureItem; i++)
            {
                changeFurnitureItem[i].transform.Find("Text").GetComponent<Text>().text = FurItemName[i];
                changeFurnitureItem[i].transform.Find("Image").GetComponent<Image>().sprite = FurShopSprites[i];
                changeFurnitureItem[i].transform.Find("Button").gameObject.SetActive(false);
                changeFurnitureItem[i + 1].transform.Find("Button").gameObject.SetActive(true);
            }

        }
        if (GameManager.curHomeFurniture > 0 && GameManager.curRoomFurniture > 0)
        {
            changeHomeObj.GetComponent<Image>().sprite = homeFurniture[GameManager.curHomeFurniture];
            changeRoomObj.GetComponent<Image>().sprite = roomFurniture[GameManager.curRoomFurniture];
        }
    }
    #endregion

    #region BumShop methods
    public void BuyBum(int bum)
    {
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
        GameManager.score = GameManager.score - pricesBums[bum];
        PlayerPrefs.SetInt("score", GameManager.score);
        GameManager.passiveGain = GameManager.passiveGain + bumsGains[bum];
        PlayerPrefs.SetInt("passiveGain", GameManager.passiveGain);
        bumsLevels[bum]++;
        SavePlayer();
        pricesBums[bum] = pricesBums[bum] * 107 / 100;
        SavePlayer();
        changeBumItem[bum].transform.Find("Text").GetComponent<Text>().text = BumItemName[bum];
        changeBumItem[bum].transform.Find("Texx").GetComponent<Text>().text = ("Ур: " + bumsLevels[bum]);
        changeBumItem[bum].transform.Find("Text (1)").GetComponent<Text>().text = ($"{pricesBums[bum]}");
        changeBumItem[bum].transform.Find("Image").GetComponent<Image>().sprite = BumShopSprites[bum];
        changeBumItem[bum + 1].transform.Find("Button").gameObject.SetActive(true);
        GameManager.curBumItem++;
        PlayerPrefs.SetInt("curBumItem", GameManager.curBumItem);
    }
    public void BumManipulator2(int bum)
    {
        GameManager.score = GameManager.score - pricesBums[bum];
        PlayerPrefs.SetInt("score", GameManager.score);
        GameManager.passiveGain = GameManager.passiveGain + bumsGains[bum];
        PlayerPrefs.SetInt("passiveGain", GameManager.passiveGain);
        bumsLevels[bum]++;
        SavePlayer();
        pricesBums[bum] = pricesBums[bum] * 107 / 100;
        SavePlayer();
        changeBumItem[bum].transform.Find("Texx").GetComponent<Text>().text = ("Ур: " + bumsLevels[bum]);
        changeBumItem[bum].transform.Find("Text (1)").GetComponent<Text>().text = ($"{pricesBums[bum]}");
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

    public void BuyUpgrades(int upg)
    {
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




