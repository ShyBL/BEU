using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int waypointIndex;
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        PatrolCycle();
        if (enemy.CanSeePlayer())
        {
            EnemyStateMachine.ChangeState(new AttackState());
        }
    }
    public void PatrolCycle()
    {
        //implement out patrol cycle
        if(enemy.Agent.remainingDistance < 0.2f)
        {
            if (waypointIndex < enemy.path.waypoints.Count - 1)
                waypointIndex++;
            else
                waypointIndex = 0;
            enemy.Agent.SetDestination(enemy.path.waypoints[waypointIndex].position);
        }
    }

}
    

