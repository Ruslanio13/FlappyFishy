using System;
using UnityEngine;

public class SkinManager : SaveSerial
{
    private Sprite _skin;
    public Sprite SelectedSkin { get; private set; }
    
    public static SkinManager Instance;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);        
        
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        LoadGame();
    }

    public void Initialize(int selectedSkinId)
    {
        SelectedSkin = ListOfItemsInStore[selectedSkinId].Icon;
        PlayerPrefs.SetInt("Skin" + selectedSkinId, 1);
    }

    public void AddSkin(int id)
    {
        if (PlayerPrefs.GetInt("Skin" + id) == 1)
            throw new Exception("Skin was Already Bought");
        PlayerPrefs.SetInt("Skin" + id, 1);
    }

    public void SelectSkin(int id)
    {
        if (PlayerPrefs.GetInt("Skin" + id) != 1)
            throw new Exception("Trying to select not bought skin");
        PlayerPrefs.SetInt("SelectedSkinId", id);
        SelectedSkin = ListOfItemsInStore[id].Icon;
    }
    public void OnDestroy()
    {
        SaveGame();
    }
    
}
