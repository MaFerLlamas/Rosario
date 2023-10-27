using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerLicGlezScene : MonoBehaviour
{

    public bool isDialogueActive = true;
   
    
    private IEnumerator OnTriggerEnter2D(Collider2D collision){
        //Se Activa solo si Morgan cocha contra el cuadro, Morgan ya hablo con Daniela 1 vez y no ha hablado con el Licenciado todavia
        if (collision.gameObject.tag.Equals("Player") && FindObjectOfType<DialogueAyuntamientoDaniela>().didDialogueAlreadyPast == true && isDialogueActive){
            FindObjectOfType<MorganController>().morganShouldMove = false;
            FindObjectOfType<LicGonzalezController>().showThoughts = true;
            yield return new WaitForSeconds(4.0f); // Espera 2 segundos
            FindObjectOfType<MorganController>().morganShouldMove = true;
            isDialogueActive=false;
        }
    }
}
