using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorganController : MonoBehaviour
{
    public float speed = 4.0f;
    private bool walking = false;
    public Vector2 lastMovement = Vector2.zero;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastVertical = "LastVertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string walkingState = "Walking";

    private Rigidbody2D morganRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        morganRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        walking = false;
        // s = v*t; espacio = velocidad por tiempo
        /*espacio que hay que mover el personaje es producto de la 
        velocidad a la que se mueve el personaje por el tiempo que 
        ha pasado desde la ultima vez que se renderizo un frame */
        if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f)
        {
            /*this.transform.Translate(new Vector3(Input.GetAxisRaw(horizontal)
            * speed *  Time.deltaTime,0,0));*/
            morganRigidbody.velocity = new Vector2(
                Input.GetAxisRaw(horizontal)* speed,
                morganRigidbody.velocity.y);
                walking = true;
                lastMovement = new Vector2(Input.GetAxisRaw(horizontal),0);
        }

        if (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
        {
            /*this.transform.Translate(new Vector3(0,Input.GetAxisRaw(vertical)
            * speed *  Time.deltaTime,0));*/
            morganRigidbody.velocity = new Vector2(
                morganRigidbody.velocity.x,
                Input.GetAxisRaw(vertical)* speed);
                walking = true;
                lastMovement = new Vector2(0,Input.GetAxisRaw(vertical));
        }

        if (!walking){
            morganRigidbody.velocity = Vector2.zero;
        }
    }
}
