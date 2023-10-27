using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LicGonzalezController : MonoBehaviour
{
    
    public Transform startPosition;
    public Transform endPosition;
    private Transform currentStart;
    [SerializeField] private GameObject dialogueMark1;
    [SerializeField] private GameObject dialogueMark2;
    

    public float speed = 2.0f;

    private Vector2 currentTarget;
    private float journeyLength;
    private float startTime;

    public bool LicGonShouldMove = false; 
    public bool isInterrupted = false; 
    public bool showThoughts= false; 
    private Rigidbody2D rb; 

    void Start(){
        rb = GetComponent<Rigidbody2D>();
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
                    if (showThoughts){
                        dialogueMark1.SetActive(true);
                        dialogueMark2.SetActive(false);
                    }
                    currentTarget = startPosition.position;
                    currentStart = endPosition;
                }
                else
                {
                    if(showThoughts){
                        dialogueMark1.SetActive(false);
                        dialogueMark2.SetActive(true);
                    }
                    currentTarget = endPosition.position;
                    currentStart = startPosition;
                }
                startTime = Time.time;
            }
        }else{
            if (isInterrupted){
                rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, 1 * Time.deltaTime);
                // Once velocity is sufficiently low, set isInterrupted to false.
                if (rb.velocity.magnitude < 1.0f){
                    isInterrupted = false;
                }
            }
        }
    }
}