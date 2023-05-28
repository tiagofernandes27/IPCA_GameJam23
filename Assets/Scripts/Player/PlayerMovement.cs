using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class PlayerMovement : MonoBehaviour
{

    //Variavel que verifica se pode ativar o lenco
    public bool lencoAnim = false;
    //PlayerDirty
    public bool PlayerDirty = false;

    static float speed = 15f;
    public Vector3 target;

    private bool isMoving;
    private float MovementThreshold = 1;

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
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            isMoving = true;
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
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        isMoving = true;
    }

    private void HasMoved()
    {
        float distance = Vector2.Distance(transform.position, target);
        if (distance < MovementThreshold) 
        { 
            isMoving = false;  
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a wall
        if (collision.collider.CompareTag("Wall"))
        {
            isMoving = false;
        }
    }


}
