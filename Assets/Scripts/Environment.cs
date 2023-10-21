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
    void Start()
    {
        newSpawnName = "spawn Name";
        prologoCasaDanielaDone = false;
        prologoCasaDanielaMovementDone = false;
        prologoCasaDaniela2Done = false;
        prologoCasaDanielaMovement2Done=false;
}
}
