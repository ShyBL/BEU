using System;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private PickupType type;
    [SerializeField] private GameObject[] pickups;
    [SerializeField] private GameObject pickupHealth;
    [SerializeField] private GameObject pickupPoints;
    [SerializeField] private GameObject pickupEnergy;

    private void Awake()
    {
        foreach (var obj in pickups)
        {
            obj.SetActive(false);
        }
        
        switch (type)
        {
            case PickupType.Health:
                pickupHealth.SetActive(true);
                break;
            case PickupType.Points:
                pickupPoints.SetActive(true);
                break;
            case PickupType.Energy:
                pickupEnergy.SetActive(true);
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    

    public void OnPickUp()
    {
        switch (type)
        {
            case PickupType.Health:
                ParticlesManager.PlayFXByType(FXType.HealthPickup);
                gameObject.SetActive(false);
                // Player.AddHealth()
                
                break;
            case PickupType.Points:
                ParticlesManager.PlayFXByType(FXType.PointsPickup);
                gameObject.SetActive(false);
                // Player.AddPoints()
                
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        Destroy(this);
    }
}