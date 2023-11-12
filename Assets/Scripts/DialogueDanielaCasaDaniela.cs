using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueDanielaCasaDaniela : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLinesFinal;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    private float typingTime = 0.05f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    //Propositos de Testig Activar para saltar Dialogo
    public bool skipDialogueForTesting;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("Fire1"))
        {
            if (!didDialogueStart)
            {
                startDialogue();
            }else if (dialogueText.text == dialogueLines[lineIndex])
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

    private void Start()
    {
        if (Environment.prologoCasaDanielaDialogo2EscenasDone)
        {
            dialogueLines = dialogueLinesFinal;
        }
        //Propositos de Testig
        if (Environment.skipDialogueForTestingAll == true){
            skipDialogueForTesting = true;
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
            //FIN DEL DIALOGO
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
            if(Environment.prologoCasaDaniela4PM) {
                Environment.dialogoDanielaFinalDone = true;  
            }
            else {Environment.prologoCasaDanielaDialogo2EscenasDone = true;
                // Activando el sistema de misiones por primera vez
                //GameObject.Find("Scroll View").SetActive(true);
                //Mostrando Mision en pantalla
                // "UN PRETEXTO"
                //QUEST 0 INICIO
                FindObjectOfType<QuestDialogue>().initQuest(0, true, false);
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
