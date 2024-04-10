using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMngr : MonoBehaviour
{
    public GameObject objectToPool;
    private int numberOfObjects = 3;
    private int zOffset = 20;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private List<Vector3> initialPositions = new List<Vector3>();

    void Start()
    {
        //  pool creation
        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject objectPooled = Instantiate(objectToPool);
            objectPooled.SetActive(false);
            pooledObjects.Add(objectPooled);

        }

        // Placement initial
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 spawnPosition = gameObject.transform.position + new Vector3(0, 0, i * zOffset);
            pooledObjects[i].transform.position = spawnPosition;
            pooledObjects[i].SetActive(true);
        }
    }
}