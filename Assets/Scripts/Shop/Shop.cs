using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    [SerializeField] private List<ItemsInStore> itemScreens;
    [SerializeField] private ItemsInStore itemList;
    [SerializeField] private ItemView itemView;
    [SerializeField] private Sprite[] buttonIcons;
    [SerializeField] private Image NextListButton;
    [SerializeField] private Image PrevListButton;
    private List<ItemView> spawnedItems = new List<ItemView>();
    private int _selectedScreen;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        InitializeShop();
    }

    public void GoToNextScreen()
    {
        PlayerPrefs.Save();
        if (_selectedScreen < itemScreens.Count - 1)
            _selectedScreen++;
        else
            _selectedScreen = 0;
        itemList = itemScreens[_selectedScreen];
        InitializeShop();
    }

    public void GoToPreviousScreen()
    {
        PlayerPrefs.Save();
        if (_selectedScreen > 0)
            _selectedScreen--;
        else
            _selectedScreen = itemScreens.Count - 1;
        itemList = itemScreens[_selectedScreen];
        InitializeShop();
    }

    private void InitializeShop()
    {
        var items = itemList.ItemsList;
        
        foreach (var item in spawnedItems)
            Destroy(item.gameObject);
        spawnedItems.Clear();
                
        for(int i = 0; i < items.Count; i++)
        {
            var spawnedItem = Instantiate(itemView, transform);
            spawnedItems.Add(spawnedItem.GetComponent<ItemView>());
            spawnedItem.GetComponent<ItemView>().Initialize(items[i]);
        }
        ShowSelectedItems();
        UpdateButtonsIcon(_selectedScreen);
    }
    
    public void ShowSelectedItems()
    {
        foreach (var item in spawnedItems)
            item.UpdateSelection();
    }

    private void UpdateButtonsIcon(int currentListIndex)
    {
        NextListButton.sprite = buttonIcons[currentListIndex == buttonIcons.Length - 1 ? 0 : currentListIndex + 1];
        PrevListButton.sprite = buttonIcons[currentListIndex == 0 ? buttonIcons.Length - 1 : currentListIndex - 1];
    }
}
