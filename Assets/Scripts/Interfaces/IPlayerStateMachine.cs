public interface IPlayerStateMachine 
{
    void Initialze();
    void ChangeState(IState newState);
    void CreateStateMachine();
}
