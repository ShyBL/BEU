using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
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
            if(Vector3.Distance(enemy.transform.position,enemy.player.transform.position) > 1.5)
            {
                enemy.Agent.SetDestination(enemy.player.transform.position);
            }
           
        }
    }

    
}