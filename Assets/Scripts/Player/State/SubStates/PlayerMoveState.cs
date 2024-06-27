using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    private Coroutine footstepCoroutine;
    private float footstepInterval = 0.45f;

    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string animName) : base(_player, _stateMachine, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartFootstepSound();
        ParticlesManager.PlayFXByType(FXType.Footsteps);
    }

    public override void Exit()
    {
        base.Exit();
        StopFootstepSound();
        ParticlesManager.StopFXByType(FXType.Footsteps);
    }

    public override void Update()
    {
        base.Update();
        
        CheckIfStopped();
        //CheckIfFalling();
    }

    private void CheckIfStopped()
    {
        if (moveInputVector == Vector3.zero)
            stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void CheckIfFalling()
    {
        if (!player.isGrounded())
            stateMachine.ChangeState(stateMachine.AirState);
    }

    private void StartFootstepSound()
    {
        if (footstepCoroutine == null)
        {
            footstepCoroutine = player.StartCoroutine(FootstepSoundCoroutine());
        }
    }

    private void StopFootstepSound()
    {
        if (footstepCoroutine != null)
        {
            player.StopCoroutine(footstepCoroutine);
            footstepCoroutine = null;
        }
    }

    private IEnumerator FootstepSoundCoroutine()
    {
        while (true)
        {
            if (moveInputVector != Vector3.zero)// && player.isGrounded())
            {
                SoundManager.PlaySound(soundType.WALKING);
            }
            yield return new WaitForSeconds(footstepInterval);
        }
    }
}