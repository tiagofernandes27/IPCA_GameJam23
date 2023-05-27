using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSlot : MonoBehaviour
{
    public GameObject[] slots;
   
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
}
