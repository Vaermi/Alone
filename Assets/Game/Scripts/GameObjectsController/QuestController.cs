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
    public QuestObjects QuestObj;

    private string questId = "OLdU9m2J33gP89Tt8mH2";
    private DocumentReference quest;
    private DocumentReference subQuest;
    private DocumentSnapshot questSnapshot;


    async void Start()
    {
        QuestText = GetComponent<TextMeshProUGUI>();
        quest = await GetQuestWithID(questId);
        subQuest = quest;
        questSnapshot = await subQuest.GetSnapshotAsync();
        QuestText.text = questSnapshot.GetValue<string>("text");
        //QuestText.text = await GetQuestWithID(questId);
    }


    private void Update()
    {
        if (Panel != null && gameObject.activeSelf && Input.GetKey(KeyCode.Space))
        {
            Panel.DeactivateQuestWindow();
        }
    }


    private async Task<DocumentReference> GetQuestWithID(string id)
    {
        return await FirebaseService.Instance.GetQuestWithIdAsync(id); 
    }


    public void CheckCurrentQuest()
    {
        /*IAsyncEnumerable<CollectionReference> subcollections = subQuest.ListCollectionsAsync();
        if (quest. )
        {
            LastCompletedQuest = CurrentQuest;
            CurrentQuest = string.Empty;

        }
        else
        {
        }*/
    }

}








