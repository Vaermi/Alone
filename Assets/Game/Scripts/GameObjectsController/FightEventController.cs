using Assets.Game.Scripts.GameObjects;
using UnityEngine;

public class FightEventController
{
    private HeroService heroService = HeroService.Instance;
    private Fight fight;
    public Hero hero;
    public Enemy enemy;

    public void StartFight()
    {
        enemy = new Enemy();
        float heroDice = Random.Range(0, heroService.DefaultDice);
        float enemyDice = Random.Range(0, enemy.DefaultDice);

        // TODO Startbedingung überarbeiten

        if (heroService.AttackSpeed > enemy.AttackSpeed)
        {
            fight.HerosTurn();
        }
        else
        {
            fight.EnemysTurn();
        }
    }

}
