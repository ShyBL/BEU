using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
    Default,
    Main,
    Egypt,
    Italy,
    France,
    NewYork
}

public class MyGameManager : MonoBehaviour
{
    private static MyGameManager instance;
    private Scene selectedScene;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadEgyptLevelButton()
    {
        StartCoroutine(LoadLevelCoroutine(SceneType.Egypt));
    }
    
    public void LoadItalyLevelButton()
    {
        StartCoroutine(LoadLevelCoroutine(SceneType.Italy));
    }
    
    public void LoadFranceLevelButton()
    {
        StartCoroutine(LoadLevelCoroutine(SceneType.France));
    }
    
    public void LoadNewYorktLevelButton()
    {
        StartCoroutine(LoadLevelCoroutine(SceneType.NewYork));
    }
    
    private IEnumerator LoadLevelCoroutine(SceneType sceneType)
    {
        LoadSceneAdditive(sceneType);

        while (!selectedScene.isLoaded)
        {
            yield return null;
        }

        foreach (var obj in selectedScene.GetRootGameObjects())
        {
            if (obj.name == sceneType.ToString())
            {
                obj.SetActive(true);
                    break;
            }
        }
    }

    public void LoadSceneAdditive(SceneType sceneType)
    {
        SceneManager.LoadScene((int)sceneType, LoadSceneMode.Additive);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    { 
        selectedScene = scene;
    }
}