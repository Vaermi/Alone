using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy-Spezifische Funktionen
/// </summary>
public class Enemy : GameObjectController
{
    public string EnemyName;
    public int Health;
    public int Defence;
    public int Attack;
    public int AttackSpeed;
    public int DefaultDice = 12;
}
