using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketBooth : MonoBehaviour
{
    public GameObject Player;
    public PlayerMovement playerMovement;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - 10, 0);
            playerMovement.target = Player.transform.position;
        }
    }
}
