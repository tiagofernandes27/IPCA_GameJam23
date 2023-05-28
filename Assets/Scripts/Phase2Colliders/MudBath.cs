using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudBath : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameObject Player;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player.transform.position = new Vector3(-60, -45, 0);
            animator.SetTrigger("Dive");
            playerMovement.PlayerDirty = true;
        }
    }
}
