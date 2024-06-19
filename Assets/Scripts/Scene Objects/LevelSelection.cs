using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private GameObject selection;
    [SerializeField] private GameObject camFollow;
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
            case SceneType.Default:
                break;
            case SceneType.Main:
                break;
            case SceneType.LevelSelect:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        // rectTransform.position = RectTransformUtility.WorldToScreenPoint
        //     (mainCam, selection.transform.position);
    }

    public void CameraToSelection()
    {
        camFollow.transform.DOMove(selection.transform.position, 1).OnComplete(() =>
        {
            ScenesManager.LoadLevel(_sceneType);
        });
    }
}
