using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueCasaDaniela0 : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines;

    private float typingTime = 0.05f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private bool firstDialogueActivated;
    private int lineIndex;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("Fire1") && !Environment.prologoCasaDanielaDone){
            if (!didDialogueStart){
                startDialogue();
            }else if (dialogueText.text == dialogueLines[lineIndex]){
                nextDialogueLine();
            }else {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }
    private void startDialogue(){
            didDialogueStart = true;
            dialoguePanel.SetActive(true);
            dialogueMark.SetActive(false);
            lineIndex = 0;
            Time.timeScale = 0f;
            StartCoroutine(ShowLine());
    }

    private void nextDialogueLine(){
        lineIndex++;
        if (lineIndex < dialogueLines.Length){
            StartCoroutine(ShowLine());
        }else {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
            FindObjectOfType<MorganController>().morganShouldMove = false;
            FindObjectOfType<CameraFollow>().followTarget = GameObject.Find("Daniela");
            FindObjectOfType<DanielaController>().danielaShouldMove = true;
            Environment.prologoCasaDanielaDone = true;
        }
    }

    private IEnumerator ShowLine(){
        dialogueText.text = string.Empty;
        foreach(char ch in dialogueLines[lineIndex]){
            dialogueText.text  += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log(Environment.prologoCasaDanielaDone);
        if (collision.gameObject.CompareTag("Player") && !Environment.prologoCasaDanielaDone ){
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
            FindObjectOfType<MorganController>().morganShouldMove = false;
            startDialogue();
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player")){
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }
}