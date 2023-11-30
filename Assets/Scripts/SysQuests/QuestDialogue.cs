using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDialogue : MonoBehaviour
{
    private QuestManager manager;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void initQuest(int questID, bool startPoint, bool endPoint){
Debug.Log("llamada recibida Mision "+ questID);
        manager = FindObjectOfType<QuestManager>();
        if (!manager.questCompleted[questID]){
            // Si estoy En el punto de inicio y la mision no esta activa
            if (startPoint && !manager.quests[questID].gameObject.activeInHierarchy){
                manager.quests[questID].gameObject.SetActive(true);
                manager.quests[questID].startQuest(); 
                manager.questsList[questID].gameObject.SetActive(true);
                manager.questsList[questID].startListQuest(); 
            }

            if (endPoint){
                manager.quests[questID].CompleteQuest();
                manager.questsList[questID].gameObject.SetActive(false);
            }
        }
    }
    // Update is called once per frame
    public void UpdateQuest(int questID, string text){

        manager = FindObjectOfType<QuestManager>();
        if (!manager.questCompleted[questID]){

                manager.quests[questID].gameObject.SetActive(true);
                manager.quests[questID].startQuest(text); 
                Debug.Log("0");
                manager.questsList[questID].gameObject.SetActive(true);
                manager.questsList[questID].startListQuest(text); 
        }
    }

}
