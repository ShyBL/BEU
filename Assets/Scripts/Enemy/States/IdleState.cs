using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    bool isTrigger = true;
    public override void Enter()
    {
       
    }

    public override void Exit()
    {
       
    }

    public override void Perform()
    {
        if (isTrigger)
        {
            if (enemy.CanSeePlayer())
            {
                enemyStatemachine.ChangeState(new AttackState());
            }
        }
       
    }

    
}
