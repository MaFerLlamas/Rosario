using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LicGonzalezController : MonoBehaviour
{
    
    public Transform startPosition;
    public Transform endPosition;
    private Transform currentStart;

    public float speed = 2.0f;

    private Vector2 currentTarget;
    private float journeyLength;
    private float startTime;

    public bool LicGonShouldMove = false; 
    public bool LicGonStopMoving = false; 

    void Start()
    {
        currentStart = startPosition;
        currentTarget = endPosition.position;
        journeyLength = Vector2.Distance(startPosition.position, endPosition.position);
        startTime = Time.time;
    }

    void Update()
    {
        if (true){

            float distanceCovered = (Time.time - startTime) * speed;
            float journeyPercentage = distanceCovered / journeyLength;

            if (LicGonShouldMove)
                transform.position = Vector2.Lerp(currentStart.position, currentTarget, journeyPercentage);

            if (journeyPercentage >= 1.0f )
            {
                // Swap the target position when reaching the current target.
                if (currentTarget == (Vector2)endPosition.position)
                {
                    if (LicGonShouldMove){
                        currentTarget = startPosition.position;
                        currentStart = endPosition;
                    }else{
                        LicGonStopMoving = true;
                    }
                }
                else
                {
                    if (LicGonShouldMove){
                        currentTarget = endPosition.position;
                        currentStart = startPosition;
                    }else{
                        LicGonStopMoving = true;
                    }
                }
                startTime = Time.time;
            }
        }
    }
}
