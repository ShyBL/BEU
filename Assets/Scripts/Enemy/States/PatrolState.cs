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
        if (Enemy.CanSeePlayer())
        {
            EnemyStateMachine.ChangeState(new AttackState());
        }
    }
    public void PatrolCycle()
    {
        //implement out patrol cycle
        if(Enemy.Agent.remainingDistance < 0.2f)
        {
            if (waypointIndex < Enemy.path.waypoints.Count - 1)
                waypointIndex++;
            else
                waypointIndex = 0;
            Enemy.Agent.SetDestination(Enemy.path.waypoints[waypointIndex].position);
        }
    }

}
    

