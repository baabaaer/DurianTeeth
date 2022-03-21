using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;


public class PlayerPlantingState : PlayerMoveBaseState
{
    public Transform currentWaypoint;
    public List<Transform> plantingPlaces = new List<Transform>();
    private int i=0;
    
    public override void EnterState(PlayerMoveManager playerMove, NavMeshAgent playerMoveAI, Waypoints waypoints)
    {
        plantingPlaces = waypoints.plantingPointsList;
        Debug.Log("Helo, I am Planting State!");
    }

    public override void UpdateState(PlayerMoveManager playerMove, NavMeshAgent playerMoveAI, Camera cam, Waypoints waypoints)
    {
        currentWaypoint = plantingPlaces[i];
       
        if ( i < plantingPlaces.Count )
        {
            if (Vector3.Distance(playerMoveAI.transform.position, currentWaypoint.position) < 2f)
            {
                i++;
                if (i == plantingPlaces.Count)
                {
                    i = 0;
                    ExitState(playerMove, playerMoveAI, waypoints);
                }
                else
                {
                    currentWaypoint = plantingPlaces[i];
                    playerMoveAI.SetDestination(currentWaypoint.position);
                }
                
            }
            if (Vector3.Distance(playerMoveAI.transform.position, currentWaypoint.position) > 2f)
            {
                // This code will make player go to nearest PP despite it's index on plantingPointsList
                playerMoveAI.SetDestination(currentWaypoint.position);
            } 
        }
    } 

    public override void ExitState(PlayerMoveManager playerMove, NavMeshAgent playerMoveAI, Waypoints waypoints)
    {
        waypoints.ClearTheList();
        playerMove.ToMoveState();
        Debug.Log("Congrats!");
    }
}
