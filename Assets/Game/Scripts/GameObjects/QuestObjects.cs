using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObjects : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public string QuestId;
    public string NextQuestId;
    public string QuestText { get; private set; }
    public bool isActive = false;

    public QuestPanelController questPanel;


    public void SwitchStatusQuestObjects()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log(spriteRenderer);
        spriteRenderer.enabled = !spriteRenderer.enabled;
        Debug.Log("Switch Status");
        GameObject.Find("TextQuests").GetComponent<QuestController>().LoadQuest(QuestId);
        isActive = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name is not "Hero") return;
        
        Debug.Log("Trigger");
        questPanel.SetQuestWindowActive();
        SwitchStatusQuestObjects();
    }


    public void SwitchToNextQuest()
    {
        QuestId = NextQuestId;
        isActive = true;
    }

}
