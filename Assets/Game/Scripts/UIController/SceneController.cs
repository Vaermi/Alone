using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

    // Start is called before the first frame update
    void Awake()
    {
        /*Debug.Log("Awake");
        myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/Game/Levels");
        Debug.Log(myLoadedAssetBundle);
        scenePaths = myLoadedAssetBundle.GetAllScenePaths();
        //LoadScene();
    }

    private void Start()
    {
        Debug.Log("Start");
        Debug.Log(scenePaths.Length);
        
    }

    /*public void LoadScene()
    {
        Debug.Log("Loading Scene");
        SceneManager.LoadScene(scenePaths[1], LoadSceneMode.Single);*/
    }
}
