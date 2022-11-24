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
        public async void SetHeroNameAsync(string name)
        {
            Task t = EstablishConnectionAsync();
            Dictionary<string, object> heroname = new Dictionary<string, object>
        {
            {"name", name}
        };
            await t;
            DocumentReference docRef = db.Collection("Player").Document("HeroName");
            await docRef.SetAsync(heroname);
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
