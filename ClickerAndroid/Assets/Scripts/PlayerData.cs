using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
public int[] LevelsOfBums;
public double[] PricesOfBums;

public int [] pricesOfUpgrades;
public int [] LevelsOfUpgrades;

public PlayerData (MainScript mainScript)
{
LevelsOfBums = new int[13];
for (int i = 0; i < 13; i++)
{
   LevelsOfBums[i] = mainScript.bumsLevels[i]; 
}

PricesOfBums = new double [13];
for (int i = 0; i < 13; i++)
{
   PricesOfBums[i] = mainScript.pricesBums[i]; 
}

LevelsOfUpgrades = new int[13];
for (int i = 0; i < 13; i++)
{
   LevelsOfUpgrades[i] = mainScript.upgLevels[i];
}
pricesOfUpgrades = new int[13];
for (int i = 0; i < 13; i++)
{
   pricesOfUpgrades[i] = mainScript.pricesUpgrades[i];
}


}

}


