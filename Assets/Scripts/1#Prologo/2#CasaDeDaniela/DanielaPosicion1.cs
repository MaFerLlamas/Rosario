using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanielaPosicion1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("This is a message.");
        if (collision.gameObject.tag.Equals("NPC"))
        {
            FindObjectOfType<DanielaController>().danielaShouldMove = true;
            FindObjectOfType<CameraFollow>().followTarget = GameObject.Find("Morgan");
            FindObjectOfType<MorganController>().morganShouldMove = true;
            Environment.prologoCasaDanielaMovement2Done = true;
            Destroy(collision.gameObject);
        }
    }
}
