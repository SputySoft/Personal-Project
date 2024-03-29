using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SpwnMngr : MonoBehaviour
{

    public GameObject building;
    public List<Wave> waves = new List<Wave>();
    public Dictionary<SpawnArea, (Vector3 position, Quaternion rotation)> spawnLocations;

    void Awake()
    {
        InitializeSpawnLocations();
    }

    void InitializeSpawnLocations()
    {
        spawnLocations = new Dictionary<SpawnArea, (Vector3, Quaternion)>();

        
        spawnLocations[SpawnArea.Top1] = (new Vector3(-20.125f, 1f, 16.5f), Quaternion.Euler(0, 180, 0));
        spawnLocations[SpawnArea.Top2] = (new Vector3(-14.375f, 1f, 16.5f), Quaternion.Euler(0, 180, 0));
        spawnLocations[SpawnArea.Top3] = (new Vector3(-8.625f, 1f, 16.5f), Quaternion.Euler(0, 180, 0));
        spawnLocations[SpawnArea.Top4] = (new Vector3(-2.875f, 1f, 16.5f), Quaternion.Euler(0, 180, 0));
        spawnLocations[SpawnArea.Top5] = (new Vector3(2.875f, 1f, 16.5f), Quaternion.Euler(0, 180, 0));
        spawnLocations[SpawnArea.Top6] = (new Vector3(8.625f, 1f, 16.5f), Quaternion.Euler(0, 180, 0));
        spawnLocations[SpawnArea.Top7] = (new Vector3(14.375f, 1f, 16.5f), Quaternion.Euler(0, 180, 0));
        spawnLocations[SpawnArea.Top8] = (new Vector3(20.125f, 1f, 16.5f), Quaternion.Euler(0, 180, 0));

        spawnLocations[SpawnArea.Down1] = (new Vector3(-20.125f, 1f, -16.5f), Quaternion.Euler(0, 0, 0));
        spawnLocations[SpawnArea.Down2] = (new Vector3(-14.375f, 1f, -16.5f), Quaternion.Euler(0, 0, 0));
        spawnLocations[SpawnArea.Down3] = (new Vector3(-8.625f, 1f, -16.5f), Quaternion.Euler(0, 0, 0));
        spawnLocations[SpawnArea.Down4] = (new Vector3(-2.875f, 1f, -16.5f), Quaternion.Euler(0, 0, 0));
        spawnLocations[SpawnArea.Down5] = (new Vector3(2.875f, 1f, -16.5f), Quaternion.Euler(0, 0, 0));
        spawnLocations[SpawnArea.Down6] = (new Vector3(8.625f, 1f, -16.5f), Quaternion.Euler(0, 0, 0));
        spawnLocations[SpawnArea.Down7] = (new Vector3(14.375f, 1f, -16.5f), Quaternion.Euler(0, 0, 0));
        spawnLocations[SpawnArea.Down8] = (new Vector3(20.125f, 1f, -16.5f), Quaternion.Euler(0, 0, 0));

        spawnLocations[SpawnArea.Right1] = (new Vector3(26.5f, 1f, 9.75f), Quaternion.Euler(0, 180, 0));
        spawnLocations[SpawnArea.Right2] = (new Vector3(26.5f, 1f, 3.25f), Quaternion.Euler(0, 180, 0));
        spawnLocations[SpawnArea.Right3] = (new Vector3(26.5f, 1f, -3.25f), Quaternion.Euler(0, 180, 0));
        spawnLocations[SpawnArea.Right4] = (new Vector3(26.5f, 1f, -9.75f), Quaternion.Euler(0, 180, 0));

        spawnLocations[SpawnArea.Right1] = (new Vector3(-26.5f, 1f, 9.75f), Quaternion.Euler(0, 0, 0));
        spawnLocations[SpawnArea.Right2] = (new Vector3(-26.5f, 1f, 3.25f), Quaternion.Euler(0, 0, 0));
        spawnLocations[SpawnArea.Right3] = (new Vector3(-26.5f, 1f, -3.25f), Quaternion.Euler(0, 0, 0));
        spawnLocations[SpawnArea.Right4] = (new Vector3(-26.5f, 1f, -9.75f), Quaternion.Euler(0, 0, 0));
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnBuildings", 0, 1);
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawnBuildings()//has to be move to pooling method
    {



        Vector3 position = new Vector3(Random.Range(-22f, 22f), 5f, 16.5f + Random.Range(-2.5f, 2.5f));
        Instantiate(building, position, building.transform.rotation);
        Debug.Log("Building Spawned");
    }

    IEnumerator SpawnWaves()
    {
        foreach (Wave wave in waves)
        {
            yield return new WaitForSeconds(wave.waveDelay);

            foreach (ObjectSpawned objToSpawn in wave.objectSpawneds)
            {
                yield return new WaitForSeconds(objToSpawn.delay);

                var spawnData = spawnLocations[objToSpawn.area];

                Instantiate(objToSpawn.prefabs, spawnData.position, spawnData.rotation);

                Debug.Log("Spawned Something from wave" + wave);


            }

        }
    }
}
