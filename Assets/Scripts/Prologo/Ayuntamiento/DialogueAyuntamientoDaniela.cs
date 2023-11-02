using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueAyuntamientoDaniela : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    private string[] dialogue;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines2;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines3; //dialogo: algo que hacer

    private float typingTime = 0.05f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    
    private int lineIndex;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("Fire1")){
            if (!didDialogueStart){
                startDialogue();
            }else if (dialogueText.text == dialogue[lineIndex]){
                nextDialogueLine();
            }else {
                StopAllCoroutines();
                dialogueText.text = dialogue[lineIndex];
            }
        }
    }
    private void startDialogue(){
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        if (Environment.algoQueHacerStart)
        {
            dialogue = dialogueLines3;
            if (Environment.dialogoDanielaAlgoQueHacerDone) lineIndex = dialogue.Length - 1;
        }
        else if (Environment.didDialogueAlreadyPast){
            dialogue = dialogueLines2;
            lineIndex = dialogue.Length - 1;
        }else dialogue = dialogueLines;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void nextDialogueLine(){
        lineIndex++;
        if (lineIndex < dialogue.Length){
            StartCoroutine(ShowLine());
        }else {
            //FIN DEL DIALOGO
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
            Environment.didDialogueAlreadyPast =true;
            if(Environment.algoQueHacerStart) Environment.dialogoDanielaAlgoQueHacerDone = true;
        }
    }

    private IEnumerator ShowLine(){
        dialogueText.text = string.Empty;
        foreach(char ch in dialogue[lineIndex]){
            dialogueText.text  += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player")){
            Debug.Log("Enter");
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player")){
            Debug.Log("Exit");
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }
}
