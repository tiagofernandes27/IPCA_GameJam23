using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IventaryActivate : MonoBehaviour
{
    private bool isActive;
    
    // Start is called before the first frame update
    void Start()
    {   
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isActive == false)
        {
           
            Debug.Log("Inventario");
            foreach (Transform child in transform)
            {
                
                child.gameObject.SetActive(true);
                isActive= true;
                Time.timeScale = 0f;




            }
                
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false );
                isActive = false;
                Time.timeScale = 1.0f;
                //gameObject.GetComponent<PlayerMovement>().enabled = true;

            }

        }
    }

  
}
