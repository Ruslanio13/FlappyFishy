using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private ItemsInStore itemList;
    [SerializeField] private ItemView itemView;


    private void Awake()
    {
        var items = itemList.ItemsList;
        for(int i = 0; i < items.Count; i++)
        {
            var spawnedItem = Instantiate(itemView, transform);
            spawnedItem.GetComponent<ItemView>().Initialize(items[i]);
        }

    }
}
