using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest[] quests;
    public QuestList[] questsList;
    public bool[] questCompleted;
    public bool[] questActive;


    private TextQuestManager manager;
    // Start is called before the first frame update
    void Start()
    {
        questCompleted = new bool[quests.Length];
        questActive = new bool[quests.Length];
        manager = FindObjectOfType<TextQuestManager>();
    }


    public void showQuestText(string questText){
        manager.ShowDialog(questText);
    }
}