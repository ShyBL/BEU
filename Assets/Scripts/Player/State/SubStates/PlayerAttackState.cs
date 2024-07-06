using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAttackState : PlayerGroundedState
{
    public PlayerAttackState(Player _player, PlayerStateMachine _stateMachine, string animName) : base(_player, _stateMachine, animName)
    {
    }

    [Header(" Settings ")]
    private float minTimeBetweenAttacks = 1f;


    public override void Enter()
    {
        base.Enter();
        canAttack = false;
        player.DisableMovement();
        player.StopInPlace();
        //ParticlesManager.PlayFXByType(FXType.Pickup);
    }

    public override void Update()
    {
        base.Update();
        if (stateDuration <= 0) {
            Debug.Log("Changed to Idle");
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        canAttack = true;
        player.EnableMovement();
        //ParticlesManager.StopFXByType(FXType.Pickup);
    }

}
