using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropItems : MonoBehaviour
{
    public GameObject[] myObjects; // Array of GameObjects

    public GameObject[] slots;
    public GameObject player;
    public GameObject pipocas;

    public Animator ExplosionAnimator;
    public Animator CashierAnimator;

    //Codigo da cabana dos bilhetes
    public GameObject TicketBooth;
    private CapsuleCollider2D BoothCollider;

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
        if (child.CompareTag("Sirene") && player.transform.position.x > 0 && player.transform.position.y < 0)
        {
            for (int i = 0; i < myObjects.Length; i++)
            {
                if (myObjects[i] != null)
                {
                    // Access the script component attached to the GameObject
                    NpcRunningAway myScript = myObjects[i].GetComponent<NpcRunningAway>();

                    // Check if the script component exists
                    if (myScript != null)
                    {
                        // Access the boolean variable in the script
                        myScript.OutsideRunning = true;
                    }
                }
            }
            Destroy(child.gameObject);
            Debug.Log("DROP SIRENE");
        }
        else if (child.CompareTag("Balão") && player.transform.position.x > 0 && player.transform.position.y > 0)
        {
            for (int i = 0; i < myObjects.Length; i++)
            {
                if (myObjects[i] != null) {
                    // Access the script component attached to the GameObject
                    NpcRunningAway myScript = myObjects[i].GetComponent<NpcRunningAway>();

                    // Check if the script component exists
                    if (myScript != null)
                    {
                        // Access the boolean variable in the script
                        myScript.CinemaRunning = true;
                    } 
                }
            }
            Destroy(child.gameObject);
            Debug.Log("DROP Balão");
        }
        else if (child.CompareTag("Bomba") && player.transform.position.x < 0 && player.transform.position.y > 0 && child.CompareTag("Pipoca"))
        {

            pipocas = GameObject.FindWithTag("Pipocas");
            ExplosionAnimator.SetBool("Explosion", true);
            CashierAnimator.SetBool("Walk", true);
            //Procura e destroi o collider que esta a esturvar
            BoothCollider = GameObject.FindAnyObjectByType<CapsuleCollider2D>();
            Destroy(BoothCollider);
            Destroy(pipocas);
            Destroy(child.gameObject);
            
            Debug.Log("DROP Bomba");
        }
        else if (child.CompareTag("Ticket") && player.transform.position.x > 0 && player.transform.position.y > 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
     