using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCards : MonoBehaviour
{
    public GameObject[] cards;
    // Start is called before the first frame update
    void Start()
    {
        if (Environment.habloJoaquinCont > 1){
            cards[0].SetActive(true);
        }
        if (Environment.habloJoaquinCont > 2){
            cards[1].SetActive(true);
        }
        if (Environment.habloJoaquinCont > 3){
            cards[2].SetActive(true);
        }
    }
}
