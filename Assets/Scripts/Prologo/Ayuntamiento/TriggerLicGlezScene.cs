using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerLicGlezScene : MonoBehaviour
{

    public bool isDialogueActive = true;
    private LicGonzalezController licenciado;

    private void Start()
    {
        licenciado = FindObjectOfType<LicGonzalezController>();
    }
    private IEnumerator OnTriggerEnter2D(Collider2D collision){
        //Se Activa solo si Morgan cocha contra el cuadro, Morgan ya hablo con Daniela 1 vez y no ha hablado con el Licenciado todavia
        Debug.Log(Environment.didDialogueAlreadyPast);
        if (collision.gameObject.tag.Equals("Player") && Environment.didDialogueAlreadyPast && isDialogueActive && !Environment.dialogoDentroFabricaAbandonadaDone && !Environment.didDialogueAlreadyPastGlz){
            
            Environment.morgan.morganShouldMove = false;
            licenciado.showThoughts = true;
            Environment.camara.followTarget = licenciado.gameObject;
            yield return new WaitForSeconds(3.0f); // Espera 2 segundos
            Environment.camara.followTarget = Environment.morgan.gameObject;
            Environment.morgan.morganShouldMove = true;
            isDialogueActive=false;
        }else if (Environment.didDialogueAlreadyPastGlz)
        {
            isDialogueActive = false;
        }
        
    }
}
