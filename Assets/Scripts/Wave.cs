using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public float waveDelay;
    public List<ObjectSpawned> objectSpawneds = new List<ObjectSpawned>();
}

public enum SpawnArea
{
    Top1,
    Top2,
    Top3,
    Top4,
    Top5,
    Top6,
    Top7,
    Top8,
    Right1,
    Right2,
    Right3,
    Right4,
    Left1,
    Left2,
    Left3,
    Left4,
    Down1,
    Down2,
    Down3,
    Down4,
    Down5,
    Down6,
    Down7,
    Down8

}

[System.Serializable]
public class ObjectSpawned
{
    public GameObject prefabs;
    public SpawnArea area;
    public float delay;

    public ObjectSpawned (GameObject prefabs, SpawnArea spwnArea, int spwnDelay)
    {
        this.prefabs = prefabs;
        this.area = spwnArea;
        this.delay = spwnDelay;
    }
}
