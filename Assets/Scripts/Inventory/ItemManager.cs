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

    public Slots slot;
    


    private void Start()
    {
        inventory = new List<Item>();

        levelItems = FindObjectsOfType<Item>();
        slot = GetComponent<Slots>();

        
    }

    private void Update()
    {
        foreach(Item item in levelItems)
        {
            if (item.hasBeenCollected && item.added == false)
            {
                inventory.Add(item);
                slot.AddtoSlot(item);
                Debug.Log("Item Added to inventory");
                item.added = true;
               
            }

            if (item.hasBeenUsed && item.added == true)
            {
                inventory.Remove(item);
                Debug.Log("Item Removed from inventory");
                item.added = false;
                
            }
        }

        

    }
}
