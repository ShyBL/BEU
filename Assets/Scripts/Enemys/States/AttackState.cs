using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    public override void Enter()
    {
       
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        if(enemy.CanSeePlayer())
        {
            
                enemy.Agent.SetDestination(enemy.player.transform.position);
                moveTimer = 0;
        
        }
        
    }

    
}
