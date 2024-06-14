using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpState : PlayerGroundedState
{
    [Header(" Settings ")]
    private float timeToPickup = .2f;

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
        
        player.ItemDetector.detectedItem.SetActive(false);
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
    }
}
