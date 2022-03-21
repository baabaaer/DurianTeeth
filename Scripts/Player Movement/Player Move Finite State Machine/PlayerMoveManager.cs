using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PlayerMoveManager : MonoBehaviour
{
    // The most basic component for player nav with NavMesh
    public Camera cam;
    public NavMeshAgent player;

    // To be used to point where player should go and where to plant
    public Button moveStateButton;
    public Button prepareStateButton;
    public Button plantStateButton;
    public Button readyPPButton;
    public Vector3 wayPoint;
    public Waypoints waypoints;
    public float distanceThreshold = 0.05f;
    public PlayerMoveBaseState currentMove;
    
    // Sets up the finite states
    public PlayerPlantingState plantingState = new PlayerPlantingState();
    public PlayerPreparingState preparingState = new PlayerPreparingState();
    public PlayerMovingState movingState = new PlayerMovingState();

    // We need an event to ask where the clicked point is
    public delegate Vector3 whereToPlant(Vector3 vector);
    public event whereToPlant plantingPlace;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        ToMoveState();
        //currentMove = movingState;
        //currentMove.EnterState(this, player, waypoints);
        if (wayPoint == null)
        {
            waypoints = GameObject.Find("PlantingPointsPool Active").GetComponent<Waypoints>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentMove.UpdateState(this, player, cam, waypoints);
        
    }

    public void ToPrepareState()
    {
        SwitchState(this.preparingState);
        moveStateButton.gameObject.SetActive(false);
        prepareStateButton.gameObject.SetActive(true);
        plantStateButton.gameObject.SetActive(false);
        readyPPButton.gameObject.SetActive(true);
    }

    public void ToPlantState()
    {
        // Don't like this at all, how to summon ExitState of preparing State without it being part of entering planting State?
        // I need it to be exited to moving State too!
        preparingState.ExitState(this, player, waypoints);
        
        SwitchState(this.plantingState);
        moveStateButton.gameObject.SetActive(false);
        prepareStateButton.gameObject.SetActive(false);
        plantStateButton.gameObject.SetActive(true);
        readyPPButton.gameObject.SetActive(false);
    }

    public void ToMoveState()
    {
        SwitchState(this.movingState);
        moveStateButton.gameObject.SetActive(true);
        prepareStateButton.gameObject.SetActive(false);
        plantStateButton.gameObject.SetActive(false);
    }

    public void SwitchState(PlayerMoveBaseState move)
    {
        currentMove = move;
        move.EnterState(this, player, waypoints);
    }
       
    public void ThePlanting(Vector3 point)
    {
        wayPoint = point;
        plantingPlace?.Invoke(wayPoint);
    }

   
}
