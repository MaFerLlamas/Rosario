using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadowing : MonoBehaviour
{
    // Start is called before the first frame update
    private float darkness;
    private float clarity;
    private bool dark;
    void Start()
    {
        dark = false;
        clarity = 0;
        darkness = 0;
        this.GetComponent<Renderer>().material.color = new Color(0, 0, 0, darkness);
        
        //this.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
            this.transform.position = new Vector2(Environment.morgan.transform.position.x, Environment.morgan.transform.position.y);
        if (Environment.prologoCasaDanielaMovement2Done)
        {
            if(darkness < 255f && !dark)
            {
                darkness+=100*Time.deltaTime;
                this.GetComponent<Renderer>().material.color = new Color(0,0,0,darkness/255);
            }else if(dark && clarity<255)
            {
                //Debug.Log(clarity);
                clarity += 100 * Time.deltaTime;
                this.GetComponent<Renderer>().material.color = new Color(clarity/255, clarity/255, clarity/255, darkness / 255);
            }
            if(darkness > 254)
            {
                dark = true;
                //obscuridad = 0;
            }
            if(clarity > 254)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("PrologoCasaDaniela");
            }
            
        }
    }
}
