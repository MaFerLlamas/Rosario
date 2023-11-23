using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZonaPesca : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    private string[] dialogueLines =
        { "Pescador: Que carajos",
        "Pescador: Toda la mañana tratando y a la primera, estas bendito mi broder",
        "Morgan: Solo suerte ",
        "Pescador: No compa, ahora sí que me dejastes´ mal. Te regalo esa caña, al fin y al cabo te eligio. ",
        "Pescador: Yo seguiré en la lucha, a ver si pesco algo"
       };

    private float typingTime = 0.05f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    private float timer=0.0f;
    private bool activado =false;
    private float waitTime = 1.5f;

    // Update is called once per frame
    void Update()
    {
        if(activado) timer += Time.deltaTime;
        if (isPlayerInRange && Input.GetButtonDown("Fire1") && Environment.habloPescador && !Environment.tieneCana || activado && timer> waitTime)
        {
            activado = true;
            if (timer > waitTime)
            {
                activado=false;
                if (!didDialogueStart)
                {
                    startDialogue();
                }
                else if (dialogueText.text == dialogueLines[lineIndex])
                {
                    nextDialogueLine();
                }
                else
                {
                    StopAllCoroutines();
                    dialogueText.text = dialogueLines[lineIndex];
                }
            }
        }
        if(isPlayerInRange && Input.GetButtonDown("Fire1"))
        {
            Environment.setMorganFishing(true);
            dialogueMark.SetActive(false);
        }
    }
    private void startDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void nextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
            Environment.tieneCana = true;
            Environment.setMorganFishing(false);
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Environment.habloPescador)
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Environment.habloPescador)
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
            Environment.setMorganFishing(false);
        }
    }
}
