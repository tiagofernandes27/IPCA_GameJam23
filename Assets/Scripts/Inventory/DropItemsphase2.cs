using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropItemsphase2 : MonoBehaviour
{
    public GameObject[] myObjects; // Array of GameObjects

    public GameObject[] slots;
    public GameObject player;

    //-------------------------------------
    public GameObject NPCdoBanco;
    public Animator AnimatorDoBarco;
    public HatManRunning hatManRunning;
    public GameObject NPC;
    public Animator AnimatorDoCao;
    public PlayerMovement playerMovement;
    public IcecreamMove icecreamMove;
    void Start()
    {   
        
        slots = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            slots[i] = transform.GetChild(i).gameObject;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            // Check if the ray hits a child object of the "Image" object
            for (int i = 0; i < slots.Length; i++)
            {
                // Check if the current child object is being hovered over
                if (hit && hit.transform.IsChildOf(transform) && hit.transform == slots[i].transform)
                {
                    
                   
                    if (slots[i].transform.childCount > 0)
                    {
                        Debug.Log("SLOT Cheio");
                        Transform childObject = slots[i].transform.GetChild(0);
                        CheckTag(childObject);
                    }
                    else
                    {
                        Debug.Log("SLOT VAzio");
                        return;
                    }
                }
                else
                {
                    // Reset the color of non-hovered child objects
                    
                }
            }
        }

        
    }

    void CheckTag(Transform child)
    {
        if (child.CompareTag("Gerador") && player.transform.position.x > 0 && player.transform.position.y > 0)
        {
            //Animação do chapeu a voar prep
            playerMovement.lencoAnim = true;
            //Mudar a animação do cão
            AnimatorDoCao.SetTrigger("Cap");
            //Ativar e por a correr o homem do chapeu
            NPC.SetActive(true);
            hatManRunning.running = true;
            //Ligar o barco
            AnimatorDoBarco.SetTrigger("TurningOn");
            //Destruir o gerador e o homem do banco
            Destroy(NPCdoBanco.gameObject);
            Destroy(child.gameObject);
            
        }
        else if (child.CompareTag("Gerador2") && player.transform.position.x > 0 && player.transform.position.y < 0)
        {
            icecreamMove.Moving = true;
            Destroy(child.gameObject);
            Debug.Log("DROP Balão");
        }
        else if (child.CompareTag("Bomba") && player.transform.position.x < 0 && player.transform.position.y > 0 && child.CompareTag("Pipoca"))
        {

            
            Destroy(child.gameObject);
            
            Debug.Log("DROP Bomba");
        }
        else if (child.CompareTag("Ticket") && player.transform.position.x > 0 && player.transform.position.y > 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
     