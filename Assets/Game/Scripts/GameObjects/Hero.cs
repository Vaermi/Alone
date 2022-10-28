using Assets.Game.Scripts.Db;
using Firebase.Firestore;
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
    private FirebaseService testdb;

    public string HeroName = "";
    public int Health = 50;
    public int Insanity = 0;
    public int Inventory = 0;       //Counter für Inventory/Placeholder
    public int Defence = 20;
    public int Attack = 5;
    public int AttackSpeed = 3;
    public int DefaultDice = 10;



    //Methode um Quests auszulösen, sobald der Hero den Kollider berührt
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        panel.SetQuestWindowActive();
        questObjects.SwitchStatusQuestObjects();

    }

    private void Start()
    {
        /*Debug.Log("Db in Hero");
        testdb.SaveHeroNameInDb("Linz");
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        Debug.Log(db);*/
    }

}
