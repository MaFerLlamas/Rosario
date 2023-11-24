using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    private MorganController theMorgan;
    private CameraFollow theCamera;
    public Vector2 facingDirection = Vector2.zero;
    [SerializeField] private string spawnName;
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
                    theCamera.transform.position.z
                );
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
