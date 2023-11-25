using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitaBanca : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(!Environment.entregoMachete)
        {
            Destroy(gameObject);
        }
    }
}
