
public abstract class BaseState 
{
    //Instance of EnemyClass
    public Enemy enemy;
    //Instance of Statemachine class
    public EnemyStatemachine enemyStatemachine;
    

    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();

}
