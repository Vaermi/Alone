using Assets.Game.Scripts.GameObjects;
using UnityEngine;

public class FightEventController : Fight
{
    private HeroService heroService;
    private Enemy enemy;

    private void Start()
    {
        float heroDice = Random.Range(0, heroService.DefaultDice);
        float enemyDice = Random.Range(0, enemy.DefaultDice);

        // TODO Startbedingung überarbeiten

        if (heroService.AttackSpeed > enemy.AttackSpeed)
        {
            HeroFirstTurn();
        }
        else
        {
            EnemyFirstTurn();
        }
    }

}
