using Assets.Game.Scripts.Db;
using System;
using System.Collections.Generic;
using System.Linq;
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



        private HeroService() { }

        private static HeroService instance;

        public static HeroService Instance 
        { get 
            { 
                if (instance == null) instance = new HeroService();
                return instance; 
            } 
        }

        //Methode zum Abfragen vom Hero Namen
        public async Task Init()
        {
            HeroName = await FirebaseService.Instance.GetHeroNameAsync();
        }


    }
}
