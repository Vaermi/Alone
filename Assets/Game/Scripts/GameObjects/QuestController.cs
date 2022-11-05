using Assets.Game.Scripts.Db;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

/// <summary>
/// QuestLib ist eine Sammlung von Quests mit Verweis auf die Questobjects
/// </summary>

public class QuestController : MonoBehaviour
{

    public TextMeshProUGUI QuestText;
    public QuestPanel Panel;
    public QuestObjects QuestObj;

    private string questId = "OLdU9m2J33gP89Tt8mH2";

    async void Start()
    {
        //TODO in Methode auslagern

        if (gameObject.activeSelf)
        {
            if (QuestText)
            {
                QuestText = GetComponent<TextMeshProUGUI>();
                string quest01 = QuestText.text;
                Debug.Log("Standard Textfeld anzeigen lassen" + quest01);
                QuestObjects questObject01 = gameObject.AddComponent<QuestObjects>();
                Debug.Log("Neues QuestObject erstellen" + questObject01);
                string text = await GetQuestWithID(questId);
                QuestText.text = text;
                Debug.Log("Quest ausgeben" + quest01);


            }
            else if (QuestText == null)
            {
                Debug.Log("Keine Quest aktiv");
            }
        }
    }
    /*if (gameObject.activeSelf)
    {
        QuestHandler(QuestText, QuestObj, questId);
    }*/
    private void Update()
    {
        if (Panel != null && gameObject.activeSelf && Input.GetKey(KeyCode.Space))
        {
            Panel.DeactivateQuestWindow();
        }
    }
    private async Task<string> GetQuestWithID(string id)
    {
        return await FirebaseService.Instance.GetQuestWithIdAsync(id);
    }

}

    /*public async Task<string> QuestHandler(TextMeshProUGUI questText, QuestObjects questObj, string id)
    {
        string text;
        if (QuestText)
        {
            QuestText = GetComponent<TextMeshProUGUI>();
            string quest01 = QuestText.text;
            questObj = gameObject.AddComponent<QuestObjects>();
            text = await GetQuestWithID(id);
            return text;
        }
        else 
        {
            Debug.Log("Keine Quest aktiv");
        }
    }*/







