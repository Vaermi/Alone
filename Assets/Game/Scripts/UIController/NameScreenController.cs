using Assets.Game.Scripts.Db;
using Assets.Game.Scripts.GameObjects;
using TMPro;
using UnityEngine;

public class NameScreenController : MonoBehaviour
{
    public TextMeshProUGUI textQuestion;
    public TextMeshProUGUI userInput;


    public async void CreateHeroName()
    {
        string userInputText = userInput.text;
        if (userInputText != string.Empty) HeroService.Instance.SetHeroName(userInputText);
        string id = await FirebaseService.Instance.SetInitialSaveGameAsync(userInputText);
        HeroService.Instance.SetHeroID(id);
        SceneController.MainGameScreen();
    }
}

