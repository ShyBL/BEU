public class IdleState : BaseState
{
    bool _isTriggered = true;
    
    public override void Enter()
    {
       
    }

    public override void Exit()
    {
       
    }

    public override void Perform()
    {
        if (!_isTriggered) return;
        
        if (Enemy.CanSeePlayer())
        {
            EnemyStateMachine.ChangeState(new MoveState());
        }
    }
}