using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScenePrologue : MonoBehaviour
{
    //Tiempo a esperar para cuando termine la escena
    public float endTime;

    // Update is called once per frame
    void Update()
    {
        endTime -= Time.deltaTime;
        if (endTime <= 0){
            ReturnToGame();
        }
    }

    public void ReturnToGame()
    {
        FindObjectOfType<CameraFollow>().followTarget = GameObject.Find("Morgan");
        FindObjectOfType<MorganController>().morganShouldMove = true;
    }
}
