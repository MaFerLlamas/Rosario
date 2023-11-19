using System.Collections;
using UnityEngine;
using TMPro;

public class ElizabethPerezDialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    private string[] dialogue;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines1;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines2;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines3;

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
            switch (Environment.habloElizabthCont)
        {
            case 1:
                dialogue = dialogueLines1; break;
            case 2:
                dialogue = dialogueLines2; break;
            case 3:
                dialogue = dialogueLines3;  
                Environment.habloElizabthCont = 3;
                break;
            default:
                dialogue = dialogueLines3;
                break;
        }
            didDialogueStart = true;
            dialoguePanel.SetActive(true);
            dialogueMark.SetActive(false);
            lineIndex = 0;
            Time.timeScale = 0f;
            StartCoroutine(ShowLine());
    }

    private void nextDialogueLine(){
        lineIndex++;
        if (lineIndex < dialogue.Length){
            StartCoroutine(ShowLine());
        }else {
            //FINAL DEL DIALOGO
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
            Environment.habloElizabthCont ++;
            
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
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player")){
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }
}
