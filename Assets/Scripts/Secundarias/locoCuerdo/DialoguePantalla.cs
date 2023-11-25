using System.Collections;
using UnityEngine;
using TMPro;


public class DialoguePantalla : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;


    private float typingTime = 0.05f;
    //private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;

    private bool dialogeStarted;
    private float darkness;
    private bool tapando;
    private bool aclarando;

    private void Start()
    {
        dialogeStarted = false;
        darkness = 0.0f;
        tapando = false;
        aclarando = false;
        this.GetComponent<Renderer>().material.color = new Color(0, 0, 0, darkness);
    }

    public void tapa()
    {
        this.transform.position = Vector2.zero;
        tapando = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (tapando && !aclarando && darkness<255)
        {
            darkness += 100 * Time.deltaTime;
            this.GetComponent<Renderer>().material.color = new Color(0, 0, 0, darkness / 255);
        }else if(aclarando && darkness > 0)
        {
            darkness -= 100 * Time.deltaTime;
            this.GetComponent<Renderer>().material.color = new Color(0, 0, 0, darkness / 255);
            Debug.Log("aclarando: "+darkness);
        }
        if (darkness > 255 && Input.GetButtonDown("Fire1") && !aclarando || !dialogeStarted && darkness>255)
        {
            dialogeStarted=true;
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
            if (darkness > 254)
            {
                //reproducir audio
                aclarando = true;
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
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
    */
}
