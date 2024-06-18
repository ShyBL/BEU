using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FXType
{
    Footsteps,
    Pickup,
    HealthPickup,
    PointsPickup
}

public class ParticlesManager : MonoBehaviour
{
    private static ParticlesManager instance;
    [SerializeField] public ParticleSystem Footsteps;
    [SerializeField] public ParticleSystem Scanner;
    [SerializeField] public GameObject ScannerCone;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        instance.ScannerCone.SetActive(false);
    }

    public static void PlayFXByType(FXType type)
    {
        switch (type)
        {
            case FXType.Footsteps:
                instance.Footsteps.Play();
                break;
            case FXType.Pickup:
                instance.ScannerCone.SetActive(true);
                instance.Scanner.Play();
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
            case FXType.Pickup:
                instance.ScannerCone.SetActive(false);
                instance.Scanner.Stop();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        
    }
}
