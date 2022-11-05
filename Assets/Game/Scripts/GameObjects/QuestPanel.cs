using UnityEngine;

/// <summary>
/// Das QuestPanel steuert die Visuelle Anzeige der Quests.
/// </summary>

public class QuestPanel : MonoBehaviour
{
    public void SetQuestWindowActive()
    {
        gameObject.SetActive(true);
        Debug.Log("Questtext Activatet");
    }


    public void DeactivateQuestWindow()
    {
        gameObject.SetActive(false);
        Debug.Log("Questtext Deactivatet");
    }
}


