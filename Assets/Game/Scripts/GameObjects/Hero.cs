using Assets.Game.Scripts.GameObjects;
using UnityEngine;


/// <summary>
/// Helden Spezifische Funktionen
/// </summary>
public class Hero : TheGameObject
{
    public QuestObjects questObjects;
    public QuestPanel panel;
    
    

    public string HeroName = HeroService.Instance.HeroName;
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

    

}
