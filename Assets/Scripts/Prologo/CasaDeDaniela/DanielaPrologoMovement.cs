using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanielaPrologoMovement : MonoBehaviour
{
    Rigidbody2D danielaRigidbody;
    DanielaController daniela;
    Animator animationDaniela;
    string HORIZONTAL = "Horizontal";
    string VERTICAL = "Vertical";
    
    private float VELOCITY =5.0f;

    public void moveDaniela()
    {   
        if(this.transform.position.x>8 && this.transform.position.x < 9 && this.transform.position.y > -4 && this.transform.position.y < -3)
        {
            danielaRigidbody.velocity= new Vector2(0, VELOCITY); //up
            animationDaniela.SetFloat(HORIZONTAL, 0);
            animationDaniela.SetFloat(VERTICAL, 1);
        }
        else if (daniela.transform.position.x > 8 && daniela.transform.position.x < 9 && daniela.transform.position.y > -2.6f && daniela.transform.position.y < -1.0f){
            danielaRigidbody.velocity = new Vector2(-VELOCITY, 0); //left
            animationDaniela.SetFloat(HORIZONTAL, -1);
            animationDaniela.SetFloat(VERTICAL, 0);
        }
        else if (daniela.transform.position.x > 3 && daniela.transform.position.x < 4 && daniela.transform.position.y > -2.6f && daniela.transform.position.y < -1.0f)
        {
            danielaRigidbody.velocity = new Vector2(0, -VELOCITY ); //down
            animationDaniela.SetFloat(HORIZONTAL, 0);
            animationDaniela.SetFloat(VERTICAL, -1);
        }
        else if (daniela.transform.position.x > 3 && daniela.transform.position.x < 4 && daniela.transform.position.y > -4.5f && daniela.transform.position.y < -3.5f)
        {
            danielaRigidbody.velocity = new Vector2(-VELOCITY, 0); //left
            animationDaniela.SetFloat(HORIZONTAL, -1);
            animationDaniela.SetFloat(VERTICAL, 0);
        }
        else if (daniela.transform.position.x > -3 && daniela.transform.position.x < -2 && daniela.transform.position.y > -4.5f && daniela.transform.position.y < -3.5f)
        {
            danielaRigidbody.velocity = new Vector2(0, VELOCITY); //up
            animationDaniela.SetFloat(HORIZONTAL, 0);
            animationDaniela.SetFloat(VERTICAL, 1);
        }
        else if (this.transform.position.x > -3 && this.transform.position.x < -2 && this.transform.position.y > -2 && this.transform.position.y < -1)
        {
            FindObjectOfType<MorganController>().morganShouldMove = true;
            Environment.prologoCasaDanielaMovementDone = true;
            animationDaniela.SetFloat(HORIZONTAL, 0); //idle
            animationDaniela.SetFloat(VERTICAL, 0);
        }
        
    }

    public void regresarDaniela()
    {
        //Debug.Log(danielaRigidbody.velocity.x+"/"+ danielaRigidbody.velocity.y);
        if (this.transform.position.x > -2.5 && this.transform.position.x < -1.5 && this.transform.position.y > -2 && this.transform.position.y < -1)
        {
            danielaRigidbody.velocity = new Vector2(0, -VELOCITY); //down
            animationDaniela.SetFloat(HORIZONTAL, 0);
            animationDaniela.SetFloat(VERTICAL, -1);
            //Debug.Log("step 1");
        }
        else if (daniela.transform.position.x > -2.5 && daniela.transform.position.x < 4 && daniela.transform.position.y > -4.6f && daniela.transform.position.y < -3.5f)
        {
            danielaRigidbody.velocity = new Vector2(VELOCITY, 0); //right
            animationDaniela.SetFloat(HORIZONTAL, 1);
            animationDaniela.SetFloat(VERTICAL, 0);
            //Debug.Log("step 2");
        }
        else if (daniela.transform.position.x > 4 && daniela.transform.position.x < 5 && daniela.transform.position.y > -4.5f && daniela.transform.position.y < -3.5f)
        {
            danielaRigidbody.velocity = new Vector2(0, VELOCITY); //up
            animationDaniela.SetFloat(HORIZONTAL, 0);
            animationDaniela.SetFloat(VERTICAL, 1);
            //Debug.Log("step 3");
        }
        else if (daniela.transform.position.x > 4 && daniela.transform.position.x < 5 && daniela.transform.position.y > -2.6f && daniela.transform.position.y < -1.6f)
        {
            danielaRigidbody.velocity = new Vector2(VELOCITY, 0); //right
            animationDaniela.SetFloat(HORIZONTAL, 1);
            animationDaniela.SetFloat(VERTICAL, 0);
            //Debug.Log("step 4");
        }
        else if (daniela.transform.position.x > 8 && daniela.transform.position.x < 9 && daniela.transform.position.y > -2.6f && daniela.transform.position.y < -1.6f)
        {
            danielaRigidbody.velocity = new Vector2(0, -VELOCITY); //down
            animationDaniela.SetFloat(HORIZONTAL, 0);
            animationDaniela.SetFloat(VERTICAL, -1);
            //Debug.Log("step 5");
        }
        else if (this.transform.position.x > 8 && this.transform.position.x < 9 && this.transform.position.y > -4.5 && this.transform.position.y < -3.5)
        {
            danielaRigidbody.velocity = new Vector2(VELOCITY, 0); //right
            animationDaniela.SetFloat(HORIZONTAL, 1);
            animationDaniela.SetFloat(VERTICAL, 0);
            FindObjectOfType<MorganController>().morganShouldMove = true;
            Environment.prologoCasaDanielaMovement2Done = true;
            //Debug.Log("finish");
            //Environment.prologoCasaDanielaDone = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        daniela = FindObjectOfType<DanielaController>();
        danielaRigidbody = daniela.GetComponent<Rigidbody2D>();
        animationDaniela = daniela.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Environment.prologoCasaDanielaDone && !Environment.prologoCasaDanielaMovementDone)
        {
            moveDaniela();
        }else if (Environment.prologoCasaDaniela2Done && !Environment.prologoCasaDanielaMovement2Done)
        {
            regresarDaniela();
        }
    }
}
