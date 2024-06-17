using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string animName) : base(_player, _stateMachine, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.Jump();
        
        SoundManager.PlaySound(soundType.JUMP);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        HoldAirState();
    }

    private void HoldAirState()
    {
        if (player.Physx.CurrentVelocity().y < 0)
        {
            stateMachine.ChangeState(stateMachine.AirState);
        }
    }
}
