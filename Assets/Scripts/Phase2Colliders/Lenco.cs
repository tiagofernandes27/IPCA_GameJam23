using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lenco : MonoBehaviour
{
    public GameObject Player;
    public GameObject LencoAnimacao;
    private PlayerMovement playerMovement;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = Player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.lencoAnim && Player.transform.position.x < 0 && Player.transform.position.y > 0)
        {
            LencoAnimacao.SetActive(true);
            Destroy(LencoAnimacao, 1f);
            Destroy(this);
        }
    }
}
