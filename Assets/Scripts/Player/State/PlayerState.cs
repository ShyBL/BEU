using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    [Header(" Components ")]
    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected Vector3 rbVelocity;

    [Header(" Settings ")]
    protected float stateDuration;
    private string _animName;
    protected float animLength;

    protected Vector3 moveInputVector = Vector3.zero;


    [Header(" State ")]
    protected bool canAttack = true;
    protected bool isBusy = false;
    protected bool triggerCalled;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string animName)
    {
        player = _player;
        stateMachine = _stateMachine;
        this._animName = animName;
    }

    /// <summary>
    /// On Enter Into state
    /// </summary>
    public virtual void Enter()
    {
        player.Visualizer.PlayAnimation(_animName);
        Debug.Log("Entered : " + this.ToString());
    }

    /// <summary>
    ///  Update for State
    /// </summary>
    public virtual void Update()
    {
        stateDuration -= Time.deltaTime;
        if (player.canMove)
            SetMovementVector();
        player.Visualizer.SetYBlend(rbVelocity.y);

    }

    /// <summary>
    /// On Exit from state
    /// </summary>
    public virtual void Exit()
    {
    }

    private void SetMovementVector()
    {
        moveInputVector = player.moveInputVector;
    }


    protected IEnumerator BusyFor(float seconds)
    {
        isBusy = true;
        Debug.Log("Started");
        yield return new WaitForSeconds(seconds);
        isBusy = false;
    }
}
