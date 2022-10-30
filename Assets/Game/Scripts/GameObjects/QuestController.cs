using Assets.Game.Scripts.Db;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

/// <summary>
/// QuestLib ist eine Sammlung von Quests mit Verweis auf die Questobjects
/// </summary>

public class QuestController : MonoBehaviour {
    
    public TextMeshProUGUI questText01;
    public QuestPanel panel;
    public QuestObjects questObjects;

    private string questId01 = "quest01";

    async void Start()
    {

    //TODO mit Datenbank verbinden - Quest 1
    //TODO in Methode auslagern

        if(gameObject.activeSelf)
        {
            if(questText01)
            {
                questText01 = GetComponent<TextMeshProUGUI>();
                string quest01 = questText01.text;
                Debug.Log("Standard Textfeld anzeigen lassen" + quest01);
                QuestObjects questObject01 = gameObject.AddComponent<QuestObjects>();
                Debug.Log("Neues QuestObject erstellen" + questObject01);
                await GetQuestWithID(questId01);
                string text = GetQuestWithID(questId01).Result;
                questText01.text = text;
                Debug.Log("Quest ausgeben" + quest01);

                
            } else if(questText01 == null)
            {
                Debug.Log("Keine Quest aktiv");
            }
        }
    }



    private void Update()
    {
        if (panel != null && gameObject.activeSelf && Input.GetKey(KeyCode.Space))
        {
            panel.DeactivateQuestWindow();
        }
    }

    private async Task<string> GetQuestWithID(string id)
    {
        return await FirebaseService.Instance.GetQuestWithIdAsync(id);
    }

}
