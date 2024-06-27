using UnityEngine;

public class PlayerPickUpState : PlayerGroundedState
{
    public PlayerPickUpState(Player _player, PlayerStateMachine _stateMachine, string animName) : base(_player, _stateMachine, animName)
    {
    }

    [Header(" Settings ")]
    private float pickupTime = 1f;

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered Pickup!");
        stateDuration = pickupTime;
        player.DisableMovement();
        player.StopInPlace();
        
        ParticlesManager.PlayFXByType(FXType.Pickup);

        if (player.ItemDetector.detectedItem.TryGetComponent(out Pickup pickup))
        {
            pickup.OnPickUp();
            player.ItemDetector.ResetItemDetector();
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