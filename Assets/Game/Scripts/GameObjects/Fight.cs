using Assets.Game.Scripts.GameObjects;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Fight : MonoBehaviour
{
    private HeroService heroService;
    private Enemy enemy;
    private Hero hero;
    private SceneController sceneController;

    public int Counter = 0;

    public void HerosTurn()
    {
        heroService.IsHerosTurn = true;
        FightLog($"{HeroService.Instance.HeroName} ist dran...");

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
            float heroDmgInput = HeroService.Instance.ReduceHeroHealth(enemyDmgOutput);
            FightLog($"{enemy.EnemyName} zieht {HeroService.Instance.HeroName} {heroDmgInput} Lebenspunkte ab.");
            heroService.ReduceHeroHealth(heroDmgInput);

            if (heroService.Health <= 0)
            {
                FightLog($"{HeroService.Instance.HeroName} ist gestorben. Game Over!");
                Counter = 0;
                SceneController.GameOverScreen();
            }

            Counter++;
            heroService.IsHerosTurn = true;
            HerosTurn();
        }
    }


    public void AttackClick()
    {
        if (heroService.IsHerosTurn)
        {
            float heroDmgOutput = heroService.HeroAttack();
            float enemyDmgInput = enemy.ReduceEnemyHealth(heroDmgOutput);
            FightLog($"{HeroService.Instance.HeroName} zieht {enemy.EnemyName} {enemyDmgInput} Lebenspunkte ab.");
            enemy.SetEnemyHealth(enemyDmgInput);
            FightLog($"{enemy.EnemyName} hat noch {enemy.Health} Lebenspunkte.");
            AfterUserTurn();
        }
    }


    public void HealClick()
    {
        if (heroService.IsHerosTurn)
        {
            Debug.Log($"{HeroService.Instance.HeroName} benutzt einen Heiltrank.");
            HeroService.Instance.UseHealPotion();
            Debug.Log($"{HeroService.Instance.HeroName} heilt sich und hat nun wieder {HeroService.Instance.Health} Lebenspunkte.");
            AfterUserTurn();
        }
    }


    public void RunClick()
    {
        if (heroService.IsHerosTurn)
        {
            FightLog($"{HeroService.Instance.HeroName} versucht zu fliehen...");
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
            FightLog($"{HeroService.Instance.HeroName} hat gewonnen!");
            HeroService.Instance.IncreaseExperience();
            Counter = 0;
            sceneController.ExitFightScreen();
        }
        else
        {
            EnemysTurn();
        }
    }


    public string FightLog(string text)
    {
        return text;
    }
}
