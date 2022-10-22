using Firebase.Firestore;
using Firebase.Extensions;
using UnityEngine;
using System.Collections.Generic;
using System;

public class FirebaseDb : MonoBehaviour
{
    static FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

    //CREATE

    //TODO Spielername hinzufügen
    
    public static void SaveHeroNameInDb(string heroName)
    {
        DocumentReference docRef = db.Collection("Player").Document("HeroName");
        Dictionary<string, object> heroname = new Dictionary<string, object>
        {
            {"name", heroName}
        };
        docRef.SetAsync(heroname).ContinueWithOnMainThread(task =>
        {
            Debug.Log("Added data to the HeroName document in the Player collection.");
        });
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

