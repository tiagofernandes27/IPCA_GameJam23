using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaOutside : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject Player;
    public GameObject OutsideMarker;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a wall
        if (collision.collider.CompareTag("Player") && GetComponent<Collider2D>().OverlapPoint(playerMovement.target))
        {
            Player.transform.position = OutsideMarker.transform.position;
        }
    }
}
