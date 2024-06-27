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
        base.Enter();
        Debug.Log("Entered Destroy!");
        stateDuration = destroyTime;
        player.DisableMovement();
        player.StopInPlace();
        
        ParticlesManager.PlayFXByType(FXType.Pickup);

        if (player.ItemDestroyer.destroyedItem.TryGetComponent(out Destructible destroyable))
        {
            destroyable.OnDestroyThis();
            player.ItemDestroyer.ResetItemDestroyer();
        }
    }

    public override void Update()
    {
        base.Update();
        if (stateDuration <= 0)
        {
            Debug.Log("Changed to Idle");
            stateMachine.ChangeState(stateMachine.IdleState);
        }

    }

    public override void Exit()
    {
        base.Exit();
        player.EnableMovement();
        
        ParticlesManager.StopFXByType(FXType.Pickup);
    }
}