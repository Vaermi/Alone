using Assets.Game.Scripts.Db;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public static void StartScreen()
    {
        SceneManager.LoadScene("StartScreen");
    }


    public static void NameCreationScreen()
    {
        FirebaseService.Instance.SetInitialSaveGameAsync();
        SceneManager.LoadScene("NameCreationScreen");
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
