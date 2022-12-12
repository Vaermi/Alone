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
                {"Position", "0 0 0" }
            };
            await t;
            return (await db.Collection("Player").AddAsync(data)).Id;
        }


        public async void UpdateHeroAttackAsync(int attack, string heroId)
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


        public async void SetHeroAttackSpeedAsync(int attackSpeed, string heroId)
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


        public async void SetHeroDefaultDiceAsync(int defaultDice, string heroId)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updateName = new Dictionary<string, object>
        {
            {"DefaultDice", defaultDice},
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document($"{heroId}");
            await docRef.SetAsync(updateName, SetOptions.MergeAll);
        }


        public async void SetHeroDefenceAsync(int defence, string heroId)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updateName = new Dictionary<string, object>
        {
            {"Defence", defence},
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document($"{heroId}");
            await docRef.SetAsync(updateName, SetOptions.MergeAll);
        }


        public async void SetHeroExperienceAsync(int exp, string heroId)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updateName = new Dictionary<string, object>
        {
            {"Experience", exp},
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document($"{heroId}");
            await docRef.SetAsync(updateName, SetOptions.MergeAll);
        }


        public async void SetHeroInsanityAsync(int insanity, string heroId)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updateName = new Dictionary<string, object>
        {
            {"Insanity", insanity},
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document($"{heroId}");
            await docRef.SetAsync(updateName, SetOptions.MergeAll);
        }


        public async void SetHeroLevelAsync(int level, string heroId)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updateName = new Dictionary<string, object>
        {
            {"Level", level},
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document($"{heroId}");
            await docRef.SetAsync(updateName, SetOptions.MergeAll);
        }

        //TODO Spielstand muss Spielerposition, Queststand und Spielerattrubite enthalten
        public async void SetSaveGameAsync(string name, string heroId)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> savefile = new Dictionary<string, object>
        {
            {"name", name}
        };
            await t;
            DocumentReference docRef = db.Collection("SaveGame").Document($"{heroId}");
            await docRef.SetAsync(savefile);
        }


        public async Task<string> GetHeroNameAsync(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document($"{heroId}");
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<string>("HeroName");
        }


        //public async Task<string> GetHeroIDAsync(string id)
        //{
        //    await EstablishConnectionAsync();
        //    DocumentReference docRef = db.Collection("Player").Document(id);
        //    var snapshot = await docRef.GetSnapshotAsync();
        //    return snapshot.GetValue<string>("ID");
        //}

        //TODO Quest abrufen anhand des aktuellen Queststands
        string currentQuest = "Quest";
        public async Task<DocumentSnapshot> GetQuestWithIdAsync(string id)
        {
            await EstablishConnectionAsync();
            //id = "Quests/fgfjdlgsl
            //id = Quests/hfgsdgfss/Subquests/gfdjgsklfjdsalf
            //id = Quests/fkjdsfls/Subquests/gsdlngskdl/Subquests/
            DocumentReference docRef = db.Document($"{currentQuest}/{id}");
            currentQuest = $"{currentQuest}/{id}/SubQuest";
            //var snapshot = await docRef.GetSnapshotAsync();
            return await docRef.GetSnapshotAsync();
        }

        //TODO Spielerposition abrufen
        public string? GetPlayerPosition(string heroId)
        {
            return null;
        }

        //TODO Spielerwerte abrufen
        public async void GetPlayerAttributes(string heroId)
        {
            await GetPlayerAttackAsync(heroId);
            await GetPlayerAttackSpeedAsync(heroId);
            await GetPlayerDefaultDiceAsync(heroId);
            await GetPlayerDefence(heroId);
            await GetPlayerExperience(heroId);
            await GetHeroHealthAsync(heroId);
            await GetPlayerInsanity(heroId);
            await GetPlayerLevel(heroId);
        }

        //TODO Spielstand laden
        public async Task<DocumentSnapshot> GetSaveGame()
        {
            await EstablishConnectionAsync();
            QuerySnapshot query = await db.Collection("Player").Limit(1).GetSnapshotAsync();
            IEnumerator<DocumentSnapshot> enumerator = query.Documents.GetEnumerator();
            enumerator.MoveNext();
            DocumentSnapshot snapshot = enumerator.Current;
            return snapshot;
        }


        public async Task<string> GetPlayerAttackAsync(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document(heroId);
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<string>("Attack");
        }


        public async Task<string> GetPlayerAttackSpeedAsync(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document(heroId);
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<string>("AttackSpeed");
        }


        public async Task<string> GetPlayerDefaultDiceAsync(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document(heroId);
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<string>("DefaultDice");
        }


        public async Task<string> GetPlayerDefence(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document(heroId);
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<string>("Defence");
        }


        public async Task<string> GetPlayerExperience(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document(heroId);
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<string>("Experience");
        }

        public async Task<float> GetHeroHealthAsync(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document($"{heroId}");
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<float>("Health");
        }


        public async Task<string> GetPlayerInsanity(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document(heroId);
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<string>("Insanity");
        }


        public async Task<string> GetPlayerLevel(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document(heroId);
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<string>("Level");
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

        //TODO Questfortschritt speichern
        public void UpdateQuestProgress()
        {

        }

        //TODO Spielerposition speichern

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

        //TODO Spielerwerte speichern 
        public void UpdatePlayerAttributes()
        {

        }


        public async Task UpdateSaveGame(Hero hero, string heroId)
        {
            UpdateQuestProgress();
            await UpdatePlayerPosition(hero, heroId);
            UpdatePlayerAttributes();
        }

        //DELETE

        //TODO Spielstand löschen
        public void DeleteSaveGame()
        {

        }


        
    }
}
