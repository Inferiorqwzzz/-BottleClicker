using System.Collections.Generic;
using UnityEngine;
 
public class LocalizationSystem : MonoBehaviour
{
    public enum Language
    {
        English,
        Russian
    }
 
    public static Language language = Language.Russian;
 
    public static Dictionary<string, string> localisedEN;
    public static Dictionary<string, string> localisedRU;
 
    public static bool isInit;
 
    public static void Init()
    {
        CSVLoader csvLoader = new CSVLoader();
        csvLoader.LoadCSV();
 
        localisedEN = csvLoader.GetDictionaryValues("en");
        localisedRU = csvLoader.GetDictionaryValues("ru");
 
        isInit = true;
    }
 
    public static string GetLocalisedValue(string key)
    {
        if (!isInit) { Init(); }
 
        string value = key;
 
        switch(language)
        {
            case Language.English:
                localisedEN.TryGetValue(key, out value);
                break;
            case Language.Russian:
                localisedRU.TryGetValue(key, out value);
                break;
        }
 
        return value;
    }
}
