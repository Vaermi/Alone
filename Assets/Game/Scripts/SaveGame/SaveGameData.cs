using Assets.Game.Scripts.Db;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basis-Klasse für die Spielspeicherung
/// </summary>

public class SaveGameData : MonoBehaviour {

    private static Vector3 pos;
    public static Vector3 Pos { get { return pos; } set { pos = value; } }

    public int CurrentInventory = Inventory.Instance.CurrentInventory;
    public int InventoryCount = Inventory.Instance.InventoryCount;


    public void SetSaveGame()
    {
        FirebaseService.Instance.SetSaveGameAsync("test 1");
    }

}
