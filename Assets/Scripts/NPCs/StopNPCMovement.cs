using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopNPCMovement : MonoBehaviour
{
    public GameObject NPC;
    public bool isActive = true;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == NPC && isActive){
             NPC.GetComponent<NPCsMovementController>().NPCShouldMove = false;
             isActive = false;
        }

    }
}
