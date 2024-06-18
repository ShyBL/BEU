using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private static ScenesManager instance;
    private Scene mainScene;
    private SceneType selectedScene;
    

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

    public static void LoadLevelCoroutine(SceneType sceneType)
    {
        SceneManager.UnloadSceneAsync(1);
        
        SceneManager.LoadSceneAsync("Level", LoadSceneMode.Additive);
        instance.selectedScene = sceneType;
        
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