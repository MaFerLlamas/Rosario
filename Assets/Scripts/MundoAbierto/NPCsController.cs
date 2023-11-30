using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsController : MonoBehaviour
{
    [SerializeField] private GameObject joaquinVariant;
    [SerializeField] private GameObject joaquinVariantPos2;
    [SerializeField] private GameObject joaquinVariantPos3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         switch (Environment.habloJoaquinCont)
            {

            case 2:
               //Activando variante de Joaquin en el cementerio
               joaquinVariant.SetActive(true);
               break;
            case 3:
                joaquinVariant.transform.position = joaquinVariantPos2.transform.position;
                joaquinVariant.SetActive(true);
                break;
            case 4:
                joaquinVariant.transform.position = joaquinVariantPos3.transform.position;
                joaquinVariant.SetActive(true);
                break;
            default:
                //Mostrar en Casa
                break;
        }
        
    }
}
