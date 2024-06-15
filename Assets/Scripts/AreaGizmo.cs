using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaGizmo : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 1, 0.55F);
        var transform1 = transform;
        Gizmos.DrawCube(transform1.position, transform1.localScale);
    }
}
