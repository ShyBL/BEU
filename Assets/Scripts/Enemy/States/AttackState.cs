using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float AttackTimer;
    private bool doOnce = true;
    
    public override void Enter()
    {
        enemy.animator.Play("attack_state");
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        if(Vector3.Distance(enemy.transform.position,enemy.player.transform.position) > 2f)
        {
            EnemyStateMachine.ChangeState(new MoveState());
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