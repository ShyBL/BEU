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

    public override void Enter()
    {
        base.Enter();
        player.StartCoroutine(BusyFor(timeToPickup));

    }

    public override void Update()
    {
        base.Update();
        if (!isBusy)
            stateMachine.ChangeState(stateMachine.IdleState);

    }

    public override void Exit()
    {
        base.Exit();

    }
}
