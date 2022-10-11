using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : MonoBehaviour
{
    public Hero hero;
    public QuestObjects questObjects;
    
    // Start is called before the first frame update
    void Start()
    {
        DeactivateQuestWindow();
        
    }

    public void SetQuestWindowActive()
    {
        gameObject.SetActive(true);
        System.Console.WriteLine("Questtext Activatet");
    }

    public void DeactivateQuestWindow() 
    { 
        gameObject.SetActive(false); 
    }
}
    

