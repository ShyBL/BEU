using UnityEngine;

public class PlayerItemDestroyer : MonoBehaviour
{
    public GameObject destroyedItem;
    public bool itemDetected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Destructible destroyable)) 
        {
            destroyedItem = other.gameObject;
            itemDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup")) 
        {
            destroyedItem = null;
            itemDetected = false;
        }
    }
}