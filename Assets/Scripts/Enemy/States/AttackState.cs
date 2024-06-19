using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float AttackTimer;

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
            if(Vector3.Distance(enemy.transform.position,enemy.player.transform.position) > 1)
            {
                enemy.Agent.SetDestination(enemy.player.transform.position);
            }
            else
            {
                AttackTimer += Time.deltaTime;
                if(AttackTimer > enemy.attacktime)
                {
                    enemy.AttackPlayer();
                    AttackTimer = 0;
                }
                
            }
           
        }
    }

    
}