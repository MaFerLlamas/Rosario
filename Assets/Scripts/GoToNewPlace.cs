using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewPlace : MonoBehaviour
{
    public string newPlaceName = "New Scene Name Here";
    public string newSpawnName = "spawn name";
    public bool isActive = true;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && isActive){
            Environment.newSpawnName = newSpawnName;
            SceneManager.LoadScene(newPlaceName);
        }

    }
}
