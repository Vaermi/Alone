using Assets.Game.Scripts.GameObjects;
using UnityEngine;

/// <summary>
/// Der FightEventController würfelt beim Event Beginn einen Würfel und vergleicht die AttackSpeed vom Hero und Enemy.
/// Derjenige mit höheren AttackSpeed beginnt den Kampf, in der Start Methode wird die jeweilige Fight Methode aufgerufen.
/// </summary>

public class FightEventController : Fight
{
    private HeroService heroService;
    private Enemy enemy;

    private void Start()
    {
        float heroDice = Random.Range(0, heroService.DefaultDice);
        float enemyDice = Random.Range(0, enemy.DefaultDice);

        // TODO Eventuell Startbedingung überarbeiten

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
