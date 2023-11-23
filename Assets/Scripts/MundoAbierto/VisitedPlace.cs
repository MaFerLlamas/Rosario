using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitedPlace : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Environment.VisitedPlace(this.name);
            Debug.Log(Environment.algoQueHacerVisitsDone());
        }
    }
}
