using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcRunningAway : MonoBehaviour
{
    public bool CinemaRunning;
    private Vector3 CinemaTarget = new Vector3(-10, 26, 0);
    public bool OutsideRunning;
    private Vector3 OutsideTarget = new Vector3(100, -40, 0);

    static float speed = 25f;
    static float MovementThreshold = 1f;

    private void Update()
    {
        if(CinemaRunning && this.CompareTag("CinemaNPC"))
        {
            Move(CinemaTarget);
            HasMoved(CinemaTarget);
        }
        else if (OutsideRunning && this.CompareTag("OutsideNPC"))
        {
            Move(OutsideTarget);
            HasMoved(OutsideTarget);
        }
        
    }

    private void Move(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void HasMoved(Vector3 target)
    {
        float distance = Vector2.Distance(transform.position, target);
        if (distance <= MovementThreshold)
        {
            Destroy(this.gameObject);
        }
    }
}
