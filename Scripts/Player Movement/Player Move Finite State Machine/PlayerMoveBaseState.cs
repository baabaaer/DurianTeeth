using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class PlayerMoveBaseState
{
    public abstract void EnterState(PlayerMoveManager playerMove, NavMeshAgent playerMoveAI, Waypoints waypoints);
    public abstract void UpdateState(PlayerMoveManager playerMove, NavMeshAgent playerMoveAI, Camera cam, Waypoints waypoints);
    public abstract void ExitState(PlayerMoveManager playerMove, NavMeshAgent playerMoveAI, Waypoints waypoints);
        
}
