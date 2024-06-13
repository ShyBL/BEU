using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string animName) : base(_player, _stateMachine, animName)
    {
    }


    public override void Enter()
    {
        base.Enter();
    }


    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        CheckIfMoving();
    }


    private void CheckIfMoving()
    {

        if (player.canMove && moveInputVector != Vector3.zero)
        {
            stateMachine.ChangeState(stateMachine.MoveState);
        }
    }

}
