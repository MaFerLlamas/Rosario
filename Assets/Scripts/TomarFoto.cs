using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomarFoto : MonoBehaviour
{
    private void Start()
    {
        if (Environment.tieneFotoJose)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Environment.habloJose)
        {
            Environment.tieneFotoJose = true;
            Destroy(this.gameObject);
            FindObjectOfType<GoToNewPlace>().isActive = true;
        }
    }
}
