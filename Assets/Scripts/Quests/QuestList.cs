using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestList : MonoBehaviour
{
    public TMP_Text dialogText;
    public bool questActive;
    public string title, quest;
    // Start is called before the first frame update

    public void startListQuest(){
        Debug.Log(title);
        questActive = true;
        dialogText.text =  "<b>" + title +  ":</b>\n" +  quest;
    }
    public void CompleteQuest(){
    }
}
