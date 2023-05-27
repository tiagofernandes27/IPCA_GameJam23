using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 target;

    private bool isMoving;

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
            Debug.Log("Quem é o target do botao" + target);
        }

        Move();
        Debug.Log("Quem é o target" + target);
        HasMoved();

        Debug.Log(isMoving);
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        isMoving = true;
    }

    private void HasMoved()
    {
        if(transform.transform.position == target) 
        { 
            isMoving = false;
        }
    }
}
