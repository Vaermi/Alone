using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Der FightEventController w�rfelt beim Event Beginn einen W�rfel und vergleicht die AttackSpeed vom Hero und Enemy.
/// Derjenige mit h�heren AttackSpeed beginnt den Kampf, in der Start Methode wird die jeweilige Fight Methode aufgerufen.
/// </summary>

public class FightEventController : Fight
{
    private Hero hero;
    private Enemy enemy;
    private Fight fight;

    private void Start()
    {
        float heroDice = Random.Range(0, hero.DefaultDice);
        float enemyDice = Random.Range(0, enemy.DefaultDice);

        if (hero.AttackSpeed > enemy.AttackSpeed)
        {
            HeroFirstTurn(hero, enemy);
        }
        else if (enemy.AttackSpeed > hero.AttackSpeed)
        {
            EnemyFirstTurn(enemy, hero);
        }
        // TODO bei gleichem AttackSpeed
    }


    
}
