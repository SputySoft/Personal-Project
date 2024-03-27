using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SpwnMngr : MonoBehaviour
{

    public GameObject building;
    public List<Wave> waves = new List<Wave>();

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

    void spawnBuildings()
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

                (Vector3 position, Quaternion rotation) = SpwnPosition(objToSpawn.area);

                Instantiate(objToSpawn.prefabs, position, rotation);

                Debug.Log("Spawned Something from wave" + wave);


            }

        }
    }

    (Vector3, Quaternion) SpwnPosition(int area)
    {
        Vector3 position;
        Quaternion rotation;

        switch (area)
        {
            case 0:
                
                position = new Vector3(Random.Range(-22f, 22f), 1f, 16.5f + Random.Range(-2.5f, 2.5f));
                rotation = Quaternion.Euler(0, 180, 0);
                break;
            case 1:
                
                position = new Vector3(Random.Range(-22f, 22f), 1f, -16.5f + Random.Range(-2.5f, 2.5f));
                rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2:
                
                position = new Vector3(26.5f + Random.Range(-2.5f, 2.5f), 1f, Random.Range(-12f, 12f));
                rotation = Quaternion.Euler(0, 180, 0);
                break;
            case 3:
                
                position = new Vector3(-26.5f + Random.Range(-2.5f, 2.5f), 1f, Random.Range(-12f, 12f));
                rotation = Quaternion.Euler(0, 0, 0);
                break;
            default:
                
                position = new Vector3(0, 1f, 0);
                rotation = Quaternion.identity; 
                break;
        }

        return (position, rotation);
    }

}
