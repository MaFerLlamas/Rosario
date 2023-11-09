using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questID;
    private QuestManager manager;

    public string sartText, completeText;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startQuest(){
        manager = FindObjectOfType<QuestManager>();
        manager.showQuestText(completeText);
    }
    public void CompleteQuest(){
        manager.showQuestText(sartText);
        manager.questCompleted[questID] = true;
        gameObject.SetActive(false);
    }
}
