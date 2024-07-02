using System;
using UnityEngine;

public class GameTrigger : MonoBehaviour
{
    public GameObject detectedObject;
    public bool objectDetected;
    public Action<GameObject> action;
    
    private void OnTriggerEnter(Collider other)
    {
        detectedObject = other.gameObject;
        objectDetected = true;
        action.Invoke(detectedObject);
    }

    private void OnTriggerExit(Collider other)
    {
        detectedObject = null;
        objectDetected = false;
    }
}

public class MyTrigger : GameTrigger
{
    private void Awake()
    {
        action += DoTriggeredAction;
    }

    private void OnDestroy()
    {
        action -= DoTriggeredAction;
        
    }

    private void DoTriggeredAction(GameObject obj)
    {
        var body = obj.GetComponent<Rigidbody>();
        body.AddExplosionForce(0.5f,obj.transform.position,0.5f);
    }
    
    // private void DoTriggeredAction(GameObject obj)
    // {
    //    Destroy(obj);
    // }
}