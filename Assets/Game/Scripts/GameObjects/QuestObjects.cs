using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void SwitchStatusQuestObjects()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log(spriteRenderer);
        spriteRenderer.enabled = !spriteRenderer.enabled;
        Debug.Log("Switch Status");
    }
    
}
