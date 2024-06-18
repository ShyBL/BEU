using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public EnemyStatemachine stateMachine;
    private NavMeshAgent agent;
    public NavMeshAgent Agent { get => agent; }
    public Path path;
    public GameObject player;
    public float sightDistance = 30f;
    public float attckDistance = 5f;
    public float fieldOfView = 300f;

    [Header("Stats")]
    public int maxHealth = 100;
    public int currentHealth;
    [SerializeField] private int hitDamage = 5 ;


    private bool doSoundOnce = true;
    private const string IS_WALKING_PARAM = "IsWalk";
    
    //thingis to add
    //public Transfom attckpoint
    
    void Awake()
    {
        stateMachine = GetComponent<EnemyStatemachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialized();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();

    }
    public bool CanSeePlayer()
    {
        if(player != null)
        {
            // is the player colse enough to be seen
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
                           
                            if(doSoundOnce)
                            {
                                SoundManager.PlaySound(soundType.ALERT);
                                doSoundOnce = false;
                            }
                             
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
        // Detect if player in range

        if (Vector3.Distance(transform.position,player.transform.position) > attckDistance)
        {
            // start animation
            //Collider hitPlayer = Physics.OverlapSphere(atttackPoint.position,attckDistance)
            //damage them
            //player.health.hit()
        }
   
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //play animation
        if (currentHealth <= 0 )
        {
            Die();
        }
    }

    private void Die()
    {
        //die animation
        //disable object
    }
}
