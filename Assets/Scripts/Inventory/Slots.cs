using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Slots : MonoBehaviour
{
    public GameObject[] slots;
    public Vector3 itemScale = new Vector3(5.0f, 5.0f, 5.0f);
    void Start()
    {
        slots = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            slots[i] = transform.GetChild(i).gameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddtoSlot(Item item)
    {

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount == 0)
            {
                Vector3 slotCenter = slots[i].transform.position;
                //Instantiate(item, slotCenter, Quaternion.identity, slots[i].transform);
                //Destroy(item.gameObject);

                Item newItem = Instantiate(item, slotCenter, Quaternion.identity, slots[i].transform);
                newItem.transform.localScale = itemScale; // Set the scale of the instantiated item
                Destroy(item.gameObject);
                break; // Exit the loop after instantiating the item in the first empty slot
                
            }
        }
    }

}
