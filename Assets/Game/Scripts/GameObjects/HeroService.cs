using Assets.Game.Scripts.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Scripts.GameObjects
{
    public class HeroService
    {

        private string heroName;
        public string HeroName { get { return heroName; } set { heroName = value; } }

        private int health = 50;
        public int Health { get { return health; } set { health = value; } }

        private int insanity = 0;
        public int Insanity { get { return insanity; } set { insanity = value; } }

        private int defence = 20;
        public int Defence { get { return defence; } set { defence = value; } }

        private int attack = 5;
        public int Attack { get { return attack; } set { attack = value; } }

        private int attackSpeed = 3;
        public int AttackSpeed { get { return attackSpeed; } set { attackSpeed = value; } }

        private int defaultDice = 10;
        public int DefaultDice { get { return defaultDice; } set { defaultDice = value; } }

        private int experience = 0;
        public int Experience { get { return experience; } set { value = experience; } }

       



        private HeroService() { }

        private static HeroService instance;

        public static HeroService Instance 
        { get 
            { 
                if (instance == null) instance = new HeroService();
                return instance; 
            } 
        }

        //Methode zum Abfragen vom Hero Namen zu Beginn
        public async Task Init()
        {
            HeroName = await FirebaseService.Instance.GetHeroNameAsync();
        }


        
        public void ReduceHeroHealth(float heroDmgInput)
        {
            HeroService.Instance.Health -= (int)heroDmgInput;
        }

        // TODO Methode um Health zu erhöhen zb durch Zauber
        public void IncreaseHeroHealth()
        {

        }

       
        public void ReduceInsanity()
        {
            int number = RandomizeInsanityNumber();
            HeroService.Instance.Insanity -= number;
        }

       
        public void IncreaseInsanity()
        {
            int number = RandomizeInsanityNumber();
            HeroService.Instance.Insanity += number;
        }

        public int RandomizeInsanityNumber()
        {
            Random rnd = new Random();
            int number = rnd.Next(0, 20);
            return number;
        }

        // TODO Methode um PlayerPosition zu speichern
        public void CurrentPlayerPosition()
        {

        }

       
        public void IncreaseExperience()
        {
            HeroService.Instance.Experience += 10;
        }

        // TODO Methode die GameOver prüft und GameOverScreen einblendet 
        public void IsDead()
        {

        }

        
        public void UseHealPotion()
        {
            if (Inventory.Instance.HealPotion > 0)
            {
                HeroService.Instance.Health += 30;
                --Inventory.Instance.HealPotion;
            }
        }




    }
}
