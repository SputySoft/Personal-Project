using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public float waveDelay;
    public List<ObjectSpawned> objectSpawneds = new List<ObjectSpawned>();
}

[System.Serializable]
public class ObjectSpawned
{
    public GameObject prefabs;
    public int area;
    public float delay;

    public ObjectSpawned (GameObject prefabs, int spwnArea, int spwnDelay)
    {
        this.prefabs = prefabs;
        this.area = spwnArea;
        this.delay = spwnDelay;
    }
}
