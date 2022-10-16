using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasse für QuestObjects
/// </summary>

public class QuestObjects : MonoBehaviour
{
   
    int questId;
    string questText;
    private SpriteRenderer spriteRenderer;

    public string QuestText
    {
        get
        {
            return questText;
        }
        set
        {
            questText = value;
        }
    }

    public int QuestId 
    { 
        get 
        { 
            return questId; 
        }
    }


    //Methode um den Renderer von QuestObjects zu aktivieren oder deaktivieren.
    //Macht sie sichtbar/unsichtbar in der Spielwelt, bleiben aber immer vorhanden.
    public void SwitchStatusQuestObjects()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log(spriteRenderer);
        spriteRenderer.enabled = !spriteRenderer.enabled;
        Debug.Log("Switch Status");
    }
    
}
