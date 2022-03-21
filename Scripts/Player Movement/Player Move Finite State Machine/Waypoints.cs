using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public List<Transform> plantingPointsList = new List<Transform>();
    public int plantingPointsNumber;
    public PlantingPointsSpawn plantingPointsSpawning;

    private void Start()
    {

    }

    public void WhenPlantingPointsArePlaced()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            plantingPointsList.Add(transform.GetChild(i));
        }
        plantingPointsNumber = transform.childCount;
    }
    public void OnDrawGizmos()
    {
        foreach (Transform t in transform)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(t.position, 3f);
        }
        Gizmos.color = Color.gray;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }
    }
    public void ClearTheList()
    {
        foreach(Transform t in plantingPointsList)
        {
            plantingPointsSpawning.ReturningToPool(t.gameObject);
        }
        plantingPointsList.Clear();
    } // Why this method every other pp?
}
