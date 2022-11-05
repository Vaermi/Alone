using Assets.Game.Scripts.GameObjects;
using System;
using UnityEngine;

public class Fight : MonoBehaviour
{
    private HeroService heroService;
    private Enemy enemy;

    // TODO Kampf Screen in Unity erstellen
    // TODO Fight Methoden überarbeiten
    public void HeroFirstTurn()
    {
        Console.WriteLine("Du beginnst...");
        int counter = 0;

        while (heroService.Health > 0 && enemy.Health > 0)
        {
            Console.WriteLine($"Runde {counter}");
            float heroDmgOutput = heroService.Attack * heroService.DefaultDice;
            float enemyDmgInput = heroDmgOutput - enemy.Defence;
            enemy.SetEnemyHealth(enemyDmgInput);
            counter++;

            if (enemy.Health <= 0) Console.WriteLine("YOU WIN!");
            Console.WriteLine($"Runde {counter}");
            float enemyDmgOutput = enemy.Attack * enemy.DefaultDice;
            float heroDmgInput = enemyDmgOutput - heroService.Defence;
            heroService.ReduceHeroHealth(heroDmgInput);
            counter++;

            if (heroService.Health <= 0) Console.WriteLine($"You are dead.\n GAME OVER");
            //TODO GAME OVER SCREEN
        }
    }


    public void EnemyFirstTurn()
    {
        Console.WriteLine("Enemy beginnt...");
        int counter = 0;

        while (heroService.Health > 0 && enemy.Health > 0)
        {
            Console.WriteLine($"Runde {counter}");
            float enemyDmgOutput = enemy.Attack * enemy.DefaultDice;
            float heroDmgInput = enemyDmgOutput - heroService.Defence;
            heroService.ReduceHeroHealth(heroDmgInput);
            counter++;

            if (heroService.Health <= 0) Console.WriteLine($"You are dead.\n GAME OVER");
            //TODO GAME OVER SCREEN
            Console.WriteLine($"Runde {counter}");
            float heroDmgOutput = heroService.Attack * heroService.DefaultDice;
            float enemyDmgInput = heroDmgOutput - enemy.Defence;
            enemy.SetEnemyHealth(enemyDmgInput);
            counter++;

            if (enemy.Health <= 0) Console.WriteLine("YOU WIN!");
        }
    }
}
