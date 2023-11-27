using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsMovementController : MonoBehaviour
{   
    public Transform[] positions;
    public float speed = 2.0f;

    private Vector2 currentStart;
    private Vector2 currentTarget;

    private float journeyLength;
    private float startTime;
    private int pos = 0;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";

    public bool NPCShouldMove = false; 
    public bool isCicled = false; 

    void Start(){
        nextPosition();
    }

    private void nextPosition(){
        //SOLO SI HAY MAS DE UNA POSICION QUE RECORRER PARA EVITAR ERRORES
        //LA POSICION DE INICIO DEBE SER INCLUIDA
        if (positions.Length > 1){
            currentStart = positions[pos].position;
            if (pos == (positions.Length - 1)){//Cuidando no salirnos del array
                if (isCicled){ // pero si el movimiento es repetitivo volvemos al inicio
                    pos = 0;
                    currentTarget = positions[pos].position;
                }
            }else {
                currentTarget = positions[pos+1].position;
                //Siguiente posicion 
                pos++;
            }
            //calcula distancia
            journeyLength = Vector2.Distance(currentStart, currentTarget);
            startTime = Time.time;
        }
    }

    void Update()
    {
            if (NPCShouldMove){
                Move();
            }
    }

    void Move(){
        float distanceCovered = (Time.time - startTime) * speed;
        float journeyPercentage = distanceCovered / journeyLength;
        transform.position = Vector2.Lerp(currentStart, currentTarget, journeyPercentage);

        if (journeyPercentage >= 1.0f)
        {
            //Si se alcanzo la posicion target
            if ((Vector2)transform.position == currentTarget){
                nextPosition();
            }
            /*
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
            }*/
            startTime = Time.time;
        }
    }
}
