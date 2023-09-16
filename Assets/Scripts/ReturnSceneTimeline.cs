using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReturnSceneTimeline : MonoBehaviour
{
    public float changeTime;
    // Update is called once per frame

    void Update()
    {
        changeTime -= Time.deltaTime;
        if (changeTime <= 0){
            ReturnToPreviousScene();
        }
    }

    public void ReturnToPreviousScene()
    {
        // Retrieve the name of the previous scene.
        string previousSceneName = PlayerPrefs.GetString("PreviousScene");
        FindObjectOfType<MorganController>().morganShouldMove = true;

        // Load the previous scene.
        SceneManager.LoadScene(previousSceneName);
    }
}
