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


    public async void UpdateSaveGame()
    {
        await FirebaseService.Instance.UpdateSaveGame(hero, HeroService.Instance.HeroId);
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

        DocumentSnapshot result3 = await FirebaseService.Instance.GetSaveGameAsync();
        int level = result3.GetValue<int>("Level");
        HeroService.Instance.Level = level;

        DocumentSnapshot result4 = await FirebaseService.Instance.GetSaveGameAsync();
        int exp = result4.GetValue<int>("Experience");
        HeroService.Instance.Experience = exp;

        string heroId = result.Id;
        Debug.Log(heroId);
        HeroService.Instance.SetHeroID(heroId);
        SceneController.MainGameScreen();
        
    }

}
