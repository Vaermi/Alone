using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObjects : MonoBehaviour
{
   
    int questId;
    string questText;

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
    
}
