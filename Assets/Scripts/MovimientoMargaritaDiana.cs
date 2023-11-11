using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoMargaritaDiana : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D body;
    private float VELOCITY = 5.0f;
    private float startX;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        startX = body.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Environment.habloDianaFinal)
        {
            if(!(body.position.x > startX + 5.0f))
            {
                body.velocity = new Vector2(VELOCITY, 0); //right
            }
            else if(body.position.y < 130.0f)
            {
                body.velocity = new Vector2(0,VELOCITY); //up
            }else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
