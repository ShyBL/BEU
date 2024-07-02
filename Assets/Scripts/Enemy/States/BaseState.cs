
public abstract class BaseState 
{
    //Instance of EnemyClass
    public Enemy enemy;
    //Instance of Statemachine class
    public EnemyStateMachine EnemyStateMachine;
    

    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();

}
