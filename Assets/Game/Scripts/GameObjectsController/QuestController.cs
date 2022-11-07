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
    public QuestPanelController Panel;
    public QuestObjects QuestObj;

    private string questId = "OLdU9m2J33gP89Tt8mH2";

    async void Start()
    {
        Debug.Log(name);
        QuestText = GetComponent<TextMeshProUGUI>();
        QuestText.text = await GetQuestWithID(questId);
    }


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








