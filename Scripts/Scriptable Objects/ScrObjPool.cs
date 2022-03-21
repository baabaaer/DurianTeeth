using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects Pool")]
public class ScrObjPool : ScriptableObject
{
    public GameObject anyPrefab;
    public Queue<GameObject> spawnedObjs;
    [SerializeField] public Transform anyPrefabParent;
    [SerializeField] public Transform anyPrefabParentActive;
    public int amount;

    public void SpawnPool()
    {
        if (spawnedObjs == null || spawnedObjs.Count == 0)
        {
            spawnedObjs = new Queue<GameObject>();
        }

        if(spawnedObjs.Count >= amount) { return; }

        if (!anyPrefabParent)
        {
            anyPrefabParent = new GameObject(name + " Inactive").transform;
        }

        while(spawnedObjs.Count < amount)
        {
            GameObject obj = Instantiate(anyPrefab, anyPrefabParent.transform);
            obj.SetActive(false);
            spawnedObjs.Enqueue(obj);
        }

        if (!anyPrefabParentActive)
        {
            anyPrefabParentActive = new GameObject(name + " Active").transform;
        }
    }

    public void PooledObjectsOut(Vector3 newPos, Quaternion newRot)
    {
        if (spawnedObjs == null || spawnedObjs.Count == 0)
        {
            Debug.Log("Empty Lah!");
        }
        else 
        {
            GameObject dishedOut = spawnedObjs.Dequeue();
            dishedOut.transform.position = newPos;
            dishedOut.transform.rotation = newRot;
            dishedOut.transform.SetParent(anyPrefabParentActive);
            dishedOut.SetActive(true);
        }
    }

    public void PooledObjectsIn(GameObject queueBackToPool)
    {
        queueBackToPool.transform.position = Vector3.zero;
        queueBackToPool.transform.rotation = Quaternion.identity;
        queueBackToPool.transform.SetParent(anyPrefabParent);
        spawnedObjs.Enqueue(queueBackToPool);
        if(queueBackToPool.activeSelf != false)
            queueBackToPool.SetActive(false);

    }
}
