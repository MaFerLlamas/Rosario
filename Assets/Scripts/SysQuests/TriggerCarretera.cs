using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TriggerCarretera : MonoBehaviour
{
private TextQuestManager manager;

public string TextSalir; 

private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.tag.Equals("Player"))
        {
         manager.ShowDialog(TextSalir);
        }
}

void Start()
{
      manager = FindObjectOfType<TextQuestManager>();
}

}
