using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysx: MonoBehaviour
{

    ///
    /// The game requires 2D & 3D Physx.
    /// Therefor this class is created to still keep Player class generic as much as possible.
    ///

    [SerializeField] protected Transform playerTransform;

    public virtual Vector3 CurrentVelocity()
    {
        return Vector3.zero;
    }

    public virtual void HandleMovement(Vector3 movement, float speed) { } 
    
    public virtual void Jump(Vector3 jumpVector,float airVelocity, float jumpForce) { }
    public virtual bool IsGrounded { get; }


}
