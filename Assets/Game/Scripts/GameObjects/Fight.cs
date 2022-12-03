using Assets.Game.Scripts.GameObjects;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Fight : MonoBehaviour
{
    private HeroService heroService = HeroService.Instance;
    private Enemy enemy;
    private Hero hero;

    public int Counter = 0;


    public void HerosTurn()
    {
        heroService.IsHerosTurn = true;
        FightLog($"{heroService.HeroName} ist dran...");

        if (heroService.Health > 0 && enemy.Health > 0)
        {
            FightLog($"Runde {Counter}:");

            Counter++;
        }
        EnemysTurn();
    }


    public void EnemysTurn()
    {
        FightLog($"{enemy.EnemyName} ist dran ...");

        if (heroService.Health > 0 && enemy.Health > 0)
        {
            FightLog($"Runde {Counter}");
            float enemyDmgOutput = enemy.EnemyAttack();
            float heroDmgInput = heroService.ReduceHeroHealth(enemyDmgOutput);
            FightLog($"{enemy.EnemyName} zieht {heroService.HeroName} {heroDmgInput} Lebenspunkte ab.");
            heroService.ReduceHeroHealth(heroDmgInput);

            if (heroService.Health <= 0)
            {
                FightLog($"{heroService.HeroName} ist gestorben. Game Over!");
                Counter = 0;
                SceneController.GameOverScreen();
            }
            else
            {
                Counter++;
                heroService.IsHerosTurn = true;
                HerosTurn();
            }

        }
    }


    public void AttackClick()
    {
        if (heroService.IsHerosTurn)
        {
            float heroDmgOutput = heroService.HeroAttack();
            float enemyDmgInput = enemy.ReduceEnemyHealth(heroDmgOutput);
            FightLog($"{heroService.HeroName} zieht {enemy.EnemyName} {enemyDmgInput} Lebenspunkte ab.");
            enemy.SetEnemyHealth(enemyDmgInput);
            FightLog($"{enemy.EnemyName} hat noch {enemy.Health} Lebenspunkte.");
            AfterUserTurn();
        }
    }


    public void HealClick()
    {
        if (heroService.IsHerosTurn)
        {
            FightLog($"{heroService.HeroName} benutzt einen Heiltrank.");
            heroService.UseHealPotion();
            FightLog($"{heroService.HeroName} heilt sich und hat nun wieder {heroService.Health} Lebenspunkte.");
            AfterUserTurn();
        }
    }


    public void RunClick()
    {
        if (heroService.IsHerosTurn)
        {
            FightLog($"{heroService.HeroName} versucht zu fliehen...");
            hero.RunFromFight();
            FightLog($"Fluchtversuch gescheitert!");
            AfterUserTurn();
        }
    }


    public void AfterUserTurn()
    {
        heroService.IsHerosTurn = false;
        if (enemy.Health <= 0)
        {
            FightLog($"{heroService.HeroName} hat gewonnen!");
            heroService.IncreaseExperience();
            Counter = 0;
            SceneController.ExitFightScreen();
        }
        else
        {
            EnemysTurn();
        }
    }


    public string FightLog(string text)
    {
        var goText = GameObject.Find("Scroll View").GetComponent<Text>().text;
        goText += text;
        return goText;
    }
}
