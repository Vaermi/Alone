using Firebase;
using Firebase.Firestore;
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


        public async void SetInitialSaveGameAsync()
        {
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
                {"Expirience", 0},
                {"Level", 1}
            };
            await t;
            DocumentReference docRef = db.Collection("Player").Document("NewPlayer");
            await docRef.SetAsync(data);
        }
        public async void SetHeroNameAsync(string name)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> updateName = new Dictionary<string, object>
        {
            {"HeroName", name}
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document("NewPlayer");
            await docRef.SetAsync(updateName, SetOptions.MergeAll);
        }

        //TODO Spielstand muss Spielerposition, Queststand und Spielerattrubite enthalten
        public async void SetSaveGameAsync(string name)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> savefile = new Dictionary<string, object>
        {
            {"name", name}
        };
            await t;
            DocumentReference docRef = db.Collection("SaveGame").Document("SaveFile");
            await docRef.SetAsync(savefile);
        }


        public async Task<string> GetHeroNameAsync()
        {
            await EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document("HeroName");
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<string>("name");
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
        /*public string? GetPlayerPosition()
        {
            return null;
        }*/

        //TODO Spielerwerte abrufen
        public void GetPlayerAttributes()
        {

        }

        //TODO Spielstand laden
        public void GetSaveGame()
        {

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
    }
}
