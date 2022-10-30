using Assets.Game.Scripts.GameObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inventory-Spezifische Funktionen
/// </summary>

public class Inventory
{
    private int currentInventory = 0;       
    public int CurrentInventory { get { return currentInventory; } set { currentInventory = value; } }

    private int maxInventory = 10;
    public int MaxInventory { get { return maxInventory; } set { maxInventory = value; } }

    private int healPotion = 0;
    public int HealPotion { get { return healPotion; } set { healPotion = value; } }

    private int inventoryCount = 0;
    public int InventoryCount { get { return inventoryCount; } set { inventoryCount = value; } }


    private Inventory() { }
    private static Inventory instance;
    public static Inventory Instance
    {
        get
        {
            if (instance == null) instance = new Inventory();
            return instance;
        }

    }


    //TODO Counter für Inventory/Placeholder
    //TODO Methode um ein HealPotion dem Inventar hinzuzufügen
}
