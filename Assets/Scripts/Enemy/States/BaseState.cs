
public abstract class BaseState 
{
    public Enemy Enemy;
    public EnemyStateMachine EnemyStateMachine;
    
    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();

}