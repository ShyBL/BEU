using UnityEngine;

public class MoveState : BaseState
{
    private bool doOnce = true;
    
    public override void Enter()
    {
        //enemy.Agent.SetDestination(enemy.player.transform.position);
        enemy.Agent.isStopped = false;
        SoundManager.PlaySound(soundType.ALERT);
        enemy.animator.Play("player_move");
    }

    public override void Exit()
    {
       
    }

    public override void Perform()
    {
        if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) < 2f)
        {
            enemy.Agent.isStopped = true;
            EnemyStateMachine.ChangeState(new AttackState());
        }
        else
        {
            enemy.Agent.SetDestination(enemy.player.transform.position);
        }
        
        // if (enemy.CanSeePlayer())
        // {
        //     if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) > 1f)
        //     {
        //         enemy.Agent.SetDestination(enemy.player.transform.position);
        //
        //         if (doOnce)
        //         {
        //             SoundManager.PlaySound(soundType.ALERT);
        //             enemy.animator.Play("player_move");
        //             doOnce = false;
        //         }
        //     }
        //     else
        //     {
        //         //enemy.Agent.isStopped = true;
        //         EnemyStateMachine.ChangeState(new AttackState());
        //     }
        // }
    }
}