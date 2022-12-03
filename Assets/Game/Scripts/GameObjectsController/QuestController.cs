using Assets.Game.Scripts.Db;
using Firebase.Firestore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    public TextMeshProUGUI QuestText;
    public QuestPanelController Panel;


    async void Start()
    {
        QuestText = GetComponent<TextMeshProUGUI>();

        //QuestText.text = await GetQuestWithID(questId);
    }


    private void Update()
    {
        if (Panel != null && gameObject.activeSelf && Input.GetKey(KeyCode.Space))
        {
            Panel.DeactivateQuestWindow();
        }
    }

    public async Task LoadQuest(string questId)
    {
        var data = await GetQuestWithID(questId);
        QuestText.text = data.GetValue<string>("text");
    }


    private async Task<DocumentSnapshot> GetQuestWithID(string id)
    {
        return await FirebaseService.Instance.GetQuestWithIdAsync(id);
    }


    public void ClearQuest()
    {
        QuestText.text = "";
    }


}








