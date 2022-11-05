using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasse für QuestObjects
/// </summary>

public class QuestObjects : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public int QuestId { get; set; }
    public string QuestText { get; set; }


    public void SwitchStatusQuestObjects()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log(spriteRenderer);
        spriteRenderer.enabled = !spriteRenderer.enabled;
        Debug.Log("Switch Status");
    }

}
