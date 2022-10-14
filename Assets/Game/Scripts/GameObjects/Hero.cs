using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;


/// <summary>
/// Helden Spezifische Funktionen
/// </summary>
public class Hero : TheGameObject
{
    public QuestObjects questObjects;
    public QuestPanel panel;
    private Enemy enemy;

    public string HeroName = "Doris";
    public int Health = 50;
    public int Insanity = 0;
    public int Inventory = 0;       //Counter für Inventory/Placeholder
    public int Defence = 20;
    public int Attack = 5;
    public int AttackSpeed = 3;
    public int DefaultDice = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        panel.SetQuestWindowActive();
        questObjects.SwitchStatusQuestObjects();

    }

    private void Fight()
    {
        float heroDice = Random.Range(0, DefaultDice);
        float enemyDice = Random.Range(0, enemy.DefaultDice);

        if(AttackSpeed > enemy.AttackSpeed)
        {
            Debug.Log("Du beginnst...");
            while(Health != 0 && enemy.Health != 0)
            {
                int counter = 0;

                Debug.Log($"Runde {counter}");
                float heroDmgOutput = Attack * heroDice;
                float enemyDmgInput = heroDmgOutput - enemy.Defence;
                enemy.Health -= (int)enemyDmgInput;
                counter++;
                if(enemy.Health <= 0) Debug.Log("Du hast gewonnen!");

                Debug.Log($"Runde {counter}");
                float enemyDmgOutput = enemy.Attack * enemyDice;
                float heroDmgInput = enemyDmgOutput - Defence;
                Health -= (int)heroDmgInput;
                counter++;
                if(Health <= 0) Debug.Log($"Du bist tot.\n GAME OVER");                
            }

        } else
        {
            Debug.Log("Enemy beginnt...");
            while (Health != 0 && enemy.Health != 0)
            {
                int counter = 0;

                Debug.Log($"Runde {counter}");
                float enemyDmgOutput = enemy.Attack * enemyDice;
                float heroDmgInput = enemyDmgOutput - Defence;
                Health -= (int)heroDmgInput;
                counter++;
                if (Health <= 0) Debug.Log($"Du bist tot.\n GAME OVER");

                Debug.Log($"Runde {counter}");
                float heroDmgOutput = Attack * heroDice;
                float enemyDmgInput = heroDmgOutput - enemy.Defence;
                enemy.Health -= (int)enemyDmgInput;
                counter++;
                if (enemy.Health <= 0) Debug.Log("Du hast gewonnen!");
            }
        }
    }




}
