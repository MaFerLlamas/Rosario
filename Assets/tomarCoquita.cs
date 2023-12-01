using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tomarCoquita : MonoBehaviour
{
    private void Start()
    {
        if (Environment.tieneCoquita)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Environment.dialogoAyuntamientoLicDone)
        {
            Environment.tieneCoquita = true;
            Destroy(this.gameObject);
        }
    }
}
