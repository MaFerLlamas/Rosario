using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkIfActive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Environment.algoQueHacerVisitsDone())
        {
            GoToNewPlace MundoAbierto = FindObjectOfType<GoToNewPlace>();
            MundoAbierto.isActive = false;
        }
    }

}
