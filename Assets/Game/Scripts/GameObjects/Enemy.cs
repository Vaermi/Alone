using Assets.Game.Scripts.GameObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy-Spezifische Funktionen
/// </summary>
public class Enemy : GameObjectController
{
    private string enemyName;
    public string EnemyName { get { return enemyName; } }

    private int health;
    public int Health { get { return health; } set { value = health; } }

    private int defence;
    public int Defence { get { return defence; } }

    private int attack;
    public int Attack { get { return attack; } }

    private int attackSpeed;
    public int AttackSpeed { get { return attackSpeed; } }

    private int defaultDice = 12;
    public int DefaultDice { get { return defaultDice; } }


    // TODO Methode um Health zu verringern
    public void ReduceEnemyHealth(float enemyDmgInput)
    {
        Health -= (int)enemyDmgInput;
    }

    // TODO Methode um Leben vom Hero zu stehlen und 50% davon in Selbstheilung umzuwandeln
    public void Lifesteal()
    {
        HeroService.Instance.Health -= 10;
        Health += 5;
    }
}
