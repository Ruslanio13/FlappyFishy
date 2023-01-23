using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

public class SaveSerial : MonoBehaviour
{
    private static Sprite _defaultSprite;
    protected string SavePath;
    protected List<Item> ListOfItemsInStore;
    protected void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Create(SavePath);
        SaveData saveData = new SaveData
        {
            boughtSkins = SkinManager.Instance.IsSkinBought,
            selectedSkinId = SkinManager.Instance.SelectedSkinId
        };

        bf.Serialize(fileStream,saveData);
        fileStream.Close();
        
        Debug.Log("Game Was Saved");
    }

    protected void LoadGame()
    {
        ListOfItemsInStore = Resources.Load<ItemsInStore>("ScriptableObjects/ItemsInStore").ItemsList;
        if (File.Exists(SavePath))
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(SavePath, FileMode.Open);
                SaveData saveData = (SaveData)bf.Deserialize(file);
                file.Close();
                SkinManager.Instance.Initialize(saveData.boughtSkins, saveData.selectedSkinId);
                Debug.Log("Game Data Loaded!");
            }
            catch(SerializationException)
            {
                SkinManager.Instance.Initialize(new bool[ListOfItemsInStore.Count], 0);
            }
        }
        else
        {
            Debug.Log("No Save File!");
            SkinManager.Instance.Initialize(new bool[ListOfItemsInStore.Count], 0);
        }
    }
}

[Serializable]
public class SaveData
{ 
    public bool[] boughtSkins;
    public int selectedSkinId;
}
