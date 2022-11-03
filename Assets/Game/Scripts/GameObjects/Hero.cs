using Assets.Game.Scripts.GameObjects;
using Assets.Game.Scripts.Db;
using UnityEngine;
using System.Threading.Tasks;
using Unity.VisualScripting;

/// <summary>
/// Helden Spezifische Funktionen
/// </summary>
public class Hero : GameObjectController
{
    public QuestObjects questObjects;
    public QuestPanel panel;
    
    

    public string HeroName = HeroService.Instance.HeroName;
    public int Health = HeroService.Instance.Health;
    public int Insanity = HeroService.Instance.Insanity;
    public int Defence = HeroService.Instance.Defence;
    public int Attack = HeroService.Instance.Attack;
    public int AttackSpeed = HeroService.Instance.AttackSpeed;
    public int DefaultDice = HeroService.Instance.DefaultDice;
    public Vector3 Pos = SaveGameData.Pos;


    // TODO Init() bekommt sp�ter der Scene-Controller
    private async void Start()
    {
        await HeroService.Instance.Init();
    }


    //Methode um Quests auszul�sen, sobald der Hero den Kollider ber�hrt
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        panel.SetQuestWindowActive();
        questObjects.SwitchStatusQuestObjects();

    }

    

}
