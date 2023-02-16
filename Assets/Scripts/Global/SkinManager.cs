using System;
using UnityEngine;
using UnityEngine.Events;

public class SkinManager : SaveSerial
{
    private Sprite _skin;
    public Item SelectedSkin { get; private set; }
    public Item SelectedHat { get; private set; }
    public Item SelectedMoustache { get; private set; }
	public Item SelectedGlasses { get; private set; }
    public Item SelectedColor { get; private set; }

    public UnityAction onSkinChanged;
    
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

    public void Initialize()
    {
        SelectedSkin = ListOfSkinsInStore[PlayerPrefs.GetInt("SelectedSKIN")];
		SelectedHat = ListOfHatsInStore[PlayerPrefs.GetInt("SelectedHAT")];
		SelectedMoustache = ListOfMoustacheInStore[PlayerPrefs.GetInt("SelectedMOUSTACHE")];
		SelectedGlasses = ListOfGlassesInStore[PlayerPrefs.GetInt("SelectedGLASSES")];
        SelectedColor = ListOfColorsInStore[PlayerPrefs.GetInt("SelectedCOLOR")];
        PlayerPrefs.SetInt("SKIN" + PlayerPrefs.GetInt("SelectedSKIN"), 1);
    }

    public void AddItem(int id, Item item)
    {
        if (PlayerPrefs.GetInt(item.Type.ToString() + id) == 1)
            throw new Exception(item.Type + " was already bought!");
        PlayerPrefs.SetInt(item.Type.ToString() + id, 1);
    }

    public void SelectItem(int id, Item item)
    {
        if (PlayerPrefs.GetInt(item.Type.ToString() + id) != 1)
            throw new Exception("Trying to select not bought item!");
        PlayerPrefs.SetInt("Selected" + item.Type, id);
        switch (item.Type)
        {
            case Item.TYPE.HAT:
                SelectedHat = item; 
                break;
            case Item.TYPE.SKIN:
                SelectedSkin = item; 
                break;
            case Item.TYPE.GLASSES:
                SelectedGlasses = item; 
                break;
            case Item.TYPE.MOUSTACHE:
                SelectedMoustache = item; 
                break;
            case Item.TYPE.COLOR:
                SelectedColor = item; 
                break;
        }
        onSkinChanged?.Invoke();
    }
    public void OnDestroy()
    {
        SaveGame();
    }
    
}
