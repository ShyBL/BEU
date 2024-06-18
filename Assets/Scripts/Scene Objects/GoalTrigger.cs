using System;
using UnityEngine;


public class GoalTrigger : MonoBehaviour
{
    public SceneType selectedScene;

    private void Start()
    {
        selectedScene = ScenesManager.instance.selectedScene;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (selectedScene)
        {

            case SceneType.Egypt:
                ScenesManager.instance.isEgyptLevelDone = true;
                break;
            case SceneType.Italy:
                ScenesManager.instance.isItalyLevelDone = true;
                break;
            case SceneType.France:
                ScenesManager.instance.isFranceLevelDone = true;
                break;
            case SceneType.NewYork:
                ScenesManager.instance.isNewYorkLevelDone = true;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
