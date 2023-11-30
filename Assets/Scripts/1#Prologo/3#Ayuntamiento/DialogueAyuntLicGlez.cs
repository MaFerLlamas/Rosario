using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueAyuntLicGlez : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    private string[] dialogue;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines0;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines2;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines3;

    private float typingTime = 0.05f;
    public bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;

    //Propositos de Testig Activar para saltar Dialogo
    public bool skipDialogueForTesting;
    void Start(){
        //Propositos de Testig
            if (Environment.skipDialogueForTestingAll == true){
            skipDialogueForTesting = true;
        }
    }
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
    public void startDialogue(){
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        //Reinicia el array y cambia de array dependiendo la situacion
        if (Environment.dialogoDentroFabricaAbandonadaDone){
            dialogue = dialogueLines3;
        }else if (Environment.didDialogueAlreadyPastGlz){
            dialogue = dialogueLines2;
            //if(Environment.dialogoAyuntamientoLicDone) lineIndex = dialogue.Length - 1;
            //lineIndex = dialogue.Length - 1;
        }else if (Environment.didLicThoughtsPast){
            dialogue = dialogueLines;
            //lineIndex = dialogue.Length - 1;
        } else dialogue = dialogueLines0;
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
            isPlayerInRange = false;
            Time.timeScale = 1f;

            if (Environment.didLicThoughtsPast){
                if (!Environment.didDialogueAlreadyPastGlz){
                    Environment.didDialogueAlreadyPastGlz = true;
                    //Mostrando Mision en pantalla
                    //FIN DE QUEST 0
                    //Un pretexto
                    FindObjectOfType<QuestDialogue>().initQuest(0, false, true);
                    // Y ahora Que
                    //QUEST 1 INICIO
                    FindObjectOfType<QuestDialogue>().initQuest(1, true, false);
                }
            }
            if (Environment.dialogoDentroFabricaAbandonadaDone)
            {
                Environment.dialogoAyuntamientoLicDone = true;
                Environment.algoQueHacerStart = true;
                //Mostrando Mision en pantalla
                    //FIN DE QUEST 1
                    //Y ahora Que
                    FindObjectOfType<QuestDialogue>().initQuest(1, false, true);
            }
            Environment.didLicThoughtsPast = true;
            GoToNewPlace newPlace = FindObjectOfType<GoToNewPlace>();
            newPlace.isActive = true;
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
        if (collision.gameObject.CompareTag("Player") && FindObjectOfType<TriggerLicGlezScene>().isDialogueActive == false){
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
            FindObjectOfType<LicGonzalezController>().isInterrupted = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player")){
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }
}
