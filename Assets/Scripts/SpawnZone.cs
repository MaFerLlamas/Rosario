using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    private MorganController theMorgan;
    private CameraFollow theCamera;
    public Vector2 facingDirection = Vector2.zero;
    [SerializeField] private string spawnName;
    [SerializeField] private bool interior;
    private float distanciaInterior = 4.0f;
    private float distanciaExterior = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        if  (Environment.newSpawnName != null){

            if(Environment.newSpawnName.Equals(this.spawnName))
            {
                
                theMorgan = FindObjectOfType<MorganController>(); 
                theCamera = FindObjectOfType<CameraFollow>(); 

                theMorgan.transform.position = this.transform.position;
                theCamera.transform.position = new Vector3(
                    this.transform.position.x,
                    this.transform.position.y,
                    -10.0f
                );
                Debug.Log(interior ? "interior" : "exterior");
                theCamera.GetComponent<Camera>().orthographicSize = interior ? distanciaInterior : distanciaExterior;
                //Environment.morgan.setPosition(this.transform.position); //esto no funciona despues vere porque
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
