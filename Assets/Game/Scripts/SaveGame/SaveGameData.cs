using Assets.Game.Scripts.Db;
using Assets.Game.Scripts.GameObjects;
using Firebase.Firestore;
using System.Threading.Tasks;
using UnityEngine;

public class SaveGameData : MonoBehaviour
{
    private Hero hero;

    private async void Awake()
    {
        await HeroService.Instance.Init();
    }


    private void Start()
    {
        hero = GameObject.FindObjectOfType<Hero>();
        Debug.Log("Save Game Data");
    }


    public async void UpdateSaveGame(string questId)
    {
        await FirebaseService.Instance.UpdateSaveGame(hero, questId, HeroService.Instance.HeroId);
    }

    public async void LoadSaveGame()
    {
        DocumentSnapshot result = await FirebaseService.Instance.GetSaveGameAsync();
        Debug.Log(result);
        string position = result.GetValue<string>("Position");
        HeroService.Instance.Position = position;

        DocumentSnapshot result2 = await FirebaseService.Instance.GetSaveGameAsync();
        int insanity = result2.GetValue<int>("Insanity");
        HeroService.Instance.Insanity = insanity;
        
        string heroId = result.Id;
        Debug.Log(heroId);
        HeroService.Instance.SetHeroID(heroId);
        SceneController.MainGameScreen();
        
    }

}
