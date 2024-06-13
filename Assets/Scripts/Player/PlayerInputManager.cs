using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private PlayerActionAsset _actionAsset;

    [Header(" Actions ")]
    public Action onJump;
    public Action onAction;
    public Action onMove;
    public Action onMoveStopped;
    public Action onDash;

    public Vector3 moveVector {  get; private set; }
    
    private void OnEnable()
    {
        _actionAsset = new PlayerActionAsset();
        _actionAsset.Enable();
        _actionAsset.Player.Move.performed += OnMovePerformed;
        _actionAsset.Player.Move.canceled += OnMoveCanceled;
        _actionAsset.Player.Jump.performed += OnJumpPerformed;
        _actionAsset.Player.Action.performed += OnActionPerformed;
        _actionAsset.Player.Dash.performed += OnDashPerfromed;
    }
    
    private void OnDisable()
    {
        _actionAsset.Player.Move.performed -= OnMovePerformed;
        _actionAsset.Player.Move.canceled -= OnMoveCanceled;
        _actionAsset.Player.Jump.performed -= OnJumpPerformed;
        _actionAsset.Player.Action.performed -= OnActionPerformed;
        _actionAsset.Player.Dash.performed -= OnDashPerfromed;
        _actionAsset.Disable();
    }
    
    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        float xVector = _actionAsset.Player.Move.ReadValue<Vector2>().x;
        float zVector = _actionAsset.Player.Move.ReadValue<Vector2>().y; // Using Y to move on Z
        moveVector = new Vector3(xVector, 0, zVector).normalized;
        onMove?.Invoke();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        moveVector = Vector3.zero;
        onMoveStopped?.Invoke();
    }

    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        onJump?.Invoke();
    }

    private void OnActionPerformed(InputAction.CallbackContext context)
    {
        onAction?.Invoke();
    }

    private void OnDashPerfromed(InputAction.CallbackContext context)
    {
        onDash?.Invoke();
    }
}
