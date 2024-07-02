using UnityEngine;

public class MoveState : BaseState
{
    private bool doOnce = true;
    
    public override void Enter()
    {
       
    }

    public override void Exit()
    {
       
    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            if(Vector3.Distance(enemy.transform.position,enemy.player.transform.position) > 2f)
            {
                enemy.Agent.SetDestination(enemy.player.transform.position);
                
                if (doOnce)
                {
                    enemy.sawPlayer = true;
                    SoundManager.PlaySound(soundType.ALERT);
                    enemy.animator.Play("player_move"); 
                    doOnce = false;
                }
            }
            else
            {
                //enemy.Agent.isStopped = true;
                EnemyStateMachine.ChangeState(new AttackState());
            }
                
        }
    }
}