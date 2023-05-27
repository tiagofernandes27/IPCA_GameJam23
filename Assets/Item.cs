using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    
    private bool isColliding;
    public bool hasBeenCollected { set; get; }
    public bool hasBeenUsed { private set; get; }
    public bool added { set; get; }
    float radius;
    void Start()
    {
        isColliding = false;
        CircleCollider2D circle = GetComponent<CircleCollider2D>();
        radius = circle.radius;
    }

    void Update()
    {
        if(isColliding)
        {
            Debug.Log("Colidou");
            if (Input.GetMouseButtonDown(0) && ((Vector2) (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position)).magnitude < radius)
            {   
                Collect();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = true;
            //Debug.Log("Enter");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isColliding=false;
        
        //Debug.Log("Exit");
    }

    private void Collect()
    {
        hasBeenCollected= true;
        Debug.Log("Coletou");
    }


}
