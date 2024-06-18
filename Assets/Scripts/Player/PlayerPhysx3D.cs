using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysx3D : PlayerPhysx
{
    [Header(" RB Settings ")]
    [SerializeField] Rigidbody _rb;
    [SerializeField] float gravityForce;

    [Header(" Ground Detection ")]
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Vector2 groundCheckBoxSize;
    [SerializeField] private float groundCastDistance;

    public override bool IsGrounded => Physics.BoxCast(
        playerTransform.position,
        groundCheckBoxSize / 2,
        -playerTransform.up,
        out _,
        playerTransform.rotation,
        groundCastDistance,
        whatIsGround
        );

    private void FixedUpdate()
    {
        ApplyAdditionalGravity();
    }

    private void ApplyAdditionalGravity()
    {
        if (_rb.velocity.y != 0)
            _rb.AddForce(Vector3.down * gravityForce, ForceMode.Acceleration);
    }

    public override Vector3 CurrentVelocity() => new Vector3(_rb.velocity.x, _rb.velocity.y, _rb.velocity.z);

    public override void HandleMovement(Vector3 movement, float speed)
    {
        _rb.velocity = new Vector3(movement.x * speed, _rb.velocity.y,movement.z * speed);
    }

    public override void Jump(Vector3 jumpVector, float airVelocity, float jumpForce)
    {
        _rb.velocity = new Vector3(jumpVector.x * airVelocity, jumpForce,jumpVector.z * airVelocity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(playerTransform.position - playerTransform.up * groundCastDistance, groundCheckBoxSize); // GroundCheck
    }
}
