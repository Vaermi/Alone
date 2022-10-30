using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasse für QuestObjects
/// </summary>

public class QuestObjects : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private int questId;
    public int QuestId { get { return questId; } }

    private string questText;
    public string QuestText { get { return questText; } }

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
