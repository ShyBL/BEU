using System;
using UnityEngine;


public class GoalTrigger : MonoBehaviour
{
    public SceneType selectedScene;
    [SerializeField] public Transform targetObject;
    [SerializeField] Camera cam;
    public float focusDistance = 10f; // Adjust as necessary
    
    private void Start()
    {
        selectedScene = ScenesManager.selectedScene;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (selectedScene)
        {
            case SceneType.Egypt:
                ScenesManager.instance.isEgyptLevelDone = true;
                SwitchToPerspective();
                FocusOnTarget();
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
    
    private void SwitchToPerspective()
    {
        if(cam != null && targetObject != null)
        {
            if (cam.orthographic)
            {
                cam.orthographic = false;
            }
        }
    }
    private void FocusOnTarget()
    {
        // Set the camera's position and rotation to focus on the target object
        Vector3 direction = targetObject.position - cam.transform.position;
        cam.transform.position = targetObject.position - direction.normalized * focusDistance;
        cam.transform.LookAt(targetObject);
    }
}
