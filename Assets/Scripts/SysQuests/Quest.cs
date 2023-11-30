using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questID;
    private QuestManager manager;

    public string startText, completeText;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame

    public void startQuest(){
        Debug.Log("title start quest" + startText);
        manager = FindObjectOfType<QuestManager>();
        manager.showQuestText(startText);
    }
    public void startQuest(string newText){
        Debug.Log("title start quest; with string" + newText);
        manager = FindObjectOfType<QuestManager>();
        manager.showQuestText(newText);
    }
    public void CompleteQuest(){
        //manager.showQuestText(completeText);
        manager.questCompleted[questID] = true;
        gameObject.SetActive(false);
    }
}
