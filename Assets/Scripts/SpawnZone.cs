using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    private MorganController theMorgan;
    private CameraFollow theCamera;
    // Start is called before the first frame update
    void Start()
    {
        theMorgan = FindObjectOfType<MorganController>(); 
        theCamera = FindObjectOfType<CameraFollow>(); 

        theMorgan.transform.position = this.transform.position;
        theCamera.transform.position = new Vector3(
            this.transform.position.x,
            this.transform.position.y,
            theCamera.transform.position.z
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
