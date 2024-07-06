using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;
    private Scene mainScene;
    public static SceneType selectedScene;

    public bool isEgyptLevelDone;
    public bool isItalyLevelDone = true;
    public bool isFranceLevelDone = true;
    public bool isNewYorkLevelDone = true;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
        mainScene = SceneManager.GetActiveScene();
    }
    

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Additive);

        foreach (var obj in mainScene.GetRootGameObjects())
        {
            if (obj.name == "SoundManager" || obj.name == "Volume")
            {
               continue;
            }

            obj.SetActive(false);
        }
    }

    public static void LoadLevel(SceneType sceneType)
    {
        SceneManager.LoadSceneAsync("Level", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("LevelSelect");
        selectedScene = sceneType;
        
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level")
        {
            foreach (var obj in scene.GetRootGameObjects())
            {
                if (obj.name == selectedScene.ToString())
                {
                    obj.SetActive(true);
                    break;
                }
            }
        }

    }
}