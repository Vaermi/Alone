using UnityEngine;

public class QuestPanelController : MonoBehaviour
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


