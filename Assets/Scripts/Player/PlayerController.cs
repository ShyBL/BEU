using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayerController
{ 
    public Vector3 moveVector { get; private set; }
    public PlayerInputManager playerInputManager { get; private set; }
    private void Start()
    {
        moveVector = Vector3.zero;
    }



}
