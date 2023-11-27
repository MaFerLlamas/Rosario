using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWaitingTime : MonoBehaviour
{
    //En segundos
    public float waitingTimeBeforeWalk = 1.0f;
    public bool waitBeforeWalk = false;

    IEnumerator DelayedAction()
    {
        // Wait for 2 seconds
        Debug.Log("Start of Coroutine");
        yield return new WaitForSeconds(waitingTimeBeforeWalk);
        FindObjectOfType<NPCsMovementController>().NPCShouldMove = true;
        Debug.Log("After waiting for 2 seconds");
        yield break;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (waitBeforeWalk) StartCoroutine(DelayedAction());
    }

}
