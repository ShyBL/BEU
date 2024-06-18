using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FXType
{
    Footsteps
}

public class ParticlesManager : MonoBehaviour
{
    private static ParticlesManager instance;
    [SerializeField] public ParticleSystem Footsteps;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static void PlayFXByType(FXType type)
    {
        switch (type)
        {
            case FXType.Footsteps:
                instance.Footsteps.Play();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        
    }
    public static void StopFXByType(FXType type)
    {
        switch (type)
        {
            case FXType.Footsteps:
                instance.Footsteps.Stop();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        
    }
}
