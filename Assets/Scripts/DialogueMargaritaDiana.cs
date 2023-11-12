using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueMargaritaDiana : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines2;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines3;

    private float typingTime = 0.05f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;

    private void Start()
    {
        if (Environment.habloJoseFinal)
        {
            dialogueLines = dialogueLines3;
        }else if (Environment.habloJose)
        {
            dialogueLines = dialogueLines2;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("Fire1"))
        {
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
        Time.timeScale = 0f;
        if (Environment.habloDiana && !Environment.habloJoseFinal)
        {
            lineIndex = dialogueLines.Length - 1;
        }
        else lineIndex = 0;
          
        StartCoroutine(ShowLine());
    }

    private void nextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            if (Environment.habloJose && lineIndex== dialogueLines.Length-1)
            {
                Environment.habloDianaFinal = true;
                FindObjectOfType<canEnterCasitaJose>().gameObject.GetComponent<GoToNewPlace>().isActive = false;
                //canEnterCasitaJose casita = FindObjectOfType<canEnterCasitaJose>();
                //scasita.gameObject.GetComponent<GoToNewPlace>().isActive = false;
            }
            StartCoroutine(ShowLine());

        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
            Environment.habloDiana = true;
            if (Environment.habloJoseFinal)
            {
                Debug.Log("habloDianaFinal");
                Environment.habloDianaFinal = true;
                DialogueFoto foto = FindObjectOfType<DialogueFoto>();
                foto.setFoto(); //esto crashea aqui y no se porque
            }
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
