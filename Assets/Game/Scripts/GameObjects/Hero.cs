using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;


/// <summary>
/// Helden Spezifische Funktionen
/// </summary>
public class Hero : TheGameObject
{
    public QuestObjects questObjects;
    public QuestPanel panel;
    private Enemy enemy;

    public string HeroName = "";
    public int Health = 50;
    public int Insanity = 0;
    public int Inventory = 0;       //Counter f�r Inventory/Placeholder
    public int Defence = 20;
    public int Attack = 5;
    public int AttackSpeed = 3;
    public int DefaultDice = 10;



    //Methode um Quests auszul�sen, sobald der Hero den Kollider ber�hrt
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        panel.SetQuestWindowActive();
        questObjects.SwitchStatusQuestObjects();

    }

    //Methode um den Spieler einen Namen f�r den Hero erstellen zu lassen
    public void CreateHeroName()
    {
        Console.WriteLine("Gib einen Namen f�r deinen Helden ein:");
        HeroName = Console.ReadLine();
        Console.WriteLine($"Dein Name ist: {HeroName}");
    }

    


    



}
