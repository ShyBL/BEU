using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private GameObject selection;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    private Camera mainCam => Camera.main;

    void Start()
    {
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
