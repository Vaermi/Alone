using Assets.Game.Scripts.Db;
using Firebase.Firestore;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeroNameScreen : MonoBehaviour
{
    //public TextMeshProUGUI textQuestion;
    //public TextMeshProUGUI userInput;
    public Hero hero;


    private void Start()
    {
        //db = FirebaseService.Instance;
        //textQuestion = GetComponent<TextMeshProUGUI>();
        //string questionHeroName = textQuestion.text;
        //questionHeroName = "Gib einen Namen für deinen Helden ein: ";
        Debug.Log("Start");
       

        CreateHeroName();


    }

    //Methode um den Spieler einen Namen für den Hero erstellen zu lassen
    public void CreateHeroName()
    {
        if (hero != null)
        {
            //userInput = GetComponent<TextMeshProUGUI>();
            //string userInputText = userInput.text;
            //userInputText = hero.HeroName;
            //hero.HeroName = "Blabla";
            string userInputText = "Das ist ein Test";
            if (userInputText != null) FirebaseService.Instance.SaveHeroNameInDbAsync(userInputText);


        }
    }

    


}

