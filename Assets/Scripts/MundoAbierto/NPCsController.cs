using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsController : MonoBehaviour
{
    [SerializeField] private GameObject joaquinVariant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Environment.habloJoaquinCont == 2 ){
            joaquinVariant.SetActive(true);
        }
    }
}
