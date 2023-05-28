using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcecreamMove : MonoBehaviour
{

    public GameObject Carrinho;
    private Vector3 Target = new Vector3(-15, -22, 0);

    public bool Moving = false;

    //IceCream Animations
    public Animator animation;

    //Dog Animations
    public Animator DogAnimations;

    //Game object que � a revista
    public GameObject revista;

    //Static variables
    static float speed = 25f;
    static float MovementThreshold = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Moving)
        {
            animation.SetTrigger("Moving");
            Move();
            HasMoved();
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target, speed * Time.deltaTime);
    }

    private void HasMoved()
    {
        float distance = Vector2.Distance(transform.position, Target);
        if (distance <= MovementThreshold)
        {
            //Trocar anima�ao
            animation.SetTrigger("Falling");

            //Trocar anima�ao do cao
            DogAnimations.SetTrigger("Licks");

            //Ativar a revista
            revista.SetActive(true);
        }
    }
}
