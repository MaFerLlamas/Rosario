using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsController : MonoBehaviour
{
    [SerializeField] private GameObject joaquinVariant;
    [SerializeField] private GameObject Arbol;
    [SerializeField] private GameObject Gasolineria;
    // Start is called before the first frame update
    void Start()
    {
        switch (Environment.habloJoaquinCont)
            {

            case 2:
               //Activando variante de Joaquin en el cementerio
               joaquinVariant.SetActive(true);
               break;
            case 3:
                //Activar posicion Arbol
                joaquinVariant.transform.position = Arbol.transform.position;
                joaquinVariant.SetActive(true);
                break;
            case 4:
                //Activar posicion Gasolinera
                joaquinVariant.transform.position = Gasolineria.transform.position;
                break;
            default:
                //Mostrar en Casa
                joaquinVariant.SetActive(false);
                break;
        }
    }

}
