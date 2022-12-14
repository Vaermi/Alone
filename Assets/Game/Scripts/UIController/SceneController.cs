using Assets.Game.Scripts.Db;
using Assets.Game.Scripts.GameObjects;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public float Counter = 0;
    private void Update()
    {
        float result = CounterToSwitchScene();
        if (result >= 5)
        {
            StartScreen();
        }
    }
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


    public static void ContinueGame()
    {
        SceneManager.UnloadSceneAsync("PauseScreen");
    }
    

    public static void EnterFightScreenBoss()
    {
        SceneManager.LoadScene("FightScreenBoss", LoadSceneMode.Additive);
    }


    public static void EnterFightScreenEnemy()
    {
        SceneManager.LoadScene("FightScreenEnemy", LoadSceneMode.Additive);
    }


    public static void ExitFightScreen()
    {
        SceneManager.UnloadSceneAsync("FightScreen");
    }


    public float CounterToSwitchScene()
    {
        Counter += Time.deltaTime;
        return Counter;
    }
}
