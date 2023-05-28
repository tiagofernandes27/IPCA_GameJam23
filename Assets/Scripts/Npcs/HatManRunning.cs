using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatManRunning : MonoBehaviour
{
    public bool running = false;
    private Vector3 Target = new Vector3(170, 63, 0);

    public Animator animator;

    static float speed = 25f;
    static float MovementThreshold = 1f;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            animator.SetBool("Running", true);

            Move();
            HasMoved();
                
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target, speed * Time.deltaTime);
    }

    private void HasMoved()
    {
        float distance = Vector2.Distance(transform.position, Target);
        if (distance <= MovementThreshold)
        {
            Destroy(this.gameObject);
        }
    }
}
