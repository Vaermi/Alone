using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Das QuestPanel steuert die Visuelle Anzeige der Quests.
/// </summary>

public class QuestPanel : MonoBehaviour
{
    public Hero hero;
    public QuestObjects questObjects;
    
    

    //Methode um das Questfenster einzublenden
    public void SetQuestWindowActive()
    {
        gameObject.SetActive(true);
        Debug.Log("Questtext Activatet");
    }


    //Methode um das Questfenster auszublenden
    public void DeactivateQuestWindow() 
    { 
        gameObject.SetActive(false);
        Debug.Log("Questtext Deactivatet");
    }
}
    

