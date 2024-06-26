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
        animator.Play("Barrel_Boom");
        
        Invoke(nameof(DestroyThis),animator.GetCurrentAnimatorClipInfo(1).Length);
    }

    void DestroyThis()
    {
        Destroy(this);
    }
}