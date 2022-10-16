using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basis-Klasse für die Spielspeicherung
/// </summary>

public class SaveGameData
{
    public static SaveGameData current = new SaveGameData();

    public Inventory inventory = new Inventory();

}
