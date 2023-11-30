using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueMarisela : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    private float typingTime = 0.05f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    //private bool firstDialogue =true; //dialogue start when entry to the factory
    private bool startDialoge = true;
    private int lineIndex;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("Fire1") || !Environment.dialogoDentroFabricaAbandonadaDone && Input.GetButtonDown("Fire1") || startDialoge && !Environment.dialogoDentroFabricaAbandonadaDone)
        {
            startDialoge = false;
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
    private void startDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        if (!Environment.dialogoDentroFabricaAbandonadaDone)
        {
            lineIndex = 0;
        }
        else
        {
            lineIndex = dialogueLines.Length - 1;
        }
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void nextDialogueLine()
    {
        lineIndex++;
        if ((lineIndex < dialogueLines.Length && Environment.dialogoDentroFabricaAbandonadaDone) || (lineIndex < dialogueLines.Length-1 && !Environment.dialogoDentroFabricaAbandonadaDone))
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
            //firstDialogue = false; //with this will not repeat everything from start
            if (Environment.dialogoDentroFabricaAbandonadaDone){
                //Mostrando Mision en pantalla
                // "Algo Que Hacer"
                //QUEST 1 Parte 3 
                FindObjectOfType<QuestDialogue>().UpdateQuest(1, "vueve a hablar con el Licenciado en el Ayuntamiento");
            }
            Environment.dialogoDentroFabricaAbandonadaDone = true;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }
}
