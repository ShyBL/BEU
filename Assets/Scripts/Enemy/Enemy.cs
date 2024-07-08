using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public EnemyStateMachine stateMachine;
    private NavMeshAgent agent;
    public Animator animator;
    public NavMeshAgent Agent { get => agent; }
    public Path path;
    public GameObject player;
    private Player playerFunc;
    public float sightDistance = 30f;
    // public float attckDistance = 1f;
    public float fieldOfView = 300f;

    [Header("Stats")]
    public int maxHealth = 15;
    public int currentHealth;
    [SerializeField] private int hitDamage = 1 ;
    public int attacktime = 2;
    public bool IsAlive;
    public bool sawPlayer ;

    
    //public Transfom attckpoint
    
    void Awake()
    {
        IsAlive = true;
        stateMachine = GetComponent<EnemyStateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialized();
        player = GameObject.FindGameObjectWithTag("Player");
        playerFunc = player.GetComponent<Player>();
        currentHealth = maxHealth;
        animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        if (sawPlayer && IsAlive)
        {
            this.transform.LookAt(player.transform.position);
        }
        
    }
    public bool CanSeePlayer()
    {
        if(player != null)
        {
            // is the player close enough to be seen
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance )
            {
                Vector3 targetDirection = player.transform.position - transform.position; 
                float angleToPlayer = Vector3.Angle(targetDirection,transform.forward );
                if( angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position,targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if( Physics.Raycast(ray,out hitInfo,sightDistance))
                    {
                        if(hitInfo.transform.gameObject == player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            sawPlayer = true;
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
    public void AttackPlayer()
    {
        Debug.Log("Attack" + hitDamage);
        
        //Collider hitPlayer = Physics.OverlapSphere(atttackPoint.position,attckDistance)
        playerFunc.PlayerCombat.GotHit(hitDamage);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        animator.Play("hurt_state");
        
        if (currentHealth <= 0)
        {
            IsAlive = false;
            Die();
        }
    }

    private void Die()
    {
        stateMachine.ChangeState(new DeadState());
        
        var obj = gameObject.GetComponent<BoxCollider>();
        obj.enabled = false;
        agent.enabled = false;
        
        Debug.Log(this.name + " DEAD");
        
    }
}