using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanielaPosition2 : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
            Debug.Log("This is a message.");
        if (collision.gameObject.tag.Equals("NPC")){
            FindObjectOfType<DanielaController>().danielaShouldMove = true;
            FindObjectOfType<CameraFollow>().followTarget = GameObject.Find("Morgan");
        }
    }

}
