using Assets.Game.Scripts.Db;
using Assets.Game.Scripts.GameObjects;
using UnityEngine;

public class SaveGameData : MonoBehaviour
{
    public static Vector3 Pos { get; set; }

    public int CurrentInventory = Inventory.Instance.CurrentInventory;
    public int InventoryCount = Inventory.Instance.InventoryCount;


    private async void Awake()
    {
        await HeroService.Instance.Init();
    }


    private void Start()
    {
        SetSaveGame("Test1");
    }


    private void FixedUpdate()
    {
        Pos = transform.position;
    }


    public void SetSaveGame(string name)
    {
        FirebaseService.Instance.SetSaveGameAsync(name);
    }

}
