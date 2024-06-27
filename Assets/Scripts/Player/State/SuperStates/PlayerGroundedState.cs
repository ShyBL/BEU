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
        player.InputManager.onAction -= OnAction;

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
        //if (!player.isGrounded() || !canAttack) 
        if (!canAttack)
        {
            Debug.Log("Cant Attack");
            return;
        }

        if (IsOverPickup())
        {
            stateMachine.ChangeState(stateMachine.PickUpState);
        }
            
        else if (IsOverDestroyable())
        {
            stateMachine.ChangeState(stateMachine.DestroyState);
        }
        else
        {
            stateMachine.ChangeState(stateMachine.AttackState);
        }
            

    }

    private bool IsOverPickup()
    {
        return player.ItemDetector.itemDetected ? true : false;
    }
    
    private bool IsOverDestroyable()
    {
        return player.ItemDestroyer.itemDetected ? true : false;
    }

}
