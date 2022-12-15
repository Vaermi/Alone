using Assets.Game.Scripts.Db;
using Assets.Game.Scripts.GameObjects;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class QuestObjects : MonoBehaviour
{
    public string QuestId;
    public GameObject NextQuest;

    public QuestPanelController questPanel;


    public async Task SwitchStatusQuestObjects()
    {
        await GameObject.Find("TextQuests").GetComponent<QuestController>().LoadQuest(QuestId);
        SwitchToNextQuest();
        Destroy(gameObject);
    }


    private async void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name is not "Hero") return;
        
        Debug.Log("Trigger");
        questPanel.SetQuestWindowActive();
        await SwitchStatusQuestObjects();
        await FirebaseService.Instance.UpdateQuestProgressAsync(QuestId, HeroService.Instance.HeroId);
    }


    public void SwitchToNextQuest()
    {
        if (NextQuest == null) return;
        NextQuest?.SetActive(true);
    }

}
