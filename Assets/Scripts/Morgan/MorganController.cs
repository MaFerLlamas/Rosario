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
    public bool morganShouldMove = true;

    private Animator animator;

    public static bool isMorganCreated;
    private Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();

        if(!isMorganCreated){
            isMorganCreated = true;
            playerRigidbody = GetComponent<Rigidbody2D>();
            DontDestroyOnLoad(this.transform.gameObject);
        }else{
            Destroy(gameObject);
        }
    }
    public Vector2 getPosition()
    {
        return playerRigidbody.position;
    }
    public void setPosition(Vector2 newPosition)
    {
        playerRigidbody.position = newPosition;
    }
    public void setPosition(Vector3 newPosition)
    {
        playerRigidbody.position = new Vector2 (newPosition.x, newPosition.y);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 20.0f;
            Environment.setMorganRunning(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 4.0f;
            Environment.setMorganRunning(false);
        }

        if (morganShouldMove){
            // s = v*t; espacio = velocidad por tiempo
            /*espacio que hay que mover el personaje es producto de la 
            velocidad a la que se mueve el personaje por el tiempo que 
            ha pasado desde la ultima vez que se renderizo un frame */
            if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f)
            {
                this.transform.Translate(new Vector3(Input.GetAxisRaw(horizontal)
                * speed *  Time.deltaTime,0,0));
                /*playerRigidbody.velocity = new Vector2(
                    Input.GetAxisRaw(horizontal)*speed, playerRigidbody.velocity.y);*/
            
            }
            if (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
            {
                this.transform.Translate(new Vector3(0,Input.GetAxisRaw(vertical)
                * speed *  Time.deltaTime,0));
                /*playerRigidbody.velocity = new Vector2(
                    playerRigidbody.velocity.x, Input.GetAxisRaw(vertical)*speed);   */
            }
        }else
        {
            if (Environment.direccion.Equals(Environment.ARRIBA))
            {
                animator.SetFloat(horizontal, 1);
                animator.SetFloat(vertical, 0);
            }else if (Environment.direccion.Equals(Environment.ABAJO))
            {
                animator.SetFloat(horizontal, -1);
                animator.SetFloat(vertical, 0);
            }
            else if (Environment.direccion.Equals(Environment.DERECHA))
            {
                animator.SetFloat(horizontal, 0);
                animator.SetFloat(vertical, 1);
            }
            else if (Environment.direccion.Equals(Environment.IZQUIERDA))
            {
                animator.SetFloat(horizontal, 0);
                animator.SetFloat(vertical, -1);
            }
        }
        
        animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        animator.SetFloat(vertical, Input.GetAxisRaw(vertical));
    }

}