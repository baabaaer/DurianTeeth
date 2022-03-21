using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoveMouseNavMesh : MonoBehaviour
{
    // The most basic component for player nav with NavMesh
    public Camera cam;
    public NavMeshAgent player;
    
    // This GameObject is used as a flagpole to remind you where you clicked
    public Vector3 wayPoint;

    // Handles Movement input
    public GameObject moveInputHandler;
    private MoveInputHandler moveInput;

    // We need an event to ask where the clicked point is
    public delegate Vector3 whereToPlant(Vector3 vector);
    public event whereToPlant plantingPlace;


    void Awake()
    {
        moveInput = moveInputHandler.transform.GetComponent<MoveInputHandler>();
    }
     
    void Update()
    {
        if (moveInput.LeftClick)
        {
            Ray ray = cam.ScreenPointToRay(moveInput.MousePosition);
            RaycastHit hitPoint;
            if(Physics.Raycast(ray, out hitPoint))
            {
                // Setting the points the player should go, in order of first-clicked
                wayPoint = hitPoint.point;
                
                player.SetDestination(wayPoint);

               plantingPlace?.Invoke(wayPoint);
                
            }
        }

    }

   
}
