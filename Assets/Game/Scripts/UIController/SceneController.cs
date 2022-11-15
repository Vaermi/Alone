using Assets.Game.Scripts.Db;
using Assets.Game.Scripts.GameObjects;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private HeroService heroService = HeroService.Instance;

    public static void StartScreen()
    {
        SceneManager.LoadScene("StartScreen");
    }


    public async void NameCreationScreen()
    {
        SceneManager.LoadScene("NameCreationScreen");
        string id = await FirebaseService.Instance.SetInitialSaveGameAsync();
        heroService.SetHeroID(id);
    }


    public static void MainGameScreen()
    {
        SceneManager.LoadScene("Main");
    }


    public static void GameOverScreen()
    {
        SceneManager.LoadScene("GameOverScreen");
    }

}
