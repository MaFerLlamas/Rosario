using System.Collections;
using UnityEngine;
using TMPro;
public class DialogueLoco : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines2;

    private Rigidbody2D elRigibody;
    [SerializeField] private DialoguePantalla pantalla;

    private float typingTime = 0.05f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;

    private bool ajua;
    // Update is called once per frame

    private void Start()
    {
        if(Environment.entregoMachete) Destroy(gameObject);
        elRigibody = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("Fire1"))
        {

            Environment.direccion = Environment.IZQUIERDA;
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
        if (ajua == true)
        {
            if(elRigibody.position.x > 0.0f && elRigibody.position.x < 1.0f && elRigibody.position.y > -4.3f && elRigibody.position.y < -3.0f){
                elRigibody.velocity = new Vector2(0,-2.0f); //down
            }
            if(elRigibody.position.x>-0.5f && elRigibody.position.x < 1.0f && elRigibody.position.y > -5.0f && elRigibody.position.y < -4.0f)
            {
                elRigibody.velocity = new Vector2(-2.0f, 0f); //left
            }else if (elRigibody.position.x > -1.0f && elRigibody.position.x < 1.0f && elRigibody.position.y > -6.0f && elRigibody.position.y < -4.0f){
                elRigibody.velocity = new Vector2(0, -2.0f); //down
            }
            else
            {
                pantalla.tapa();
            }
        }
    }
    private void startDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        if (Environment.tieneMachete)
        {
            dialogueLines = dialogueLines2;
        }
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

            if (Environment.tieneMachete){
                ajua = true;
                Environment.entregoMachete = true;
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
