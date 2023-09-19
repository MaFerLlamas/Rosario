using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorganController : MonoBehaviour
{
    public float speed = 4.0f;


    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastVertical = "LastVertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string walkingState = "Walking";


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // s = v*t; espacio = velocidad por tiempo
        /*espacio que hay que mover el personaje es producto de la 
        velocidad a la que se mueve el personaje por el tiempo que 
        ha pasado desde la ultima vez que se renderizo un frame */
        if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f)
        {
            this.transform.Translate(new Vector3(Input.GetAxisRaw(horizontal)
            * speed *  Time.deltaTime,0,0));
           
        }

        if (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
        {
            this.transform.Translate(new Vector3(0,Input.GetAxisRaw(vertical)
            * speed *  Time.deltaTime,0));
            
        }
    }
}
