using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SkinManager : SaveSerial
{
    private Sprite _skin;

    public bool[] IsSkinBought { get; private set; }
    public Sprite SelectedSkin { get; private set; }
    public int SelectedSkinId { get; private set; }
    
    public static SkinManager Instance;
    
    private void Awake()
    {
        SavePath = Application.persistentDataPath + "/MySaveData.dat";
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

    public void Initialize(bool[] boughtSkins, int selectedSkinId)
    {
        IsSkinBought = boughtSkins;
        SelectedSkinId = selectedSkinId;
        SelectedSkin = ListOfItemsInStore[selectedSkinId].Icon;
        IsSkinBought[SelectedSkinId] = true;
    }

    public void AddSkin(int id)
    {
        if (IsSkinBought[id])
            throw new Exception("Skin was Already Bought");
        IsSkinBought[id] = true;
    }

    public void SelectSkin(int id)
    {
        if (!IsSkinBought[id])
            throw new Exception("Trying to select not bought skin");
        SelectedSkinId = id;
        SelectedSkin = ListOfItemsInStore[SelectedSkinId].Icon;
    }
    public void OnDestroy()
    {
        SaveGame();
    }
    
}
