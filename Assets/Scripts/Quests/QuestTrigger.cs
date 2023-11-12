using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class QuestTrigger : MonoBehaviour
{
    private QuestManager manager;
    public int questID;
    public bool startPoint, endPoint;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision){

        manager = FindObjectOfType<QuestManager>();
        // si Morgan choca con este Cuadro
        if (collision.gameObject.tag.Equals("Player")){
            if (!manager.questCompleted[questID]){
                // Si estoy En el punto de inicio y la mision no esta activa
                if (startPoint && !manager.quests[questID].gameObject.activeInHierarchy){
                    manager.quests[questID].gameObject.SetActive(true);
                    manager.quests[questID].startQuest();
                    manager.questsList[questID].gameObject.SetActive(true);
                    manager.questsList[questID].startListQuest(); 
                }

                if (endPoint && manager.quests[questID].gameObject.activeInHierarchy){
                    manager.quests[questID].CompleteQuest();
                }
            }
        }
    }
}
