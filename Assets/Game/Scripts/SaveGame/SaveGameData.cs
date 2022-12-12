using Assets.Game.Scripts.Db;
using Assets.Game.Scripts.GameObjects;
using Firebase.Firestore;
using System.Threading.Tasks;
using UnityEngine;

public class SaveGameData : MonoBehaviour
{
    private Hero hero;

    public int CurrentInventory = Inventory.Instance.CurrentInventory;
    public int InventoryCount = Inventory.Instance.InventoryCount;
    


    private async void Awake()
    {
        await HeroService.Instance.Init();
    }


    private void Start()
    {
        hero = GameObject.FindObjectOfType<Hero>();
        Debug.Log("Save Game Data");
       // SetSaveGame("Test1");
    }


    public void SetSaveGame(string name, string heroId)
    {
        FirebaseService.Instance.SetSaveGameAsync(name, heroId);
    }


    public async void UpdateSaveGame()
    {
        await FirebaseService.Instance.UpdateSaveGame(hero, HeroService.Instance.HeroId);
    }

    public async void LoadSaveGame()
    {
        DocumentSnapshot result = await FirebaseService.Instance.GetSaveGame();
        Debug.Log(result);
        string position = result.GetValue<string>("Position");
        HeroService.Instance.Position = position;
        
        string heroId = result.Id;
        Debug.Log(heroId);
        HeroService.Instance.SetHeroID(heroId);
        SceneController.MainGameScreen();
        
    }

}
