using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;


/// <summary>
/// Helden Spezifische Funktionen
/// </summary>
public class Hero : TheGameObject
{
    public QuestObjects questObjects;
    public QuestPanel panel;

    public string HeroName = "Doris";
    public int Health = 50;
    public int Sanity = 0;
    public int Inventory = 0;       //Counter für Inventory/Placeholder
    int maxHealth = 100;    
    int maxSanity = 100;
    int attack = 250;
    int maxAttack = 1000;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        panel.SetQuestWindowActive();
    }






}
