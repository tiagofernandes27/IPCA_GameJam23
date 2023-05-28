using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGoingBack : MonoBehaviour
{
    public GameObject Player;
    public PlayerMovement playerMovement;
    public Vector3 AwayFromPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Player") && playerMovement.PlayerDirty)
       {
            gameObject.transform.position = AwayFromPlayer;
       }else if(collision.CompareTag("Player") && !playerMovement.PlayerDirty){//Aqui o player volta atras
            //Escrever TMP
            Player.transform.position = new Vector3(Player.transform.position.x - 10, Player.transform.position.y, 0);
       }
    }
}
