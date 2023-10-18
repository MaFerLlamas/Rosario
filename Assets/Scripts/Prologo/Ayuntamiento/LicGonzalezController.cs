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

    void Start()
    {
        currentStart = startPosition;
        currentTarget = endPosition.position;
        journeyLength = Vector2.Distance(startPosition.position, endPosition.position);
        startTime = Time.time;
    }

    void Update()
    {
        if (LicGonShouldMove){

            float distanceCovered = (Time.time - startTime) * speed;
            float journeyPercentage = distanceCovered / journeyLength;

            transform.position = Vector2.Lerp(currentStart.position, currentTarget, journeyPercentage);

            if (journeyPercentage >= 1.0f)
            {
                // Swap the target position when reaching the current target.
                if (currentTarget == (Vector2)endPosition.position)
                {
                    currentTarget = startPosition.position;
                    currentStart = endPosition;
                }
                else
                {
                    currentTarget = endPosition.position;
                    currentStart = startPosition;
                }
                startTime = Time.time;
            }
        }
    }
}
