using System;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    [SerializeField] private List<ItemsInStore> itemScreens;
    [SerializeField] private ItemsInStore itemList;
    [SerializeField] private ItemView itemView;
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
        Debug.Log(itemList.NextListName);
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
        Debug.Log(itemList.PreviousListName);
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
    }
    
    public void ShowSelectedItems()
    {
        foreach (var item in spawnedItems)
            item.UpdateSelection();
    }
}
