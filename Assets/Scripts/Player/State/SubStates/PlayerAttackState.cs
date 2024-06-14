using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerGroundedState
{
    public PlayerAttackState(Player _player, PlayerStateMachine _stateMachine, string animName) : base(_player, _stateMachine, animName)
    {

    }

    [Header(" Settings ")]
    private float minTimeBetweenAttacks = .2f;


    public override void Enter()
    {
        base.Enter();
        player.StartCoroutine(BusyFor(minTimeBetweenAttacks));

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
