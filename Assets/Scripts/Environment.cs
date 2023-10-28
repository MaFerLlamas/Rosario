using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public static string newSpawnName;
    public static bool prologoCasaDanielaDone;
    public static bool prologoCasaDanielaMovementDone;
    public static bool prologoCasaDaniela2Done;
    public static bool prologoCasaDanielaMovement2Done;
    public static bool dialogoChesco1Done;
    public static bool dialogoFueraFabricaAbandonadaDone;
    public static bool dialogoDentroFabricaAbandonadaDone;
    void Start()
    {
        newSpawnName = "spawn Name";
        prologoCasaDanielaDone = false;
        prologoCasaDanielaMovementDone = false;
        prologoCasaDaniela2Done = false;
        prologoCasaDanielaMovement2Done=false;
        dialogoChesco1Done = false;
        dialogoFueraFabricaAbandonadaDone = false;
        dialogoDentroFabricaAbandonadaDone = false;

        //testing here
        /* arriba estaran los valores por default que tendra el juego al iniciarse, pero si quieren adelantarse
         * aqui abajo estaran las modificaciones correspondientes para que no tengan que pasar todo el juego"
         * las cuales vamos a borrar cuando salga una version final */

}
}
