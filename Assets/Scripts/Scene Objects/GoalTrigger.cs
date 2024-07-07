using System;
using UnityEngine;
using Cinemachine;

public class GoalTrigger : MonoBehaviour
{
    public SceneType selectedScene;
    [SerializeField] private CinemachineVirtualCamera TriggeredObject;
    [SerializeField] private CinemachineVirtualCamera PlayerCamera;
    private float _focusDistance;
    
    private void Start()
    {
        selectedScene = ScenesManager.selectedScene;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        MarkSceneAsDone(true);
        TriggeredObject.enabled = true;
        // PlayerCamera.m_Priority = 0;
        // TriggeredObject.m_Priority = 1;
    }

    private void OnTriggerExit(Collider other)
    {
        MarkSceneAsDone(false);
        TriggeredObject.enabled = false;
        // PlayerCamera.m_Priority = 1;
        // TriggeredObject.m_Priority = 0;
    }

    private void MarkSceneAsDone(bool isDone)
    {
        switch (selectedScene)
        {
            case SceneType.Egypt:
                ScenesManager.instance.isEgyptLevelDone = isDone;
                break;
            case SceneType.Italy:
                ScenesManager.instance.isItalyLevelDone = isDone;
                break;
            case SceneType.France:
                ScenesManager.instance.isFranceLevelDone = isDone;
                break;
            case SceneType.NewYork:
                ScenesManager.instance.isNewYorkLevelDone = isDone;
                break;
            case SceneType.Default:
                break;
            case SceneType.Main:
                break;
            case SceneType.LevelSelect:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}