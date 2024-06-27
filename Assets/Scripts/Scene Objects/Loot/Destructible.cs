using System;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject pickup;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        pickup.SetActive(false);
    }

    public void OnDestroyThis()
    {
        animator.Play("Barrel_Boom");
        
        Invoke(nameof(DestroyThis),animator.GetCurrentAnimatorClipInfo(1).Length);
    }

    void DestroyThis()
    {
        pickup.SetActive(true);
        //Destroy(this);
    }
}