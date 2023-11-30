using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanielaPosition2 : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("This is a message1"+ collision.gameObject.tag+"/"+ collision.gameObject.tag.Equals("NPC"));
        if (collision.gameObject.tag.Equals("NPC")){
            Debug.Log("This is a message. de que si entro");
            //FindObjectOfType<DanielaController>().danielaShouldMove = true;
            FindObjectOfType<CameraFollow>().followTarget = GameObject.Find("Morgan");
            FindObjectOfType<MorganController>().morganShouldMove = true;
            Environment.prologoCasaDanielaMovementDone = true;
        }
    }

}
