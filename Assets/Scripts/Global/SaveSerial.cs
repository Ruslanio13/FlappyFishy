using System.Collections.Generic;
using UnityEngine;

public class SaveSerial : MonoBehaviour
{
    protected List<Item> ListOfItemsInStore;
    protected void SaveGame()
    {
        PlayerPrefs.Save();
    }

    protected void LoadGame()
    {
        ListOfItemsInStore = Resources.Load<ItemsInStore>("ScriptableObjects/ItemsInStore").ItemsList;
        if (!PlayerPrefs.HasKey("Skin0"))
        {
            PlayerPrefs.SetInt("Skin0", 1);
            for(int i = 1; i < ListOfItemsInStore.Count; i++)
                PlayerPrefs.SetInt("Skin" + i, 0);
            PlayerPrefs.SetInt("SelectedSkinId", 0);
        }
        SkinManager.Instance.Initialize(PlayerPrefs.GetInt("SelectedSkinId"));
    }
}
