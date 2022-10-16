using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{

    private Hero hero;
    private Enemy enemy;


    //Fight-Methode wenn der Hero die erste Runde beginnt
    public void FightHeroFirst(Hero attacker, Enemy defender)
    {

        Console.WriteLine("Du beginnst...");

        int counter = 0;

        while (hero.Health != 0 && enemy.Health != 0)
        {

            Console.WriteLine($"Runde {counter}");

            float heroDmgOutput = hero.Attack * hero.DefaultDice;
            float enemyDmgInput = heroDmgOutput - enemy.Defence;
            enemy.Health -= (int)enemyDmgInput;

            counter++;

            if (enemy.Health <= 0) Console.WriteLine("Du hast gewonnen!");


            Console.WriteLine($"Runde {counter}");

            float enemyDmgOutput = enemy.Attack * enemy.DefaultDice;
            float heroDmgInput = enemyDmgOutput - hero.Defence;
            hero.Health -= (int)heroDmgInput;

            counter++;

            if (hero.Health <= 0) Console.WriteLine($"Du bist tot.\n GAME OVER");
        }
    }



    //Fight-Methode wenn der Enemy die erste Runde beginnt
    public void FightEnemyFirst(Enemy attacker, Hero defender)
    {

        Console.WriteLine("Enemy beginnt...");

        int counter = 0;

        while (hero.Health != 0 && enemy.Health != 0)
        {
            
            Console.WriteLine($"Runde {counter}");

            float enemyDmgOutput = enemy.Attack * enemy.DefaultDice;
            float heroDmgInput = enemyDmgOutput - hero.Defence;
            hero.Health -= (int)heroDmgInput;

            counter++;

            if (hero.Health <= 0) Console.WriteLine($"Du bist tot.\n GAME OVER");


            Console.WriteLine($"Runde {counter}");

            float heroDmgOutput = hero.Attack * hero.DefaultDice;
            float enemyDmgInput = heroDmgOutput - enemy.Defence;
            enemy.Health -= (int)enemyDmgInput;

            counter++;

            if (enemy.Health <= 0) Console.WriteLine("Du hast gewonnen!");
        }
    }
}
