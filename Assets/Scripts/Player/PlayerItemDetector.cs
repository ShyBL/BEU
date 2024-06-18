using UnityEngine;

public class PlayerItemDetector : MonoBehaviour
{
    public GameObject detectedItem;
    public bool itemDetected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Pickup pickup)) 
        {
            detectedItem = other.gameObject;
            itemDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Pickup pickup)) 
        {
            detectedItem = null;
            itemDetected = false;
        }
    }
}