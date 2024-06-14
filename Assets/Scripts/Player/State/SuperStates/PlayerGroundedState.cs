using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string animName) : base(_player, _stateMachine, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Subscribe();
    }

    public override void Exit()
    {
        base.Exit();
        Unsubscribe();
    }

    public override void Update()
    {
        base.Update();
    }

    private void Subscribe()
    {
        player.InputManager.onJump += OnJump;
        player.InputManager.onAction += OnAction;
    }



    private void Unsubscribe()
    {
        player.InputManager.onJump -= OnJump;
        player.InputManager.onAction += OnAction;

    }  

    private void OnJump()
    {
        if (player.isGrounded())
            stateMachine.ChangeState(stateMachine.JumpState);

    }

    /// <summary>
    /// Action will pickup if player over item, else will attack.
    /// </summary>
    private void OnAction()
    {
        if (IsOverPickup())
            stateMachine.ChangeState(stateMachine.PickUpState);
        else
            stateMachine.ChangeState(stateMachine.AttackState);

    }

    private bool IsOverPickup()
    {
        // Insert logic to check for pickup
        return false;
    }

}
