using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    [Header(" Movement ")]
    [SerializeField] private float _moveSpeed = 8f; public float moveSpeed { get => _moveSpeed; }
    [SerializeField] private float _airVelocity = 8f; public float airVelocity { get => _airVelocity; }
    [SerializeField] private float _jumpForce = 15; public float jumpForce { get => _jumpForce; }
    [SerializeField] private bool _canMove = true; public bool canMove { get => _canMove; }

    [Header(" Components ")]
    [SerializeField] private PlayerVisualizer _visualizer; public PlayerVisualizer Visualizer { get => _visualizer; }
    [SerializeField] private PlayerPhysx _playerPhysx; public PlayerPhysx Physx { get => _playerPhysx; }
    [SerializeField] private PlayerStateMachine _stateMachine; public PlayerStateMachine StateMachine { get => _stateMachine; }
    [SerializeField] private PlayerInputManager _inputManager; public PlayerInputManager InputManager { get => _inputManager; }
    [SerializeField] private PlayerItemDetector _playerItemDetector; public PlayerItemDetector ItemDetector { get => _playerItemDetector; }
    [SerializeField] private PlayerItemDestroyer _playerItemDestroyer; public PlayerItemDestroyer ItemDestroyer { get => _playerItemDestroyer; }

    
    [Header(" General Settings ")]
    [SerializeField] private bool is3DMode;

    [Header("Stats")]
    [SerializeField] private int MaxHealth;
    [SerializeField] private int HitDamage = 5;

    private int currentHealth;
    public Vector3 moveInputVector { get; private set; }
    public int facingDirection { get; private set; }
    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayer;

    Rect rect = new Rect(0, 0, 300, 100);
    Vector3 offset = new Vector3(0f, 0f, 0.5f);

    private void OnEnable()
    {
        _inputManager.onMove += MovementHandler;
        _inputManager.onMoveStopped += MovementHandler;
        _inputManager.onAttack += Attack;
    }

    private void OnDisable()
    {
        _inputManager.onMove -= MovementHandler;
        _inputManager.onMoveStopped -= MovementHandler;
        _inputManager.onAttack -= Attack;
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

    }

    void Start()
    {
        currentHealth = MaxHealth;
        _stateMachine = new PlayerStateMachine();
        _stateMachine.Initialize();
    }

    void Update()
    {
        if(_inputManager)
        {

        }
        _stateMachine.currentState.Update();
        MovementHandler();
    }


    private void MovementHandler()
    {
        if (canMove) {
            moveInputVector = _inputManager.moveVector;
            Flip();
            _playerPhysx.HandleMovement(moveInputVector, _moveSpeed);
        }
        

    }

    public void Flip()
    {

        if (moveInputVector.x != 0)
        {
            facingDirection = moveInputVector.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(1 * facingDirection, 1, 1);

            var shape = ParticlesManager.instance.Footsteps.shape;
            if (facingDirection == -1)
            {
                shape.rotation = new Vector3(0, 90, 0);
            }
            else
            {
                shape.rotation = new Vector3(0, -90, 0);
            }
            
            
        }
            
    }

    public void Jump() => _playerPhysx.Jump(moveInputVector, _airVelocity, _jumpForce);
    public void EnableMovement() => _canMove = true;
    public void StopInPlace() => _playerPhysx.HandleMovement(new Vector3(0,0,0), 0);
    public void DisableMovement() => _canMove = false;

    // Physx Getters
    public Vector3 velocity() => _playerPhysx.CurrentVelocity();
    public bool isGrounded() => _playerPhysx.IsGrounded;

    void OnGUI()
    {
        Vector3 point = Camera.main.WorldToScreenPoint(transform.position + offset);
        rect.x = point.x;
        rect.y = Screen.height - point.y - rect.height; // bottom left corner set to the 3D point
        GUI.Label(rect, _stateMachine.currentState.ToString()); // display its name, or other string
    }
    public void Attack()
    {
        Debug.Log("Player Attack");
        // start animation
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange,enemyLayer);
        foreach (Collider enemy in hitEnemies)
        {
            //damage them
            enemy.GetComponent<Enemy>().TakeDamage(HitDamage);
            Debug.Log("We hit" + enemy.name);
        }
    }

    public void GotHit(int damage)
    {
        currentHealth -= damage;
        //play animation
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //die animation
        //disable object
        //Debug.Log("Die!!!!");
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}