using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerLicGlezScene : MonoBehaviour
{

    public bool isDialogueActive = true;
    private LicGonzalezController licenciado;
    private DialogueAyuntLicGlez licenciadoDialogue;

    private void Start()
    {
        licenciado = FindObjectOfType<LicGonzalezController>();
        licenciadoDialogue = FindObjectOfType<DialogueAyuntLicGlez>();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        //Se Activa solo si Morgan choca contra el cuadro, Morgan ya hablo con Daniela 1 vez y no ha hablado con el Licenciado todavia
        if (collision.gameObject.tag.Equals("Player") && Environment.didDialogueAlreadyPast && isDialogueActive && !Environment.dialogoDentroFabricaAbandonadaDone && !Environment.didDialogueAlreadyPastGlz){
            
            Environment.morgan.morganShouldMove = false;
            Environment.camara.followTarget = licenciado.gameObject;
            // Iniciando Pensamientos del Lic
            licenciadoDialogue.isPlayerInRange = true;
            licenciadoDialogue.startDialogue();

            Environment.camara.followTarget = Environment.morgan.gameObject;
            Environment.morgan.morganShouldMove = true;
            isDialogueActive = false;
        }else if (Environment.didDialogueAlreadyPastGlz){
            isDialogueActive = false;
        }
        
    }
}
