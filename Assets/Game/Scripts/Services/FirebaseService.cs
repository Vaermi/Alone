using Assets.Game.Scripts.GameObjects;
using Firebase;
using Firebase.Firestore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assets.Game.Scripts.Db
{
    public class FirebaseService
    {
        FirebaseFirestore db;
        private FirebaseService() { }
        private static FirebaseService instance;
        public static FirebaseService Instance
        {
            get
            {
                if (instance is null) instance = new FirebaseService();
                return instance;
            }
        }


        private async Task EstablishConnectionAsync()
        {
            if (db is null)
            {
                await FirebaseApp.CheckAndFixDependenciesAsync();
                db = FirebaseFirestore.DefaultInstance;
            }
        }

        //CREATE
        public async Task<string> SetInitialSaveGameAsync(string name)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> data = new Dictionary<string, object>
            {
                {"HeroName", name},
                {"Health", 100.00},
                {"Insanity", 0},
                {"Defence", 20},
                {"Attack", 5},
                {"AttackSpeed", 3},
                {"DefaultDice", 10},
                {"Experience", 0},
                {"Level", 1},
                {"CurrentQuest", "Quest"},
                {"Position", "0 0 0" },
                {"HealPotion", 5 },
                {"InventoryCount", 5 }
            };
            await t;
            return (await db.Collection("Player").AddAsync(data)).Id;
        }

        //READ
        public async Task<string> GetHeroNameAsync(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document($"{heroId}");
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<string>("HeroName");
        }


        string currentQuest = "Quest";
        public async Task<DocumentSnapshot> GetQuestWithIdAsync(string id)
        {
            await EstablishConnectionAsync();
            //id = "Quests/fgfjdlgsl
            //id = Quests/hfgsdgfss/Subquests/gfdjgsklfjdsalf
            //id = Quests/fkjdsfls/Subquests/gsdlngskdl/Subquests/
            DocumentReference docRef = db.Document($"{currentQuest}/{id}");
            currentQuest = $"{currentQuest}/{id}/SubQuest";
            return await docRef.GetSnapshotAsync();
        }


        public async Task<string> GetHeroPositionAsync(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document($"{heroId}");
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<string>("Position");
        }


        public async Task GetHeroAttributesAsync(string heroId)
        {
            await GetHeroAttackAsync(heroId);
            await GetHeroAttackSpeedAsync(heroId);
            await GetHeroDefaultDiceAsync(heroId);
            await GetHeroDefenceAsync(heroId);
            await GetHeroExperienceAsync(heroId);
            await GetHeroHealthAsync(heroId);
            await GetHeroInsanityAsync(heroId);
            await GetHeroLevelAsync(heroId);
        }


        public async Task<DocumentSnapshot> GetSaveGameAsync()
        {
            await EstablishConnectionAsync();
            QuerySnapshot query = await db.Collection("Player").Limit(1).GetSnapshotAsync();
            IEnumerator<DocumentSnapshot> enumerator = query.Documents.GetEnumerator();
            enumerator.MoveNext();
            DocumentSnapshot snapshot = enumerator.Current;
            return snapshot;
        }


        public async Task<int> GetHeroAttackAsync(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document(heroId);
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<int>("Attack");
        }


        public async Task<int> GetHeroAttackSpeedAsync(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document(heroId);
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<int>("AttackSpeed");
        }


        public async Task<int> GetHeroDefaultDiceAsync(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document(heroId);
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<int>("DefaultDice");
        }


        public async Task<int> GetHeroDefenceAsync(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document(heroId);
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<int>("Defence");
        }


        public async Task<int> GetHeroExperienceAsync(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document(heroId);
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<int>("Experience");
        }


        public async Task<float> GetHeroHealthAsync(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document($"{heroId}");
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<float>("Health");
        }


        public async Task<int> GetHeroInsanityAsync(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document(heroId);
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<int>("Insanity");
        }


        public async Task<int> GetHeroLevelAsync(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document(heroId);
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<int>("Level");
        }

        //UPDATE
        public async Task UpdateHeroHealthAsync(float health, string heroId)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updateHealth = new Dictionary<string, object>
        {
            {"Health", health},
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document(heroId);
            await docRef.SetAsync(updateHealth, SetOptions.MergeAll);
        }


        public async Task UpdateHeroInsanityAsync(int insanity, string heroId)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updateInsanity = new Dictionary<string, object>
        {
            {"Insanity", insanity},
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document($"{heroId}");
            await docRef.SetAsync(updateInsanity, SetOptions.MergeAll);
        }


        public async Task UpdateHeroDefenceAsync(int defence, string heroId)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updateDefence = new Dictionary<string, object>
        {
            {"Defence", defence},
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document($"{heroId}");
            await docRef.SetAsync(updateDefence, SetOptions.MergeAll);
        }


        public async Task UpdateHeroAttackAsync(int attack, string heroId)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updateAttack = new Dictionary<string, object>
        {
            {"Attack", attack},
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document($"{heroId}");
            await docRef.SetAsync(updateAttack, SetOptions.MergeAll);
        }


        public async Task UpdateHeroAttackSpeedAsync(int attackSpeed, string heroId)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updateName = new Dictionary<string, object>
        {
            {"AttackSpeed", attackSpeed},
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document($"{heroId}");
            await docRef.SetAsync(updateName, SetOptions.MergeAll);
        }


        public async Task UpdateHeroDefaultDiceAsync(int defaultDice, string heroId)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updateDice = new Dictionary<string, object>
        {
            {"DefaultDice", defaultDice},
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document($"{heroId}");
            await docRef.SetAsync(updateDice, SetOptions.MergeAll);
        }


        public async Task UpdateHeroExperienceAsync(int exp, string heroId)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updateExp = new Dictionary<string, object>
        {
            {"Experience", exp},
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document($"{heroId}");
            await docRef.SetAsync(updateExp, SetOptions.MergeAll);
        }


        public async Task UpdateHeroLevelAsync(int level, string heroId)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updateLevel = new Dictionary<string, object>
        {
            {"Level", level},
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document($"{heroId}");
            await docRef.SetAsync(updateLevel, SetOptions.MergeAll);
        }


        public async Task UpdateQuestProgressAsync(Hero hero, string heroId)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updateQuest = new Dictionary<string, object>
        {
            {"CurrentQuest", HeroService.Instance.CurrentQuest},
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document($"{heroId}");
            await docRef.SetAsync(updateQuest, SetOptions.MergeAll);
        }


        public async Task UpdatePlayerPosition(Hero hero, string heroId)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updatePosition = new Dictionary<string, object>
        {
            {"Position", hero.CurrentPlayerPosition()},
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document($"{heroId}");
            await docRef.SetAsync(updatePosition, SetOptions.MergeAll);
        }


        public async Task UpdateSaveGame(Hero hero, string heroId)
        {
            await UpdateQuestProgressAsync(hero, heroId);
            await UpdatePlayerPosition(hero, heroId);
            await UpdateHeroExperienceAsync(HeroService.Instance.Experience, heroId);
        }

        //DELETE

        //TODO Spielstand löschen
        public void DeleteSaveGame()
        {

        }


        
    }
}
