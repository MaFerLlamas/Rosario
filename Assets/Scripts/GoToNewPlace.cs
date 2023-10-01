using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewPlace : MonoBehaviour
{
    public string newPlaceName = "New Scene Name Here";
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("This is a message.");
        if (collision.gameObject.tag.Equals("Player")){
            
            SceneManager.LoadScene(newPlaceName);
        }
    }
}
