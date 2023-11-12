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
    // Quest 0
    public static bool prologoCasaDanielaDone;
    public static bool prologoCasaDanielaMovementDone;
    public static bool prologoCasaDaniela2Done;
    public static bool prologoCasaDanielaMovement2Done;
    public static bool prologoCasaDanielaDialogo2EscenasDone;
    public static bool prologoCasaDaniela4PM;
    //banderas 3 escena del ayuntamiento
    // Quest 1
    public static bool didDialogueAlreadyPast;
    public static bool didLicThoughtsPast;
    public static bool didDialogueAlreadyPastGlz;
    //banderas 4 y ahora que
    public static bool dialogoChesco1Done;
    public static bool dialogoFueraFabricaAbandonadaDone;
    public static bool dialogoDentroFabricaAbandonadaDone;
    public static bool dialogoAyuntamientoLicDone;
    //banderas 5 algo que hacer
    public static bool algoQueHacerStart;
    public static bool dialogoDanielaAlgoQueHacerDone;
    public static bool visitedCementerio;
    public static bool visitedCerro;
    public static bool visitedGasolinera;
    public static bool visitedGranja;
    public static bool visitedLago;
    public static bool visitedCamping;

    //banderas escenaFinal
    public static bool dialogoDanielaFinalDone;

    //banderas Misiones secundarias
    public static bool habloJose;
    public static bool tieneFotoJose;
    public static bool habloDiana;
    public static bool habloJoseFinal;
    public static bool habloDianaFinal;
    //Propositos de Testig
    //Activar para saltarse los Dialogos 
    public static bool skipDialogueForTestingAll = false;
    void Start()
    {
        camara = FindObjectOfType<CameraFollow>();
        morgan = FindObjectOfType<MorganController>();
        newSpawnName = "spawn Name";
        //casa de daniela
        prologoCasaDanielaDone = false;
        prologoCasaDanielaMovementDone = false;
        prologoCasaDaniela2Done = false;
        prologoCasaDanielaMovement2Done = false;
        prologoCasaDanielaDialogo2EscenasDone=false;
        prologoCasaDaniela4PM = false;

        //3 escena del ayuntamiento
        didDialogueAlreadyPast = false;
        didDialogueAlreadyPastGlz = false;

        //4 y ahora que
        dialogoChesco1Done = false;
        dialogoFueraFabricaAbandonadaDone = false;
        dialogoDentroFabricaAbandonadaDone = false;
        dialogoAyuntamientoLicDone = false;

        //5 algo que hacer
        algoQueHacerStart = false;
        dialogoDanielaAlgoQueHacerDone = false;
        visitedCementerio = false;
        visitedCerro = false;
        visitedGasolinera = false;
        visitedGranja = false;
        visitedLago = false;
        visitedCamping = false;

        //6 final
        dialogoDanielaFinalDone =false;
        

        //Misiones secundarias
        habloJose=false;
        tieneFotoJose = false;
        habloDiana = false;
        habloJoseFinal = false;
        habloDianaFinal = false;
        //testing here
        /* arriba estaran los valores por default que tendra el juego al iniciarse, pero si quieren adelantarse
         * aqui abajo estaran las modificaciones correspondientes para que no tengan que pasar todo el juego"
         * las cuales vamos a borrar cuando salga una version final */
        //didDialogueAlreadyPast = true;
        //didDialogueAlreadyPastGlz = true;
        //dialogoDentroFabricaAbandonadaDone = true;

        /*
        visitedCementerio = true;
        visitedCerro = true;
        visitedGasolinera = true;
        visitedGranja = true;
        visitedLago = true;
        visitedCamping = true;
        */

    }
        public static void VisitedPlace(string place)
    {
        switch (place)
        {
            case "Cementerio":
                Environment.visitedCementerio = true; break;
            case "Cerro":
                Environment.visitedCerro = true; break;
            case "Gasolinera":
                Environment.visitedGasolinera = true;  break;
            case "Granja":
                Environment.visitedGranja = true;  break;
            case "Lago":
                Environment.visitedLago = true; break;
            case "Zona de camping":
                Environment.visitedCamping = true;  break;
            default:
                Debug.Log("unkwnown place, not registred");
                break;
        }
    }

    public static bool algoQueHacerVisitsDone()
    {
        //Debug.Log(visitedCementerio + "/" + visitedCerro + "/" + visitedGasolinera + "/" + visitedGranja + "/" + visitedLago + "/" + visitedCamping);
        return visitedCementerio && visitedCerro && visitedGasolinera && visitedGranja && visitedLago && visitedCamping;
    }
}
