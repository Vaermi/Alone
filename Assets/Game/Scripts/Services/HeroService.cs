using Assets.Game.Scripts.Db;
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
        public int DefaultDice { get; private set; } = 7;
        public int Experience { get; private set; } = 0;
        public bool IsHerosTurn { get; set; } = false;
        public string Position = "";


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
            Health = await FirebaseService.Instance.GetHeroHealthAsync(HeroId);
            Level = await FirebaseService.Instance.GetHeroLevelAsync(HeroId);
            Insanity = await FirebaseService.Instance.GetHeroInsanityAsync(HeroId);
        }


        public void SetHeroName(string name)
        {
            HeroName = name;
        }


        public void SetHeroID(string id)
        {
            HeroId = id;
        }


        public void SetHeroHealth(float health)
        {
            Health = health;
        }


        //public void GetCurrentQuest()
        //{
        //    FirebaseService.Instance.UpdateQuestProgressAsync(hero, HeroId);
        //}


        public void ReduceInsanity()
        {
            int number = RandomizeInsanityNumber();
            Insanity -= number;
            FirebaseService.Instance.UpdateHeroInsanityAsync(Insanity, HeroId);
        }


        public void IncreaseInsanity()
        {
            int number = RandomizeInsanityNumber();
            Insanity += number;
            FirebaseService.Instance.UpdateHeroInsanityAsync(Insanity, HeroId);
        }


        public int RandomizeInsanityNumber()
        {
            return UnityEngine.Random.Range(0, 20);
        }


        public void UseHealPotion()
        {
            if (Inventory.Instance.HealPotion > 0)
            {
                SetHeroHealth(Health + 30);
                Inventory.Instance.RemoveHealPotionFromInventory();
            }
        }

        public float ReduceHeroHealth(float heroDmgInput)
        {
            float result = Health - heroDmgInput;
            SetHeroHealth(result);
            return result;
        }


        public async void IncreaseHeroHealthOnLevelUp()
        {
            Health += 50;
            await FirebaseService.Instance.UpdateHeroHealthAsync(Health, HeroId);
        }


        public void IncreaseHeroAttackOnLevelUp()
        {
            Attack += 1;
            FirebaseService.Instance.UpdateHeroAttackAsync(Attack, HeroId);
        }


        public void IncreaseExperience()
        {
            Experience += 10;
            CheckExperiencePoints();
            FirebaseService.Instance.UpdateHeroExperienceAsync(Experience, HeroId);
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
            FirebaseService.Instance.UpdateHeroLevelAsync(Level, HeroId);
            IncreaseAttributesOnLevelUp();
        }


        public void IncreaseAttributesOnLevelUp()
        {
            IncreaseHeroHealthOnLevelUp();
            IncreaseDefenceOnLevelUp();
            IncreaseHeroAttackOnLevelUp();
            IncreaseAttackSpeedOnLevelUp();
            IncreaseDefaultDiceOnLevelUp();
        }

        public void IncreaseAttackSpeedOnLevelUp()
        {
            AttackSpeed += 1;
            FirebaseService.Instance.UpdateHeroAttackSpeedAsync(AttackSpeed, HeroId);
        }


        public void IncreaseDefaultDiceOnLevelUp()
        {
            ++DefaultDice;
            FirebaseService.Instance.UpdateHeroDefaultDiceAsync(DefaultDice, HeroId);
        }


        public void IncreaseDefenceOnLevelUp()
        {
            Defence += 2;
            FirebaseService.Instance.UpdateHeroDefenceAsync(Defence, HeroId);
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


        // TODO Methode um Health zu erhöhen zb durch Zauber


    }
}
