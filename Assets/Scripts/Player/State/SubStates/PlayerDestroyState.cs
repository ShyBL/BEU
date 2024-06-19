using UnityEngine;

public class PlayerDestroyState : PlayerGroundedState
{
    public PlayerDestroyState(Player _player, PlayerStateMachine _stateMachine, string animName) : base(_player, _stateMachine, animName)
    {
    }

    [Header(" Settings ")]
    private float destroyTime = 1f;

    public override void Enter()
    {
        Enter();
        Debug.Log("Entered Pickup!");
        stateDuration = destroyTime;
        player.DisableMovement();
        player.StopInPlace();
        
        ParticlesManager.PlayFXByType(FXType.Pickup);

        if (player.ItemDestroyer.destroyedItem.TryGetComponent(out Destructible destroyable))
        {
            destroyable.OnDestroyThis();
        }
    }

    public override void Update()
    {
        Update();
        if (stateDuration <= 0)
        {
            Debug.Log("Changed to Idle");
            stateMachine.ChangeState(stateMachine.IdleState);
        }

    }

    public override void Exit()
    {
        Exit();
        player.EnableMovement();
        
        ParticlesManager.StopFXByType(FXType.Pickup);
    }
}