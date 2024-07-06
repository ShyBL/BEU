public class DeadState : BaseState
{
    bool _isTriggered = true;
    
    public override void Enter()
    {
        Enemy.animator.Play("dead_state");
    }

    public override void Exit()
    {
       
    }
    public override void Perform()
    {
        if (!_isTriggered) return;
        
        Enemy.Agent.isStopped = true; // Stops Navmesh Agent
    }
}