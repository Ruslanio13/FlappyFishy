using System.Collections.Generic;
using UnityEngine;

public class SaveSerial : MonoBehaviour
{
    protected List<Item> ListOfSkinsInStore;
    protected List<Item> ListOfGlassesInStore;
    protected List<Item> ListOfMoustacheInStore;
    protected List<Item> ListOfHatsInStore;
    protected List<Item> ListOfColorsInStore;
    protected Dictionary<int, Item> FishColors;
    protected void SaveGame()
    {
        PlayerPrefs.Save();
    }

    protected void LoadGame()
    {
        ListOfSkinsInStore = Resources.Load<ItemsInStore>("ScriptableObjects/SkinsInStore").ItemsList;
        ListOfHatsInStore = Resources.Load<ItemsInStore>("ScriptableObjects/HatsInStore").ItemsList;
        ListOfMoustacheInStore = Resources.Load<ItemsInStore>("ScriptableObjects/MoustacheInStore").ItemsList;
        ListOfGlassesInStore = Resources.Load<ItemsInStore>("ScriptableObjects/GlassesInStore").ItemsList;
        ListOfColorsInStore = Resources.Load<ItemsInStore>("ScriptableObjects/ColorsInStore").ItemsList;
        if (!PlayerPrefs.HasKey("SKIN0"))
        {
            PlayerPrefs.SetInt("SKIN0", 1);
            PlayerPrefs.SetInt("HAT0", 1);
            PlayerPrefs.SetInt("MOUSTACHE0", 1);
            PlayerPrefs.SetInt("GLASSES0", 1);
            PlayerPrefs.SetInt("COLOR0", 1);
            
            for(int i = 1; i < ListOfSkinsInStore.Count; i++)
                PlayerPrefs.SetInt("SKIN" + i, 0);
            for(int i = 1; i < ListOfHatsInStore.Count; i++)
                PlayerPrefs.SetInt("HAT" + i, 0);
            for(int i = 1; i < ListOfMoustacheInStore.Count; i++)
                PlayerPrefs.SetInt("MOUSTACHE" + i, 0);
            for(int i = 1; i < ListOfGlassesInStore.Count; i++)
                PlayerPrefs.SetInt("GLASSES" + i, 0);
            for(int i = 1; i < ListOfColorsInStore.Count; i++)
                PlayerPrefs.SetInt("COLORS" + i, 0);
            
            PlayerPrefs.SetInt("SelectedSKIN", 0);
            PlayerPrefs.SetInt("SelectedHAT", 0);
            PlayerPrefs.SetInt("SelectedMOUSTACHE", 0);
            PlayerPrefs.SetInt("SelectedGLASSES", 0);
            PlayerPrefs.SetInt("SelectedCOLOR", 0);
        }
        SkinManager.Instance.Initialize();
    }
}
