using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatemachine : MonoBehaviour
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
            activeState.enemyStatemachine = this;
            //assign state enemy class
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }
    public void Initialized()
    {
        // setup defultState;
        ChangeState(new IdleState());
    }
}
