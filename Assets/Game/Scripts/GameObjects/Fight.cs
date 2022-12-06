using Assets.Game.Scripts.GameObjects;
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Fight : MonoBehaviour
{
    private HeroService heroService = HeroService.Instance;
    public Enemy Enemy;
    private Hero hero;

    public int Counter = 0;


    private void Start()
    {
        float heroDice = Random.Range(0, heroService.DefaultDice);
        float enemyDice = Random.Range(0, Enemy.DefaultDice);

        // TODO Startbedingung überarbeiten

        if (heroService.AttackSpeed > Enemy.AttackSpeed)
        {
            HerosTurn();
        }
        else
        {
            EnemysTurn();
        }
    }


    public void HerosTurn()
    {
        heroService.IsHerosTurn = true;
        FightLog($"{heroService.HeroName} ist dran...\n");

        if (heroService.Health > 0 && Enemy.Health > 0)
        {
            FightLog($"Runde {Counter}:\n");

            Counter++;
        }
        EnemysTurn();
    }


    public void EnemysTurn()
    {
        FightLog($"{Enemy.EnemyName} ist dran ...\n");

        if (heroService.Health > 0 && Enemy.Health > 0)
        {
            FightLog($"Runde {Counter}\n");
            float enemyDmgOutput = Enemy.EnemyAttack();
            float heroDmgInput = heroService.ReduceHeroHealth(enemyDmgOutput);
            FightLog($"{Enemy.EnemyName} zieht {heroService.HeroName} {heroDmgInput} Lebenspunkte ab.\n");

            if (heroService.Health <= 0)
            {
                FightLog($"{heroService.HeroName} ist gestorben. Game Over!\n");
                Counter = 0;
                //SceneController.GameOverScreen();
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
            float enemyDmgInput = Enemy.ReduceEnemyHealth(heroDmgOutput);
            FightLog($"{heroService.HeroName} zieht {Enemy.EnemyName} {enemyDmgInput} Lebenspunkte ab.\n");
            Enemy.SetEnemyHealth(enemyDmgInput);
            FightLog($"{Enemy.EnemyName} hat noch {Enemy.Health} Lebenspunkte.\n");
            AfterUserTurn();
        }
    }


    public void HealClick()
    {
        if (heroService.IsHerosTurn)
        {
            FightLog($"{heroService.HeroName} benutzt einen Heiltrank.\n");
            heroService.UseHealPotion();
            FightLog($"{heroService.HeroName} heilt sich und hat nun wieder {heroService.Health} Lebenspunkte.\n");
            AfterUserTurn();
        }
    }


    public void RunClick()
    {
        if (heroService.IsHerosTurn)
        {
            FightLog($"{heroService.HeroName} versucht zu fliehen...\n");
            hero.RunFromFight();
            FightLog($"Fluchtversuch gescheitert!\n");
            AfterUserTurn();
        }
    }


    public void AfterUserTurn()
    {
        heroService.IsHerosTurn = false;
        if (Enemy.Health <= 0)
        {
            FightLog($"{heroService.HeroName} hat gewonnen!\n");
            heroService.IncreaseExperience();
            Counter = 0;
            SceneController.ExitFightScreen();
        }
        else
        {
            EnemysTurn();
        }
    }


    public TextMeshProUGUI FightLog(string text)
    {
        var goText = GameObject.Find("Scroll View").GetComponentInChildren<TextMeshProUGUI>();
        goText.text += text;
        return goText;
    }
}
