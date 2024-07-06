using UnityEngine;

public class AttackState : BaseState
{
    private float _attackTimer;
    
    public override void Enter()
    {
        Enemy.animator.Play("attack_state");
    }

    public override void Exit()
    {
    }

    public override void Perform()
    {
        // If player is too far to attack, Move
        if(Vector3.Distance(Enemy.transform.position,Enemy.player.transform.position) > 2f)
        {
            EnemyStateMachine.ChangeState(new MoveState());
        }
        else
        {
            // Attack if the timer reached the desired time in the enemy data
            AttackOnTimer();
            
            // If the hurt animation is playing, wait until it finished
            var animatorStateInfo = Enemy.animator.GetCurrentAnimatorStateInfo(0);
            if (!animatorStateInfo.IsName(States.ATTACK) & animatorStateInfo.normalizedTime >= 1)
            {
                Enemy.animator.Play(States.ATTACK);
            }
            
        }
    }

    private void AttackOnTimer()
    {
        if (Timer())
        {
            Enemy.AttackPlayer();
            _attackTimer = 0;
        }
    }

    private bool Timer()
    {
        _attackTimer += Time.deltaTime;
        return (_attackTimer > Enemy.attacktime);
    }
}