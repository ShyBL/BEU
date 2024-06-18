using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private GameObject selection;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    private Camera mainCam => Camera.main;

    [SerializeField] private Button button;
    [SerializeField] private SceneType _sceneType;
    
    void Start()
    {
        button = GetComponent<Button>();
        switch (_sceneType)
        {
            case SceneType.Egypt:
                if (ScenesManager.instance.isEgyptLevelDone)
                {
                    button.interactable = false;
                }
                break;
            case SceneType.Italy:
                if (ScenesManager.instance.isItalyLevelDone)
                {
                    button.interactable = false;
                }
                break;
            case SceneType.France:
                if (ScenesManager.instance.isFranceLevelDone)
                {
                    button.interactable = false;
                }
                break;
            case SceneType.NewYork:
                if (ScenesManager.instance.isNewYorkLevelDone)
                {
                    button.interactable = false;
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        rectTransform.position = RectTransformUtility.WorldToScreenPoint
            (mainCam, selection.transform.position);
    }
    
    void FixedUpdate()
    {

        rectTransform.position = RectTransformUtility.WorldToScreenPoint
            (mainCam, selection.transform.position);
    }
    
    
    
    public void LoadEgyptLevelButton()
    {
        ScenesManager.LoadLevelCoroutine(SceneType.Egypt);
    }
    
    public void LoadItalyLevelButton()
    {
        ScenesManager.LoadLevelCoroutine(SceneType.Italy);
    }
    
    public void LoadFranceLevelButton()
    {
        ScenesManager.LoadLevelCoroutine(SceneType.France);
    }
    
    public void LoadNewYorkLevelButton()
    {
        ScenesManager.LoadLevelCoroutine(SceneType.NewYork);
    }
}
