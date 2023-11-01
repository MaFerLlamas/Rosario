using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    //general environment
    public static CameraFollow camara;
    public static MorganController morgan;
    public static string newSpawnName;
    //banderas 2, casa de daniela
    public static bool prologoCasaDanielaDone;
    public static bool prologoCasaDanielaMovementDone;
    public static bool prologoCasaDaniela2Done;
    public static bool prologoCasaDanielaMovement2Done;
    //banderas 3 escena del ayuntamiento
    public static bool didDialogueAlreadyPast;
    public static bool didDialogueAlreadyPastGlz;
    //banderas 4 y ahora que
    public static bool dialogoChesco1Done;
    public static bool dialogoFueraFabricaAbandonadaDone;
    public static bool dialogoDentroFabricaAbandonadaDone;
    public static bool dialogoAyuntamientoLicDone;
    //banderas 5 algo que hacer
    void Start()
    {
        camara = FindObjectOfType<CameraFollow>();
        morgan = FindObjectOfType<MorganController>();
        newSpawnName = "spawn Name";
        //casa de daniela
        prologoCasaDanielaDone = false;
        prologoCasaDanielaMovementDone = false;
        prologoCasaDaniela2Done = false;
        prologoCasaDanielaMovement2Done=false;

        //3 escena del ayuntamiento
        didDialogueAlreadyPast = false;
        didDialogueAlreadyPastGlz = false;

        //4 y ahora que
        dialogoChesco1Done = false;
        dialogoFueraFabricaAbandonadaDone = false;
        dialogoDentroFabricaAbandonadaDone = false;
        dialogoAyuntamientoLicDone = false;
        //testing here
        /* arriba estaran los valores por default que tendra el juego al iniciarse, pero si quieren adelantarse
         * aqui abajo estaran las modificaciones correspondientes para que no tengan que pasar todo el juego"
         * las cuales vamos a borrar cuando salga una version final */
        //didDialogueAlreadyPast = true;
        //didDialogueAlreadyPastGlz = true;
        //dialogoDentroFabricaAbandonadaDone = true;
        //fin de testings

}
}
