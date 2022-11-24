using Assets.Game.Scripts.GameObjects;

public class Enemy : GameObjectController
{
    public string EnemyName { get; private set; }
    public float Health { get; private set; }
    public int Defence { get; private set; }
    public int Attack { get; private set; }
    public int AttackSpeed { get; private set; }
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

    // TODO Unterklassen von Enemy erstellen
    // TODO Die einzelnen Unterklassen benötigen eine Kampfressource zb Energy oder Mana
}
