using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkIfActive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GoToNewPlace mundoAbierto = this.gameObject.GetComponent<GoToNewPlace>(); //FindObjectOfType<GoToNewPlace>();
        bool visitsDone = Environment.algoQueHacerVisitsDone();
        if (visitsDone || !Environment.prologoCasaDaniela4PM)
        {
            mundoAbierto.isActive = false;
        }
        if (Environment.prologoCasaDaniela4PM && !visitsDone && !Environment.didDialogueAlreadyPast)
        {
            Destroy(FindObjectOfType<DialogueDanielaCasaDaniela>().gameObject);
            mundoAbierto.newPlaceName = "PrologoAyuntamiento";
            mundoAbierto.newSpawnName = "Entrada";
        } else if (!visitsDone && Environment.prologoCasaDaniela4PM)
        {
            Destroy(FindObjectOfType<DialogueDanielaCasaDaniela>().gameObject);
        }
    }

}
