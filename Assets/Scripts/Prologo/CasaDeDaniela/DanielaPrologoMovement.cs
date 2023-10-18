using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanielaPrologoMovement : MonoBehaviour
{
    Rigidbody2D danielaRigidbody;
    DanielaController daniela;
    
    private float VELOCITY =5.0f;

    public void moveDaniela()
    {   
        if(this.transform.position.x>8 && this.transform.position.x < 9 && this.transform.position.y > -4 && this.transform.position.y < -3)
        {
            danielaRigidbody.velocity= new Vector2(0, VELOCITY); //up
            Debug.Log("step 1"+ this.transform.position.x+"/"+ this.transform.position.y);
        }
        else if (daniela.transform.position.x > 8 && daniela.transform.position.x < 9 && daniela.transform.position.y > -2.0f && daniela.transform.position.y < -1.0f){
            danielaRigidbody.velocity = new Vector2(-VELOCITY, 0); //left
            Debug.Log("step 2");

        }
        else if (daniela.transform.position.x > 3 && daniela.transform.position.x < 4 && daniela.transform.position.y > -2 && daniela.transform.position.y < -1)
        {
            danielaRigidbody.velocity = new Vector2(0, -VELOCITY ); //down
        }else if (daniela.transform.position.x > 3 && daniela.transform.position.x < 4 && daniela.transform.position.y > -4 && daniela.transform.position.y < -3)
        {
            danielaRigidbody.velocity = new Vector2(-VELOCITY, 0); //left
        }else if (daniela.transform.position.x > -3 && daniela.transform.position.x < -2 && daniela.transform.position.y > -4 && daniela.transform.position.y < -3)
        {
            danielaRigidbody.velocity = new Vector2(0, VELOCITY); //up
        }else if (this.transform.position.x > -3 && this.transform.position.x < -2 && this.transform.position.y > -2 && this.transform.position.y < -1)
        {
            FindObjectOfType<MorganController>().morganShouldMove = true;
            Environment.prologoCasaDanielaMovementDone = true;
            //Environment.prologoCasaDanielaDone = false;
        }
        
        FindObjectOfType<MorganController>().morganShouldMove = true;
        //Environment.prologoCasaDanielaDone = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        daniela = FindObjectOfType<DanielaController>();
        danielaRigidbody = daniela.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Environment.prologoCasaDanielaDone && !Environment.prologoCasaDanielaMovementDone)
        {
            moveDaniela();
        }
    }
}