using Assets.Game.Scripts.Db;
using Assets.Game.Scripts.GameObjects;
using Firebase.Firestore;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class NameScreenController : MonoBehaviour
{
    public TextMeshProUGUI textQuestion;
    public TextMeshProUGUI userInput;


    public async void Start()
    {
        //db = FirebaseService.Instance;
        string questionHeroName = "Choose a name for your hero: ";
        textQuestion.text = questionHeroName;
        Debug.Log("Start");
              
       
    }

    //Methode um den Spieler einen Namen für den Hero erstellen zu lassen
    public void CreateHeroName()
    {
        if (HeroService.Instance.HeroName is null)
        {
            string userInputText = userInput.text;
            Debug.Log(userInputText);
            if(userInputText != null) HeroService.Instance.HeroName = userInputText;
            FirebaseService.Instance.SetHeroNameAsync(HeroService.Instance.HeroName);
        }
            
    }

    

    


}

