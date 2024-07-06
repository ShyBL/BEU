using UnityEngine;

public class MoveState : BaseState
{
    private bool doOnce = true;
    
    public override void Enter()
    {
        Enemy.Agent.isStopped = false; // Make sure the Navmesh Agent is not moving before Preform
        
        SoundManager.PlaySound(soundType.ALERT);
        
        Enemy.animator.Play("player_move");
    }

    public override void Exit()
    {
    }

    public override void Perform()
    {
        if (Vector3.Distance(Enemy.transform.position, Enemy.player.transform.position) < 2f)
        {
            Enemy.Agent.isStopped = true; // Stops Navmesh Agent
            
            EnemyStateMachine.ChangeState(new AttackState());
        }
        else
        {
            // If Agent is not close enough, keep moving
            Enemy.Agent.SetDestination(Enemy.player.transform.position);
        }
    }
}