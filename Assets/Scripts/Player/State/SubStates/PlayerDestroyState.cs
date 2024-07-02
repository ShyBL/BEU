using UnityEngine;

public class PlayerDestroyState : PlayerGroundedState
{
    public PlayerDestroyState(Player _player, PlayerStateMachine _stateMachine, string animName) : base(_player, _stateMachine, animName)
    {
    }

    [Header(" Settings ")]
    private float destroyTime = 1.21f;

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered Destroy!");
        stateDuration = destroyTime;
        player.DisableMovement();
        player.StopInPlace();
        

    }

    public override void Update()
    {
        base.Update();
        if (stateDuration <= 0)
        {
            if (player.ItemDestroyer.destroyedItem.TryGetComponent(out Destructible destroyable))
            {
                destroyable.OnDestroyThis();
                player.ItemDestroyer.ResetItemDestroyer();
            }
            
            Debug.Log("Changed to Idle");
            stateMachine.ChangeState(stateMachine.IdleState);
        }

    }

    public override void Exit()
    {
        base.Exit();
        player.EnableMovement();
    }
}