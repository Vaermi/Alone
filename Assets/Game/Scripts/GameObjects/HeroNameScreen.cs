using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeroNameScreen : MonoBehaviour
{
    public TextMeshProUGUI textQuestion;
    public TextMeshProUGUI userInput;
    public Hero hero;

    private void Awake()
    {
        textQuestion.text = "Gib einen Namen für deinen Helden ein: ";
        if (hero.HeroName == "")
        {
            CreateHeroName();
        }


    }

    //Methode um den Spieler einen Namen für den Hero erstellen zu lassen
    public void CreateHeroName()
    {
        //TODO lese Name vom Hero Screen aus
        hero.HeroName = userInput.text;
    }



}

