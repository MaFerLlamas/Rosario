using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesaparecerNPC : MonoBehaviour
{
    public GameObject NPC;
    public bool isActive = true;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("NPC") && isActive){
             NPC.SetActive(false);
        }

    }
}

