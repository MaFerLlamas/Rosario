using System.Collections;
using UnityEngine;
using TMPro;

public class DialoguePrincipioDeAlgo : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    private string[] dialogueLines = 
        { "“Daniela dijo que al terminar regrese a la chan”",
        "“ probablemente sea hora de regresar.”",
        "“Aunque si regreso probablemente me de flojera salir otra vez”",
        "“debería ver todo lo que quiera ver antes de volver”"};

    private float typingTime = 0.05f;
    //private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    private bool firstDialogue=true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Environment.algoQueHacerVisitsDone() && !Environment.algoQueHacerDone || Environment.algoQueHacerVisitsDone() && firstDialogue)
        {
            firstDialogue = false;
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
            Environment.algoQueHacerDone = true;
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
            //isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }
}
