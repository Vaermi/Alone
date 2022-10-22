using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program : MonoBehaviour
{
    private Hero hero;

    private void Awake()
    {
        hero = GetComponent<Hero>();
        if(hero.HeroName == "")
        {
            hero.CreateHeroName();
        }
        FirebaseDb.CreateHeroNameInDb(hero.HeroName);
    }

}
