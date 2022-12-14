using Assets.Game.Scripts.Db;
using Assets.Game.Scripts.GameObjects;
using System;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Fight : MonoBehaviour
{
    private HeroService heroService = HeroService.Instance;
    private Hero hero;
    private PlayerPanelController panel;
    public Enemy Enemy;
    public ExitButton exitButton;


    public int Counter = 1;


    private async void Start()
    {
        float heroDice = Random.Range(0, heroService.DefaultDice);
        float enemyDice = Random.Range(0, Enemy.DefaultDice);

        await HeroService.Instance.Init();

        panel = GameObject.FindObjectOfType<PlayerPanelController>();

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

        }
        Counter++;
    }


    public void EnemysTurn()
    {
        FightLog($"{Enemy.EnemyName} ist dran ...\n");

        if (heroService.Health > 0 && Enemy.Health > 0)
        {
            FightLog($"Runde {Counter}\n");
            float enemyDmgOutput = Enemy.EnemyAttack();
            heroService.ReduceHeroHealth(enemyDmgOutput);
            FightLog($"{Enemy.EnemyName} zieht {heroService.HeroName} {enemyDmgOutput} Lebenspunkte ab.\n");
            FightLog($"{heroService.HeroName} hat noch {heroService.Health} Lebenspunkte.\n");

            if (heroService.Health <= 0)
            {
                FightLog($"{heroService.HeroName} ist gestorben. Game Over!\n");
                Counter = 1;
                exitButton.Exit();
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


    public async void AttackClick()
    {
        if (heroService.IsHerosTurn)
        {
            float heroDmgOutput = heroService.HeroAttack();
            Enemy.ReduceEnemyHealth(heroDmgOutput);
            FightLog($"{heroService.HeroName} zieht {Enemy.EnemyName} {heroDmgOutput} Lebenspunkte ab.\n");
            FightLog($"{Enemy.EnemyName} hat noch {Enemy.Health} Lebenspunkte.\n");
            await AfterUserTurn();
        }
    }


    public async void HealClick()
    {
        if (heroService.IsHerosTurn)
        {
            if(Inventory.Instance.HealPotion < 0)
            {
                FightLog($"{heroService.HeroName} benutzt einen Heiltrank.\n");
                heroService.UseHealPotion();
                FightLog($"{heroService.HeroName} heilt sich und hat nun wieder {heroService.Health} Lebenspunkte.\n");
                await AfterUserTurn();
            } 
            else
            {
                FightLog($"Kein Heiltrank im Inventar!\n");
                HerosTurn();
            }
        }
    }


    public async Task RunClick()
    {
        if (heroService.IsHerosTurn)
        {
            FightLog($"{heroService.HeroName} versucht zu fliehen...\n");
            int rndNumber = RunFromFight();
            if (rndNumber >= 70)
            {
                await FirebaseService.Instance.UpdateHeroHealthAsync(heroService.Health, heroService.HeroId);
                SceneController.ExitFightScreen();
                panel.UpdatePanel();
            }
            else
            {
                FightLog($"Fluchtversuch gescheitert!\n");
                await AfterUserTurn();
            }
        }
    }


    public async Task AfterUserTurn()
    {
        heroService.IsHerosTurn = false;
        if (Enemy.Health <= 0)
        {
            FightLog($"{heroService.HeroName} hat gewonnen!\n");
            heroService.IncreaseExperienceAsync();
            await FirebaseService.Instance.UpdateHeroHealthAsync(heroService.Health, heroService.HeroId);
            Counter = 1;
            exitButton.Exit();
            panel.UpdatePanel();
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


    public int RunFromFight()
    {
        int number = HeroService.Instance.RunFromFight();
        return number;
        
    }
}
