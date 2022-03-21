using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingPointsReQueue : MonoBehaviour
{
    public PlantingPointsSpawn plantingPointsSpawn;
    public Camera cam;
    public GameObject gobj;
    void Awake()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    // I should put the clicking conditional script on Main Camera?
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GetBackToPool();
        }
    }

    void GetBackToPool()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // BoxCollider ensures only THIS particular PlantingPoints is returned to pool queue
            BoxCollider bc = hit.collider as BoxCollider;
            if (bc.tag == "PlantingPoints")
            {
                plantingPointsSpawn.ReturningToPool(bc.gameObject);
                Debug.Log("I rightclick already!");
            }
        }
    }
}
