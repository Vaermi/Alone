using Assets.Game.Scripts.Db;
using Assets.Game.Scripts.GameObjects;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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


    public static void PauseGame()
    {
        SceneManager.LoadScene("PauseScreen", LoadSceneMode.Additive);

    }


    public void ContinueGame()
    {
        SceneManager.UnloadSceneAsync("PauseScreen");
    }
    

    public void EnterFightScreen()
    {
        SceneManager.LoadScene("FightScreen", LoadSceneMode.Additive);
    }


    public void ExitFightScreen()
    {
        SceneManager.UnloadSceneAsync("FightScreen");
    }
}
