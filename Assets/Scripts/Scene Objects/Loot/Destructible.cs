using System;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void OnDestroyThis()
    {
        animator.Play(1);
        
        Invoke(nameof(DestroyThis),animator.GetCurrentAnimatorClipInfo(1).Length);
    }

    void DestroyThis()
    {
        Destroy(this);
    }
}