using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingPointsSpawn : MonoBehaviour
{   
    public ScrObjPool scrObjPool;
    public PlayerMoveManager playerMove;
    public Waypoints waypoints;

    public int howManyPlantingPoints;
    public GameObject inActiveParent;
    public GameObject activeParent;
    // public PlantingPointsReQueue plantingPointsReQueue;
    
    void Awake()
    {
        scrObjPool.amount = howManyPlantingPoints;
        scrObjPool.anyPrefabParent = inActiveParent.transform;
        scrObjPool.anyPrefabParentActive = activeParent.transform;
        scrObjPool.SpawnPool();
        
    }

    void Start()
    {
        if(activeParent == null)
        {
            scrObjPool.anyPrefabParentActive.gameObject.AddComponent<Waypoints>();
        }
        playerMove.plantingPlace += PlantItHere;
    }

    // For methods that listens to the event, you have to set the 
    // return type and argument type to be the same! You can use
    // another metod if you need a different return type.

    public Vector3 PlantItHere(Vector3 plantingPlace)
    {
        Debug.Log("Ye, cari saye?");
        PlacingThePoints(plantingPlace);
        return plantingPlace;

    }

    public void PlacingThePoints(Vector3 plantingPlaces)
    {
        scrObjPool.PooledObjectsOut(plantingPlaces, Quaternion.identity);
    }

    // Well, you can't make events to pass a gameobject itself as
    // the thing in the Invoke

    public void ReturningToPool(GameObject gobj)
    {
        scrObjPool.PooledObjectsIn(gobj);
    }

}
