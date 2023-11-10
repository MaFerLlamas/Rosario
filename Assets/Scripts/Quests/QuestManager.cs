using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest[] quests;
    public bool[] questCompleted;


    private MisionsTextManager manager;
    private MisionsListManager listManager;
    // Start is called before the first frame update
    void Start()
    {
        questCompleted = new bool[quests.Length];
        manager = FindObjectOfType<MisionsTextManager>();
        listManager = FindObjectOfType<MisionsListManager>();
    }


    public void showQuestText(string questText){
        manager.ShowDialog(questText);
        //listManager.ShowDialog(questText);
    }
}