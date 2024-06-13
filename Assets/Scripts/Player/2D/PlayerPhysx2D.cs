using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysx2D : PlayerPhysx
{
    [SerializeField] Rigidbody2D _rb;

    [Header(" Ground Detection ")]
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Vector2 groundCheckBoxSize;
    [SerializeField] private float groundCastDistance;
    public override bool IsGrounded => Physics2D.BoxCast(playerTransform.position, groundCheckBoxSize, 0, -playerTransform.up, groundCastDistance, whatIsGround);

    public override Vector3 CurrentVelocity() => new Vector3(_rb.velocity.x, _rb.velocity.y, 0);

    public override void HandleMovement(Vector3 movement, float speed)
    {
        _rb.velocity = new Vector2(movement.x * speed, _rb.velocity.y);
    }

    public override void Jump(Vector3 jumpVector, float airVelocity, float jumpForce)
    {
        _rb.velocity = new Vector2(jumpVector.x * airVelocity, jumpForce);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(playerTransform.position - playerTransform.up * groundCastDistance, groundCheckBoxSize); // GroundCheck
    }
}
