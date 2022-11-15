using Firebase;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assets.Game.Scripts.Db
{
    public class FirebaseService
    {
        private Hero hero;

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


        public async Task<string> SetInitialSaveGameAsync()
        {
            Dictionary<string, object> value;
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> data = new Dictionary<string, object>
            {
                {"HeroName", ""},
                {"Health", 100.00},
                {"Insanity", 0},
                {"Defence", 20},
                {"Attack", 5},
                {"AttackSpeed", 3},
                {"DefaultDice", 10},
                {"Experience", 0},
                {"Level", 1},
                {"ID", "" }
            };
            await t;
            String result = "";
            await db.Collection("Player").AddAsync(data).ContinueWith(task => result = task.Result.Id);
            SetHeroIDAsync(result);
            return result;
        }


        public async void SetHeroIDAsync(string id)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updateName = new Dictionary<string, object>
        {
            {"ID", id},
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document(id);
            await docRef.SetAsync(updateName, SetOptions.MergeAll);
        }


        public async void SetHeroNameAsync(string name, string heroId)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updateName = new Dictionary<string, object>
        {
            {"HeroName", name},
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document(heroId);
            await docRef.SetAsync(updateName, SetOptions.MergeAll);
        }


        public async void SetHeroAttackAsync(int attack, string heroId)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updateName = new Dictionary<string, object>
        {
            {"Attack", attack},
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document(heroId);
            await docRef.SetAsync(updateName, SetOptions.MergeAll);
        }


        public async void SetHeroAttackSpeedAsync(int attackSpeed, string heroId)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updateName = new Dictionary<string, object>
        {
            {"AttackSpeed", attackSpeed},
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document(heroId);
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
            DocumentReference docRef = db.Collection("Player").Document(heroId);
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
            DocumentReference docRef = db.Collection("Player").Document(heroId);
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
            DocumentReference docRef = db.Collection("Player").Document(heroId);
            await docRef.SetAsync(updateName, SetOptions.MergeAll);
        }


        public async void SetHeroHealthAsync(float health, string heroId)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updateName = new Dictionary<string, object>
        {
            {"Health", health},
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document(heroId);
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
            DocumentReference docRef = db.Collection("Player").Document(heroId);
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
            DocumentReference docRef = db.Collection("Player").Document(heroId);
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
            DocumentReference docRef = db.Collection("SaveGame").Document(heroId);
            await docRef.SetAsync(savefile);
        }


        public async Task<string> GetHeroNameAsync(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document(heroId);
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<string>("HeroName");
        }


        public async Task<string> GetHeroIDAsync(string id)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document(id);
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<string>("ID");
        }

        //TODO Quest abrufen anhand des aktuellen Queststands
        public async Task<string> GetQuestWithIdAsync(string id)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Quest").Document(id);
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<string>("text");
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
            await GetPlayerHealth(heroId);
            await GetPlayerInsanity(heroId);
            await GetPlayerLevel(heroId);
        }

        //TODO Spielstand laden
        public void GetSaveGame(string heroId)
        {
            GetPlayerAttributes(heroId);
            GetPlayerPosition(heroId);
        }

        //UPDATE

        //TODO Questfortschritt speichern
        public void UpdateQuestProgress()
        {

        }

        //TODO Spielerposition speichern

        public string UpdatePlayerPosition()
        {
            string pos = hero.CurrentPlayerPosition();
            return pos;
        }

        //TODO Spielerwerte speichern 
        public void UpdatePlayerAttributes()
        {

        }


        public void UpdateSaveGame()
        {
            UpdateQuestProgress();
            UpdatePlayerPosition();
            UpdatePlayerAttributes();
        }

        //DELETE

        //TODO Spielstand löschen
        public void DeleteSaveGame()
        {

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

        public async Task<string> GetPlayerHealth(string heroId)
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document(heroId);
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<string>("Health");
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
    }
}
