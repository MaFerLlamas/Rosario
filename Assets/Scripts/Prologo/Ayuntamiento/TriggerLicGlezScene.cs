using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerLicGlezScene : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4,6)] private string[] dialogue;

    private float typingTime = 0.05f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    public bool isDialogueActive = true;
    private int lineIndex;

     void Update(){
        if (isPlayerInRange && Input.GetButtonDown("Fire1") && isDialogueActive){
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
            Time.timeScale = 0f;
            StartCoroutine(ShowLine());
    }

    private void nextDialogueLine(){
        lineIndex++;
        if (lineIndex < dialogue.Length){
            StartCoroutine(ShowLine());
        }else {
            //FIN DEL DIALOGO
            dialoguePanel.SetActive(false);
            Time.timeScale = 1f;
            isDialogueActive=false;
            FindObjectOfType<MorganController>().morganShouldMove = true; 
            FindObjectOfType<LicGonzalezController>().LicGonShouldMove = false; 
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
        //Se Activa solo si Morgan cocha contra el cuadro, Morgan ya hablo con Daniela 1 vez y no ha hablado con el Licenciado todavia
        if (collision.gameObject.tag.Equals("Player") && FindObjectOfType<DialogueAyuntamientoDaniela>().didDialogueAlreadyPast == true && isDialogueActive){
            FindObjectOfType<MorganController>().morganShouldMove = false;
            isPlayerInRange = true;
            startDialogue();
        }
    }
}
