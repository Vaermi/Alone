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
        public float MaxHealth { get; private set; } = 100.00f;
        public int Level { get; private set; } = 1;
        public int Insanity { get; private set; } = 0;
        public int Defence { get; private set; } = 20;
        public int Attack { get; private set; } = 5;
        public int AttackSpeed { get; private set; } = 3;
        public int DefaultDice { get; private set; } = 7;
        public int Experience { get; private set; } = 0;
        public bool IsHerosTurn { get; set; } = false;
        public string Position = "";

        //Inventory
        public int MaxInventory { get; } = 10;
        public int HealPotion { get; set; } = 5;
        public int InventoryCount { get; set; } = 5;


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


        public float SetHeroHealth(float health)
        {
            return Health = health;
        }


        public async void ReduceInsanityAsync()
        {
            int number = RandomizeInsanityNumber();
            Insanity -= number;
            await FirebaseService.Instance.UpdateHeroInsanityAsync(Insanity, HeroId);
        }


        public async void IncreaseInsanityAsync()
        {
            int number = RandomizeInsanityNumber();
            Insanity += number;
            await FirebaseService.Instance.UpdateHeroInsanityAsync(Insanity, HeroId);
        }


        public int RandomizeInsanityNumber()
        {
            return UnityEngine.Random.Range(0, 20);
        }


        public void UseHealPotion()
        {
            float result = SetHeroHealth(Health + 30);
            if(result > MaxHealth)
            {
                Health = MaxHealth;
            }
            else
            {
                Health = result;
            }
            RemoveHealPotionFromInventory();
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
            MaxHealth += 50;
            await FirebaseService.Instance.UpdateHeroHealthAsync(Health, MaxHealth, HeroId);
        }


        public async void IncreaseHeroAttackOnLevelUpAsync()
        {
            Attack += 1;
            await FirebaseService.Instance.UpdateHeroAttackAsync(Attack, HeroId);
        }


        public async void IncreaseExperienceAsync()
        {
            Experience += 10;
            CheckExperiencePoints();
            await FirebaseService.Instance.UpdateHeroExperienceAsync(Experience, HeroId);
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
                    GetLevelUpAsync();
                    break;
                default:
                    break;
            }
        }


        public async void GetLevelUpAsync()
        {
            ++Level;
            await FirebaseService.Instance.UpdateHeroLevelAsync(Level, HeroId);
            IncreaseAttributesOnLevelUp();
        }


        public void IncreaseAttributesOnLevelUp()
        {
            IncreaseHeroHealthOnLevelUp();
            IncreaseDefenceOnLevelUpAsync();
            IncreaseHeroAttackOnLevelUpAsync();
            IncreaseAttackSpeedOnLevelUpAsync();
            IncreaseDefaultDiceOnLevelUpAsync();
        }

        public async void IncreaseAttackSpeedOnLevelUpAsync()
        {
            AttackSpeed += 1;
            await FirebaseService.Instance.UpdateHeroAttackSpeedAsync(AttackSpeed, HeroId);
        }


        public async void IncreaseDefaultDiceOnLevelUpAsync()
        {
            ++DefaultDice;
            await FirebaseService.Instance.UpdateHeroDefaultDiceAsync(DefaultDice, HeroId);
        }


        public async void IncreaseDefenceOnLevelUpAsync()
        {
            Defence += 2;
            await FirebaseService.Instance.UpdateHeroDefenceAsync(Defence, HeroId);
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


        //Inventory Methods
        public void InventoryPlusCounter()
        {
            ++InventoryCount;
        }


        public void InventoryMinusCounter()
        {
            --InventoryCount;
        }


        public void AddHealPotionToInventory()
        {
            ++HealPotion;
            InventoryPlusCounter();
        }


        public void RemoveHealPotionFromInventory()
        {
            --HealPotion;
            InventoryMinusCounter();
        }

        // TODO Methode um Health zu erhöhen zb durch Zauber


    }
}
