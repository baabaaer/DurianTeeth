using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;


public class PlayerMovingState : PlayerMoveBaseState
{
    // To be used to point where player should go and where to plant
    public Vector3 wayPoint;
   
    public override void EnterState(PlayerMoveManager playerMove, NavMeshAgent playerMoveAI, Waypoints waypoints)
    {
        waypoints.ClearTheList();
        Debug.Log("Helo, I am Moving State!");
    }

    public override void UpdateState(PlayerMoveManager playerMove, NavMeshAgent playerMoveAI, Camera cam, Waypoints waypoints)
    {
        //player = playerMove.player;
        if (Input.GetMouseButtonDown(0))
        {
            //if (EventSystem.current.IsPointerOverGameObject()) { return; }

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;
            if (Physics.Raycast(ray, out hitPoint))
            {
                
                // Setting the points the player should go, in order of first-clicked
                wayPoint = hitPoint.point;

                playerMoveAI.SetDestination(wayPoint);
            
            }
        }

        
        

    }
    public override void ExitState(PlayerMoveManager playerMove, NavMeshAgent playerMoveAI, Waypoints waypoints)
    {
        
    }

    
}
