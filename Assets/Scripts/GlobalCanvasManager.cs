using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalCanvasManager : MonoBehaviour
{
    [SerializeField] public GameObject scrollView; 
    [SerializeField] public GameObject btnOpciones; 
    [SerializeField] public GameObject panelGlobal;

    public void Reiniciar()
    {
        Environment.restart();
        GameObject morgan=GameObject.Find("Morgan");
        if (morgan != null)
        {
            morgan.transform.position = new Vector3(0, 0, 0);
        }
        panelGlobal.SetActive(false);
        btnOpciones.SetActive(true);

        SceneManager.LoadScene("Prologo1");
    }

    public void ShowOptions()
    {
        btnOpciones.SetActive(false);
        panelGlobal.SetActive(true);
    }
    
    public void Continuar()
    {
        btnOpciones.SetActive(true);
        panelGlobal.SetActive(false);
    }

    public void Salir()
    {

        Application.Quit();

    }
  
}
