using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class canEnterCasitaJose : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;

    private void Start()
    {
        if (Environment.habloDianaFinal || Environment.habloJoseFinal)
        {
            GetComponent<GoToNewPlace>().isActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && Environment.habloDianaFinal || collision.gameObject.tag.Equals("Player") && Environment.habloJoseFinal)
        {
            this.gameObject.GetComponent<GoToNewPlace>().isActive = false;
            dialoguePanel.SetActive(true);
            if(Environment.habloDianaFinal)
            {
                dialogueText.text = "�Tal vez deber�a de dejar las cosas as� como est�n, no puedo hacer nada m�s�";
            }else if (Environment.habloJoseFinal)
            {
                dialogueText.text = "�Deber�a dejarlo tranquilo�";
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Environment.habloDianaFinal || collision.gameObject.tag.Equals("Player") && Environment.habloJoseFinal)
        {
            dialoguePanel.SetActive(false);
        }
    }
}