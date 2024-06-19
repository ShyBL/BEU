
using System;
using DG.Tweening;
using UnityEngine;

public class DoFade : MonoBehaviour
{
    private CanvasGroup cg;
    private int timer;
    private bool time;
    private void Awake()
    {
        cg = GetComponent<CanvasGroup>();
        cg.alpha = 0;
    }

    void Start()
    {
        DoFadeTween(1);
    }

    private void Update()
    {
        if (time) return;
        if (timer >= 1000)
        {
            time = true;
            DoFadeTween(0);
        }
        else
        {
            timer++;
        }
    }

    private void DoFadeTween(float endValue)
    {
        DOTween.To(() => cg.alpha, x => cg.alpha = x, endValue, 2f).SetEase(Ease.OutQuad);
    }
}
