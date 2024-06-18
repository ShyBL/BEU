using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string animName) : base(_player, _stateMachine, animName)
    {
    }
    // Used because map generator uses Vector2 instead Vector2Int, so its not pixel perfect.
    private static float LANDING_THRESHOLD = 0.001f;

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        SetYBlendAnimation();
        CheckIfIdle();
    }

    private void SetYBlendAnimation()
    {
        player.Visualizer.SetYBlend(player.Physx.CurrentVelocity().y);
    }

    public override void Exit()
    {
        base.Exit();
    }
    
    private void CheckIfIdle()
    {
        if (player.isGrounded() && player.Physx.CurrentVelocity().y < LANDING_THRESHOLD)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }

}
