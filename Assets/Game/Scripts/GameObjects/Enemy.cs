using Assets.Game.Scripts.GameObjects;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : GameObjectController
{
    public GameObject EnemySpawn;
    public string EnemyName { get; set; } = "Shog";
    public float Health { get; private set; } = 350.00f;
    public int Defence { get; private set; } = 10;
    public int Attack { get; private set; } = 5;
    public int AttackSpeed { get; private set; } = 2;
    public int DefaultDice { get; private set; } = 12;

    public void SetEnemyHealth(float number)
    {
        Health -= number;
    }


    public float ReduceEnemyHealth(float enemyDmgInput)
    {
        return Health -= enemyDmgInput;
    }


    public void Lifesteal()
    {
        HeroService.Instance.ReduceHeroHealth(10);
        Health += 5;
    }


    public float EnemyAttack()
    {
        return Attack * DefaultDice;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name is not "Hero") return;

        Debug.Log("Trigger");

        SceneController.EnterFightScreen();
    }

    // TODO Unterklassen von Enemy erstellen
    // TODO Die einzelnen Unterklassen benötigen eine Kampfressource zb Energy oder Mana
}
