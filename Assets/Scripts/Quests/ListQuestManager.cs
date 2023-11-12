using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ListQuestManager : MonoBehaviour
{

    public Quest[] quests;
    public bool[] questActive;

    // Start is called before the first frame update
    void Start()
    {
        //questCompleted = new bool[quests.Length];
    }


    public void showQuestText(string questText){
        //manager.ShowDialog(questText);
        //listManager.ShowDialog(questText);
    }
}
