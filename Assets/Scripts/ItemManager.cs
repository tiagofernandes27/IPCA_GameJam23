using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public Array levelItems;
    public List<Item> inventory;
   
    public TextMeshProUGUI textUI;

    private void Start()
    {
        inventory = new List<Item>();

        levelItems = FindObjectsOfType<Item>();

        
    }

    private void Update()
    {
        foreach(Item item in levelItems)
        {
            if (item.hasBeenCollected && item.added == false)
            {
                inventory.Add(item);
                Debug.Log("Item Added to inventory");
                item.added = true;
                textUI.text = (item.itemName);
            }

            if (item.hasBeenUsed && item.added == true)
            {
                inventory.Remove(item);
                Debug.Log("Item Removed from inventory");
                item.added = false;
                textUI.text = (item.itemName);
            }
        }
    }
}
