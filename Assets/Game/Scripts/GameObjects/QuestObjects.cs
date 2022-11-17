using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObjects : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    public string QuestId;
    public string QuestText { get; private set; }


    public void SwitchStatusQuestObjects()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log(spriteRenderer);
        spriteRenderer.enabled = !spriteRenderer.enabled;
        Debug.Log("Switch Status");
    }

}
