using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElisabethController : MonoBehaviour
{   
    public Transform startPosition;
    public Transform endPosition;

    private Transform currentStart;
    

    public float speed = 2.0f;

    private Vector2 currentTarget;
    private float journeyLength;
    private float startTime;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";

    public bool ElizabethShouldMove = false; 
    public bool isInterrupted = false; 


    //private Animator animator;
    //private bool Swap = false;

    void Start(){
        
    //animator = GetComponent<Animator>();

        currentStart = startPosition;
        currentTarget = endPosition.position;
        journeyLength = Vector2.Distance(startPosition.position, endPosition.position);
        startTime = Time.time;
    }

    void Update()
    {
            if (ElizabethShouldMove){
                Move();
            }
    }

    void Move(){
        float distanceCovered = (Time.time - startTime) * speed;
        float journeyPercentage = distanceCovered / journeyLength;
        transform.position = Vector2.Lerp(currentStart.position, currentTarget, journeyPercentage);

        if (journeyPercentage >= 1.0f)
        {
            // Swap the target position when reaching the current target.
            if (currentTarget == (Vector2)endPosition.position)
            {
                if (isInterrupted){
                    ElizabethShouldMove = false;
                }else{
                    currentTarget = startPosition.position;
                    currentStart = endPosition;
                }
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
