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
    private Animator animator;

    public bool NPCShouldMove = false; 
    public bool isCicled = false; 

    void Start(){
        animator = GetComponent<Animator>();
        if (NPCShouldMove){
            nextPosition();
        }
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

    private void changeAnimationDirection(){
         //Si no hay diferencia en Horizontal entonces se mueve de arriba a abajo
        if (currentTarget.x == currentStart.x){
            if (currentTarget.y > currentStart.y){ // Se mueve hacia arriba
                Debug.Log("Hacia Arriba");
                animator.SetFloat(horizontal, 0);
                animator.SetFloat(vertical, 1);
            }else{ //se mueve hacia abajo
                Debug.Log("Hacia Abajo");
                animator.SetFloat(horizontal, 0);
                animator.SetFloat(vertical, -1);
            }
        } else if (currentTarget.y == currentStart.y){ //Si no hay diferencia en Vertical entonces se mueve hacia los lados
            if (currentTarget.x < currentStart.x){ // Se mueve hacia la Izquierda
                Debug.Log("Hacia Izquierda");
                animator.SetFloat(horizontal, -1);
                animator.SetFloat(vertical, 0);
            }else{ //se mueve hacia la derecha
                Debug.Log("Hacia derecha");
                animator.SetFloat(horizontal, 1);
                animator.SetFloat(vertical, 0);
            }
        }
    }

    void Update()
    {
            if (NPCShouldMove){
                changeAnimationDirection();
                Move();
            }
    }

    private void Move(){
        float distanceCovered = (Time.time - startTime) * speed;
        float journeyPercentage = distanceCovered / journeyLength;
        transform.position = Vector2.Lerp(currentStart, currentTarget, journeyPercentage);

        if (journeyPercentage >= 1.0f)
        {
            //Si se alcanzo la posicion target
            if ((Vector2)transform.position == currentTarget){
                nextPosition();
            }
            startTime = Time.time;
        }
    }
}
