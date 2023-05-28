using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToNextLevel : MonoBehaviour
{
    public GameObject Player;
    public PlayerMovement playerMovement;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Se comparar o jogador e ainda nao tiver o item ele nao passa
        if (other.CompareTag("Player"))
        {
            //Escrever o text TMP aqui
            Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - 10, 0);
            playerMovement.target = Player.transform.position;
        }
        
    }
}
