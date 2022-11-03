using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Scripts.Db
{
    public class FirebaseService
    {
        FirebaseFirestore db;
        private FirebaseService()
        {
            
        }

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
            if(db is null)
            {
                await FirebaseApp.CheckAndFixDependenciesAsync();
                db = FirebaseFirestore.DefaultInstance;

            }
        }

        //CREATE

        //TODO Spielername hinzufügen
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




        //TODO Neuen Spielstand erstellen
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

        //READ

        // Methode um den Spielernamen aus der Datenbank abzufragen
        public async Task<string> GetHeroNameAsync()
        {
            Task t = EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Player").Document("HeroName");
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<string>("name");
        }
        //TODO Quest abrufen anhand der QuestNr
        public async Task<string> GetQuestWithIdAsync(string id)
        {
            Task t = EstablishConnectionAsync();
            DocumentReference docRef = db.Collection("Quest").Document(id);
            var snapshot = await docRef.GetSnapshotAsync();
            return snapshot.GetValue<string>("text");
        }

        //TODO Spielerposition abrufen
        public string? GetPlayerPosition()
        {
            return null;
        }

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

        public void UpdatePlayerPosition()
        {

        }

        //TODO Spielerwerte speichern 
        public void UpdatePlayerAttributes()
        {

        }

        //TODO Spielstand speichern
        public void UpdateSaveGame()
        {

        }

        //DELETE

        //TODO Spielstand löschen
        public void DeleteSaveGame()
        {

        }
    }
}
