using Assets.Game.Scripts.Db;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Basis-Klasse für die Spielspeicherung
/// </summary>

public class SaveGameData : MonoBehaviour {

    public Camera Camera;

    private static Vector3 pos;
    public static Vector3 Pos { get { return pos; } set { pos = value; } }

    public int CurrentInventory = Inventory.Instance.CurrentInventory;
    public int InventoryCount = Inventory.Instance.InventoryCount;


    private void FixedUpdate()
    {
        pos = transform.position;
    }

    private void Start()
    {
        SetSaveGame("Test1");
    }





    public void SetSaveGame(string name)
    {
        FirebaseService.Instance.SetSaveGameAsync(name);
    }

}
