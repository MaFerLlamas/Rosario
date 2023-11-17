using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueFoto : MonoBehaviour
{
    [SerializeField] private Sprite imagenFoto;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;

    private float typingTime = 0.05f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    private bool dialogueStarted;

    // Update is called once per frame
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = null;
        dialogueStarted = false;
    }

    public void setFoto()
    {
        GetComponent<SpriteRenderer>().sprite = imagenFoto;
        Debug.Log("coloque foto");
    }
    private void quitaFoto()
    {
        GetComponent<SpriteRenderer>().sprite = null;
    }
    void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("Fire1") && Environment.habloJoseFinal && Environment.habloDianaFinal || !dialogueStarted && Environment.habloJoseFinal && Environment.habloDianaFinal && isPlayerInRange)
        {
            if (!didDialogueStart)
            {
                startDialogue();
                dialogueStarted=true;
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
            Time.timeScale = 1f;
            Environment.fotoTrofeo = true;
            quitaFoto();
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
        if (collision.gameObject.CompareTag("Player") && Environment.habloJoseFinal && Environment.habloDianaFinal)
        {
            isPlayerInRange = true;
            startDialogue(); //para iniciar dialogo sin hacer clic 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
