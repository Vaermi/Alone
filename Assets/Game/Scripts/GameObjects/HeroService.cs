using Assets.Game.Scripts.Db;
using System.Threading.Tasks;

namespace Assets.Game.Scripts.GameObjects
{
    public class HeroService
    {
        public string HeroName { get; private set; }
        public int Level { get; private set; } = 1;
        public float Health { get; private set; } = 100.00f;
        public int Insanity { get; private set; } = 0;
        public int Defence { get; private set; } = 20;
        public int Attack { get; private set; } = 5;
        public int AttackSpeed { get; private set; } = 3;
        public int DefaultDice { get; private set; } = 10;
        public int Experience { get; private set; } = 0;


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

        //Methode zum Abfragen vom Hero Namen zu Beginn
        public async Task Init()
        {
            HeroName = await FirebaseService.Instance.GetHeroNameAsync();
        }


        public void SetHeroName(string name)
        {
            HeroName = name;
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

        // TODO Methode um PlayerPosition zu speichern
        public void CurrentPlayerPosition()
        {

        }

        // TODO Methode die GameOver prüft und GameOverScreen einblendet 
        public void IsDead()
        {

        }


        public void UseHealPotion()
        {
            if (Inventory.Instance.HealPotion > 0)
            {
                Health += 30;
                Inventory.Instance.RemoveHealPotionFromInventory();
            }
        }

        public void ReduceHeroHealth(float heroDmgInput)
        {
            Health -= heroDmgInput;
        }

        // TODO Methode um Health zu erhöhen zb durch Zauber
        public void IncreaseHeroHealth()
        {


        }


        public void IncreaseExperience()
        {
            Experience += 10;
        }

        // TODO Methode die ein Levelup prüft
        public void CheckExperiencePoints()
        {

        }

        // TODO Methode die ein Level aufstuft
        public void GetLevelUp()
        {

        }


    }
}
