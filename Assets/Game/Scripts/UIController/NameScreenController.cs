using Assets.Game.Scripts.Db;
using Assets.Game.Scripts.GameObjects;
using TMPro;
using UnityEngine;

public class NameScreenController : MonoBehaviour
{
    public TextMeshProUGUI textQuestion;
    public TextMeshProUGUI userInput;


    public void CreateHeroName()
    {
        if (HeroService.Instance.HeroName is null)
        {
            string userInputText = userInput.text;
            Debug.Log(userInputText);
            if (userInputText != string.Empty) HeroService.Instance.SetHeroName(userInputText);
            FirebaseService.Instance.SetHeroNameAsync(HeroService.Instance.HeroName);
            SceneController.MainGameScreen();
        }
    }
}

