using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    //Sirve para que nos lleve a un nuevo nivel
    public void Iniciar()
    {
        SceneManager.LoadScene("Prologo1");
    }

    public void Salir()
    {

        Application.Quit();

    }
}