using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerLevel1 : MonoBehaviour
{
    public GameObject player;

    public Item balloon;
    public Item money;
    public Item ticket;
    public Item popcorn;
    public Item bomb;
    public Item siren;

    public GameObject dialogue;
    private TMPro.TextMeshPro dialogueText;

    void Start()
    {
        dialogueText = dialogue.GetComponentInChildren<TextMeshPro>();
        dialogue.SetActive(false);
        Dialogue();
    }


    void Update()
    {
        

    }

    public void Dialogue()
    {
        if (dialogue != null)
        {
            dialogue.SetActive(true);
            dialogueText.text = "Quero muito ver esse filme, mas como posso comprar o bilhete sem interagir com o vendedor?";
        }
    }

    //Acontece quando é usada a SIRENE
    public void ScareChildren()
    {

    }

    //Acontece quando o BALÃO é usado
    public void DistractChild()
    {

    }

    //quando PIPOCA/BOMBA é usada
    public void DesmaiarAttendant()
    {

    }

    //passar de nivel quando TEM DINHEIRO E NÃO TEM MONEY
    public void ChangeLevel()
    {

    }
}
