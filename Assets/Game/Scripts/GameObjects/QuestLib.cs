using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class QuestLib : MonoBehaviour {
    
    public TextMeshProUGUI questText01;
    //public Hero hero;
    public QuestPanel panel;
    public QuestObjects questObjects;

    void Start()
    {
    //Quest 1

        if(gameObject.activeSelf)
        {
            if(questText01)
            {
                questText01 = GetComponent<TextMeshProUGUI>();
                string quest01 = questText01.text;
                Debug.Log("Standard Textfeld anzeigen lassen" + quest01);
                QuestObjects questObject01 = gameObject.AddComponent<QuestObjects>();
                Debug.Log("Neues QuestObject erstellen" + questObject01);

                questObject01.QuestText = "Du erwachst alleine in einem dunklen Wald. Wie bist du hierher gekommen? Neben dir liegt eine kryptische Nachricht:" +
                    "\"Suche mich bei den Felsen. -V.\"\n\n - Weiter mit Leertaste - ";

                questText01.text = questObject01.QuestText;
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

}
