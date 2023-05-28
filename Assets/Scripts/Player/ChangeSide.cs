using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSide : MonoBehaviour
{
    public GameObject Player;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Player.transform.position.y > 0){
            Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - 30, 0);
            playerMovement.target = Player.transform.position;
        }else if(collision.CompareTag("Player") && Player.transform.position.y < 0)
        {
            Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 30, 0);
            playerMovement.target = Player.transform.position;
        }
    }
}
