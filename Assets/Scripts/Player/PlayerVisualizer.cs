using System;
using UnityEngine;

public class PlayerVisualizer : MonoBehaviour
{
    [SerializeField] public Animator _animator;
    private static string Y_BLEND_ANIMATION = "yVelocity";
    public void PlayAnimation(string animName)
    {
        _animator.Play(animName);
    }

    public void SetYBlend(float value)
    {
        _animator.SetFloat(Y_BLEND_ANIMATION, value);
    }

    public float GetAnimationLength(string animName)
    {
        
        return 0;
    }
}
