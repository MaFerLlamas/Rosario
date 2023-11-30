using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanielaController : MonoBehaviour
{

    public bool danielaShouldMove = false;
    public Transform targetPosition;
    public float speed = 5f; // Adjust this value to control the character's movement speed.


    private void Update()
    {
        /*
        if (danielaShouldMove && targetPosition != null && false){

            // Calculate the direction to the target.
            Vector3 direction = targetPosition.position - transform.position;

            // Normalize the direction vector to get a unit vector.
            direction.Normalize();

            // Move the character towards the target.
            transform.Translate(direction * speed * Time.deltaTime);
        }
        */
    }
}
