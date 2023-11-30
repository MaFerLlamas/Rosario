using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitedPlace : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Environment.VisitedPlace(this.name);
            if (Environment.algoQueHacerVisitsDone()){
                //Mostrando Mision en pantalla
                //FIN DE QUEST 2
                //Algo que hacer
                FindObjectOfType<QuestDialogue>().initQuest(2, false, true);
            }
        }
    }
}
