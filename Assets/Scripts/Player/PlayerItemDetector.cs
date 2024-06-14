using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemDetector : MonoBehaviour
{
    public GameObject detectedItem;
    public bool itemDetected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup")) 
        {
            detectedItem = other.gameObject;
            itemDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup")) 
        {
            detectedItem = null;
            itemDetected = false;
        }
    }
}
