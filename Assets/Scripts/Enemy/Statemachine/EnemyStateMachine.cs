using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public BaseState activeState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeState != null)
        {
            activeState.Perform();
        }
    }
    public void ChangeState(BaseState newState)
    {
        //check activeState != Null
        if (activeState != null )
        {
            //run Cleanup on activeState
            activeState.Exit();
        }
        // change to new state
        activeState = newState;
        
        //fail-safe null check to make sure new state wasn't null
        if (activeState != null )
        {
            //Setup new state
            activeState.EnemyStateMachine = this;
            //assign state enemy class
            activeState.Enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }
    public void Initialized()
    {
        // setup default State;
        ChangeState(new IdleState());
    }
    
    Rect rect = new Rect(0, 0, 300, 100);
    Vector3 offset = new Vector3(0f, 0f, 0.5f);
    
#if !PLATFORM_STANDALONE
    void OnGUI()
    {
        Vector3 point = Camera.main.WorldToScreenPoint(transform.position + offset);
        rect.x = point.x;
        rect.y = Screen.height - point.y - rect.height; // bottom left corner set to the 3D point
        GUI.Label(rect, activeState.ToString()); // display its name, or other string
    }
#endif
    
}
