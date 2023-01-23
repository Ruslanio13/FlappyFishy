using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    [SerializeField] private ItemsInStore itemList;
    [SerializeField] private ItemView itemView;
    private List<ItemView> spawnedItems = new List<ItemView>();


    private void Awake()
    {
        if (instance == null)
            instance = this;

        var items = itemList.ItemsList;
        for(int i = 0; i < items.Count; i++)
        {
            var spawnedItem = Instantiate(itemView, transform);
            spawnedItems.Add(spawnedItem.GetComponent<ItemView>());
            spawnedItem.GetComponent<ItemView>().Initialize(items[i]);
        }
        ShowSelectedSkin();
    }

    public void ShowSelectedSkin()
    {
        var selectedSkinId = PlayerPrefs.GetInt("SelectedSkinId");
        for (int i = 0; i < spawnedItems.Count; i++)
            spawnedItems[i].MakeSkinSelected(selectedSkinId == i);
    }
}
