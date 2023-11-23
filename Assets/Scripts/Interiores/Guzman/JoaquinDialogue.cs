using System.Collections;
using UnityEngine;
using TMPro;

public class JoaquinDialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    private string[] dialogue;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines1;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines2;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines3;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines4;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines5;


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
        switch (Environment.habloJoaquinCont)
        {
            case 1:
                dialogue = dialogueLines1; break;
            case 2:
                dialogue = dialogueLines2; break;
            case 3:
                dialogue = dialogueLines3;  break;
            case 4:
                dialogue = dialogueLines4;   break;
            case 5:
                Environment.habloJoaquinCont = 5;
                dialogue = dialogueLines5;  break;
            default:
                dialogue = dialogueLines5;
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
            Environment.habloJoaquinCont ++;
            //Mover a Joaquin y prepararlo para el siguiente dialogo
            switch (Environment.habloJoaquinCont)
            {
            case 2:
               //Mover al Cementerio
               this.gameObject.SetActive(false);
               isPlayerInRange = false;
               break;
            case 3:
                //parada de camion junto al arbol
                isPlayerInRange = false;
                break;
            case 4:
                //Mover a gassolinera
                isPlayerInRange = false;
                dialogue = dialogueLines4;   break;
            case 5:
                //Mostrar en Casa
                Environment.habloJoaquinCont = 5;
                this.gameObject.SetActive(true);  
                break;
            default:
                //Mostrar en Casa
                dialogue = dialogueLines5;
                break;
        }
            
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