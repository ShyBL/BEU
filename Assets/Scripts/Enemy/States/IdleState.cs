using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    bool isTrigger = false;
    public override void Enter()
    {
       
    }

    public override void Exit()
    {
       
    }

    public override void Perform()
    {
        if (isTrigger == true)
        {
            if (enemy.CanSeePlayer())
            {
                enemyStatemachine.ChangeState(new AttackState());
            }
        }
       
    }

    
}
