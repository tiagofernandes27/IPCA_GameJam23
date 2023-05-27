using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 target;

    Vector3 mousePosition;

    private bool isMoving;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;

            // Check if there is a collider between the player and the mouse click position
            if (IsCollidingWithObstacle(transform.position, mousePosition))
            {
                // Stop player movement if a collider is detected
                isMoving = false;
                return;
            }
            else
            {
                isMoving = true;
            }
        }

        
        //Animacao
        if (isMoving)
        {
            Move();

            HasMoved();

            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }
        
    }

   

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
        isMoving = true;
    }

    private void HasMoved()
    {
        if(transform.transform.position == target) 
        { 
            isMoving = false;
                  
        }
    }

    private bool IsCollidingWithObstacle(Vector3 startPos, Vector3 endPos)
    {
        RaycastHit2D hit = Physics2D.Linecast(startPos, endPos);

        if (hit.collider != null && hit.collider.CompareTag("Wall"))
        {
            return true;
        }

        return false;
    }


}
