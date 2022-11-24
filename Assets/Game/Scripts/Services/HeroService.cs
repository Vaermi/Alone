﻿using Assets.Game.Scripts.Db;
using System.Threading.Tasks;

namespace Assets.Game.Scripts.GameObjects
{
    public class HeroService
    {
        public string HeroName { get; private set; }
        public string HeroId { get; private set; }  
        public string CurrentQuest { get; private set; }
        public float Health { get; private set; } = 100.00f;
        public int Level { get; private set; } = 1;
        public int Insanity { get; private set; } = 0;
        public int Defence { get; private set; } = 20;
        public int Attack { get; private set; } = 5;
        public int AttackSpeed { get; private set; } = 3;
        public int DefaultDice { get; private set; } = 10;
        public int Experience { get; private set; } = 0;
        public bool IsHerosTurn { get; set; } = false;


        private HeroService() { }
        private static HeroService instance;
        public static HeroService Instance
        {
            get
            {
                if (instance == null) instance = new HeroService();
                return instance;
            }
        }


        public async Task Init()
        {
            HeroName = await FirebaseService.Instance.GetHeroNameAsync(HeroId);
        }


        public void SetHeroName(string name)
        {
            HeroName = name;
        }


        public void SetHeroID(string id)
        {
            HeroId = id;
        }



        public void ReduceInsanity()
        {
            int number = RandomizeInsanityNumber();
            Insanity -= number;
        }


        public void IncreaseInsanity()
        {
            int number = RandomizeInsanityNumber();
            Insanity += number;
        }


        public int RandomizeInsanityNumber()
        {
            return UnityEngine.Random.Range(0, 20);
        }

        // TODO Methode die GameOver prüft und GameOverScreen einblendet 
        public void IsDead()
        {
            if (Health <= 0)
            {
                //GameOverScreen
            }
        }


        public void UseHealPotion()
        {
            if (Inventory.Instance.HealPotion > 0)
            {
                Health += 30;
                Inventory.Instance.RemoveHealPotionFromInventory();
            }
        }

        public float ReduceHeroHealth(float heroDmgInput)
        {
            return Health -= heroDmgInput;
        }

        // TODO Methode um Health zu erhöhen zb durch Zauber
        public void IncreaseHeroHealth()
        {


        }


        public void IncreaseHeroHealthOnLevelUp()
        {
            Health += 10;
        }


        public void IncreaseExperience()
        {
            Experience += 10;
        }


        public void CheckExperiencePoints()
        {
            switch (Experience)
            {
                case 100:
                case 250:
                case 450:
                case 700:
                case 1000:
                case 1350:
                case 1750:
                case 2200:
                case 2700:
                case 3250:
                    GetLevelUp();
                    break;
                default:
                    break;
            }
        }


        public void GetLevelUp()
        {
            ++Level;
        }


        public void IncreaseAttackOnLevelUp()
        {
            Attack += 3;
        }


        public void IncreaseAttackSpeedOnLevelUp()
        {
            AttackSpeed += 2;
        }


        public void IncreaseDefaultDiceOnLevelUp()
        {
            ++DefaultDice;
        }


        public void IncreaseDefenceOnLevelUp()
        {
            Defence += 5;
        }


        public float HeroAttack()
        {
            float dmgOutput = Attack * DefaultDice;
            return dmgOutput;
        }


        public int RunFromFight()
        {
            return UnityEngine.Random.Range(0, 100);
        }


        


    }
}
