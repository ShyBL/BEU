using System;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private PickupType type;
    
    public void OnPickUp()
    {
        switch (type)
        {
            case PickupType.Health:
                ParticlesManager.PlayFXByType(FXType.HealthPickup);
                // Player.AddHealth()
                
                break;
            case PickupType.Points:
                ParticlesManager.PlayFXByType(FXType.PointsPickup);
                // Player.AddPoints()
                
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        Destroy(this);
    }
}