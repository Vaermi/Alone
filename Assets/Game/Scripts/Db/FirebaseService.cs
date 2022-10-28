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
        public async void SaveHeroNameInDbAsync(string name)
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

        //READ

        //TODO Spielername lesen
        //TODO Quest abrufen
        //TODO Spielerposition abrufen
        //TODO Spielerwerte abrufen
        //TODO Spielstand laden

        //UPDATE

        //TODO Questfortschritt speichern
        //TODO Spielerposition speichern
        //TODO Spielerwerte speichern
        //TODO Spielstand speichern

        //DELETE

        //TODO Spielstand löschen

    }
}
