using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerPreparingState : PlayerMoveBaseState
{
    public Vector3 whereToPlant;
    
    public override void EnterState(PlayerMoveManager playerMove, NavMeshAgent playerMoveAI, Waypoints waypoints)
    {
        Debug.Log("Helo, I am Preparing State!");
    }
    public override void UpdateState(PlayerMoveManager playerMove, NavMeshAgent playerMoveAI, Camera cam, Waypoints waypoints)
    {
        if (Input.GetMouseButtonDown(0))
        {
            //if (EventSystem.current.IsPointerOverGameObject()) { return; }

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;
            if (Physics.Raycast(ray, out hitPoint))
            {
                // Setting the points the player should go, in order of first-clicked
                whereToPlant = hitPoint.point;
                playerMove.ThePlanting(whereToPlant);

            }
        }
    }

    public override void ExitState(PlayerMoveManager playerMove, NavMeshAgent playerMoveAI, Waypoints waypoints)
    {
        waypoints.WhenPlantingPointsArePlaced();
    }
}
