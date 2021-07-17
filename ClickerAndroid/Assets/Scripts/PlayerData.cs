using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
public int[] LevelsOfBums;
public int[] PricesOfBums;

public PlayerData (MainScript mainScript)
{
LevelsOfBums = new int[13];
for (int i = 0; i < 13; i++)
{
   LevelsOfBums[i] = mainScript.bumsLevels[i]; 
}
PricesOfBums = new int [13];
for (int i = 0; i < 13; i++)
{
   PricesOfBums[i] = mainScript.pricesBums[i]; 
}

}

}
