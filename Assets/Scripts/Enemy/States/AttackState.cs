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
        AttackTimer += Time.deltaTime;
        if(AttackTimer > enemy.attacktime)
        {
            enemy.AttackPlayer();
            enemy.animator.Play("attack_state");
            AttackTimer = 0;
        }
        
        // if(enemy.CanSeePlayer())
        // {
        //     if(Vector3.Distance(enemy.transform.position,enemy.player.transform.position) > 1f)
        //     {
        //         enemy.Agent.SetDestination(enemy.player.transform.position);
        //         
        //         if (doOnce)
        //         {
        //             enemy.sawPlayer = true;
        //             SoundManager.PlaySound(soundType.ALERT);
        //             enemy.animator.Play("player_move"); 
        //             doOnce = false;
        //         }
        //
        //         
        //     }
        //     else
        //     {
        //         AttackTimer += Time.deltaTime;
        //         if(AttackTimer > enemy.attacktime)
        //         {
        //             enemy.AttackPlayer();
        //             enemy.animator.Play("attack_state");
        //             AttackTimer = 0;
        //         }
        //         
        //     }
        //    
        // }
    }

    
}