using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkIfActiveAyuntamiento : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Environment.didDialogueAlreadyPastGlz) GetComponent<GoToNewPlace>().isActive = true;
    }
}
