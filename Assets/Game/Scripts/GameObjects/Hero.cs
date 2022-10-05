using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Helden Spezifische Funktionen
/// </summary>
public class Hero : TheGameObject
{
    public string heroName;
    public int health = 50;
    int maxHealth = 100;
    public int sanity = 0;
    int maxSanity = 100;
    int attack = 250;
    int maxAttack = 1000;

    
    public Hero(string name, int health,int maxHealth, int sanity,int maxSanity, int attack, int maxAttack)
    {
        this.heroName = name;
        this.health = health;
        this.maxHealth = maxHealth;
        this.sanity = sanity;
        this.maxSanity = maxSanity;
        this.attack = attack;
        this.maxAttack = maxAttack;
    }


    


}
