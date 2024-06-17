using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public enum SceneType
{
    Default,
    Main,
    LevelSelect,
    Egypt,
    Italy,
    France,
    NewYork
}

public class ScenesManager : MonoBehaviour
{
    private static ScenesManager instance;
    private Scene selectedScene;

    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject menuEnvironment;

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
    
    public void LoadNewYorkLevelButton()
    {
        StartCoroutine(LoadLevelCoroutine(SceneType.NewYork));
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Additive);
    }
    
    private IEnumerator LoadLevelCoroutine(SceneType sceneType)
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Additive);
        
        menuCanvas.SetActive(false);
        menuEnvironment.SetActive(false);
        
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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    { 
        selectedScene = scene;
    }
}