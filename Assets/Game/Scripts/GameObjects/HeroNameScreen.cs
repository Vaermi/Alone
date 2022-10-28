using Assets.Game.Scripts.Db;
using Assets.Game.Scripts.GameObjects;
using Firebase.Firestore;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeroNameScreen : MonoBehaviour
{
    public TextMeshProUGUI textQuestion;
    public TextMeshProUGUI userInput;


    public void Start()
    {
        //db = FirebaseService.Instance;
        textQuestion = GetComponent<TextMeshProUGUI>();
        string questionHeroName = "Choose a name for your hero: ";
        textQuestion.text = questionHeroName;
        Debug.Log("Start");
       
    }

    //Methode um den Spieler einen Namen für den Hero erstellen zu lassen
    public void CreateHeroName()
    {
        if (HeroService.Instance.HeroName is null)
        {
            userInput = GetComponent<TextMeshProUGUI>();
            string userInputText = userInput.text;
            Debug.Log(userInputText);
            if(userInputText != null) HeroService.Instance.HeroName = userInputText;
            FirebaseService.Instance.SaveHeroNameInDbAsync(HeroService.Instance.HeroName);

        }
    }

    


}

