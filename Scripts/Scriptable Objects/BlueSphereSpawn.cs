using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSphereSpawn : MonoBehaviour
{
    // No need to call events nor invoke to any ScrObjPool here!
    // Scriptable objects are modular and you may hurt your brain
    // Trying to split which pool is which pool to be
    // Invoked or Listened to!

    public ScrObjPool scrObjPool;

    // Instead, try to be the invoker here, and call a planting points prefab by click of a
    // mouse button.

    void Awake()
    {
        scrObjPool.SpawnPool();
    }

}
