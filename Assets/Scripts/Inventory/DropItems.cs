using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    public GameObject[] slots;
    public GameObject player;
   
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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            // Check if the ray hits a child object of the "Image" object
            for (int i = 0; i < slots.Length; i++)
            {
                // Check if the current child object is being hovered over
                if (hit && hit.transform.IsChildOf(transform) && hit.transform == slots[i].transform)
                {
                    
                   
                    if (slots[i].transform.childCount > 0)
                    {
                        Debug.Log("SLOT Cheio");
                        Transform childObject = slots[i].transform.GetChild(0);
                        CheckTag(childObject);
                    }
                    else
                    {
                        Debug.Log("SLOT VAzio");
                        return;
                    }
                }
                else
                {
                    // Reset the color of non-hovered child objects
                    
                }
            }
        }

        
    }

    void CheckTag(Transform child)
    {
        if (child.CompareTag("Sirene") && player.transform.position.x > 0 && player.transform.position.y < 0)
        {
            Debug.Log("DROP SIRENE");
        }
        else if (child.CompareTag("Balão") && player.transform.position.x > 0 && player.transform.position.y > 0)
        {
            Debug.Log("DROP Balão");
        }
        else if (child.CompareTag("Bomba") && player.transform.position.x < 0 && player.transform.position.y > 0)
        {
            Debug.Log("DROP Bomba");
        }
        else if (child.CompareTag("Ticket") && player.transform.position.x > 0 && player.transform.position.y > 0)
        {
            Debug.Log("DROP Ticket");
        }
    }
}
     