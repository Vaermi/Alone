using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Helden Spezifische Funktionen
/// </summary>
public class Hero : TheGameObject
{
    public string heroName = "Doris";
    int health;
    int maxHealth;
    int sanity;
    int maxSanity;
    int attack;
    int maxAttack;

    public Hero()
    {

    }
    public Hero(string name)
    {
        this.heroName = name;
    }
   
    public Hero(string name, int health, int sanity, int attack)
    {
        this.heroName = name;
        this.health = health;
        this.sanity = sanity;
        this.attack = attack;
    }

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
