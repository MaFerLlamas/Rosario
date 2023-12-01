using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int cardID;
    public bool isCardShowed = false;

    void Start()
    {
    }
    // Start is called before the first frame update
    public void pickingCard(){
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCardShowed = true;
            Destroy(this.gameObject);
        }
    }
}
