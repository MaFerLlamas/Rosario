using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    //Sirve para que nos lleve a un nuevo nivel
    public void Iniciar()
    {
        GameObject objectEnvironment = GameObject.Find("Environment");
        if(objectEnvironment!=null) Destroy(objectEnvironment);

        GameObject objectMorgan = GameObject.Find("Morgan");
        if (objectMorgan != null) Destroy(objectMorgan);

        GameObject objectCamera = GameObject.Find("Main Camera");
        if (objectCamera != null) Destroy(objectCamera);

        GameObject objectCanvas = GameObject.Find("GlobalCanvas");
        if (objectCanvas != null) Destroy(objectCanvas);

        GameObject objectManager = GameObject.Find("QuestManager");
        if (objectManager != null) Destroy(objectManager);

        
        SceneManager.LoadScene("Prologo1");

    }

    public void Salir()
    {

        Application.Quit();

    }
}