using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string NextSceneToLoad;
    public float Counter = 0;

    private void Start()
    {
        if (NextSceneToLoad != String.Empty) 
        { 
            StartCoroutine(LoadNextScene());
        }
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(NextSceneToLoad);
    }

    public static IEnumerator StartScreen()
    {
        yield return new WaitForSeconds(3);
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


    public static void ExitFightScreenBoss()
    {
        SceneManager.UnloadSceneAsync("FightScreenBoss");
    }


    public static void ExitFightScreenEnemy()
    {
        SceneManager.UnloadSceneAsync("FightScreenEnemy");
    }

}
