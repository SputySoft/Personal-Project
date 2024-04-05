using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SpwnMngr : MonoBehaviour
{

    public GameObject building;
    public List<Wave> waves = new List<Wave>();
    public Dictionary<SpawnArea, (Vector3 position, Quaternion rotation)> spawnLocations;
    public bool spawningBuilding;//not used
    [SerializeField] private float yPosition=10.0f;
    

    void Awake()
    {
        InitializeSpawnLocations();
    }
    //coordinates of the areas
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

        spawnLocations[SpawnArea.Left1] = (new Vector3(-26.5f, 1f, 9.75f), Quaternion.Euler(0, 0, 0));
        spawnLocations[SpawnArea.Left2] = (new Vector3(-26.5f, 1f, 3.25f), Quaternion.Euler(0, 0, 0));
        spawnLocations[SpawnArea.Left3] = (new Vector3(-26.5f, 1f, -3.25f), Quaternion.Euler(0, 0, 0));
        spawnLocations[SpawnArea.Left4] = (new Vector3(-26.5f, 1f, -9.75f), Quaternion.Euler(0, 0, 0));
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

        (Vector3 position, Quaternion rotation) = BuildingPosition();


        Instantiate(building, position, rotation);
        Debug.Log("Building Spawned");
    }
    // coroutine to spawn the waves of enemies
    IEnumerator SpawnWaves()
    {
        foreach (Wave wave in waves)
        {
            yield return new WaitForSeconds(wave.waveDelay);

            foreach (ObjectSpawned objToSpawn in wave.objectSpawneds)
            {
                yield return new WaitForSeconds(objToSpawn.delay);

                var spawnData = spawnLocations[objToSpawn.area];

                Instantiate(objToSpawn.prefabs, spawnData.position + new Vector3 (0.0f, yPosition, 0.0f) , spawnData.rotation);

                Debug.Log("Spawned Something from wave" + wave);


            }

        }
    }
    // give the coordinate of buildings before spawn
    (Vector3, Quaternion) BuildingPosition()
    {
        Vector3 position = Vector3.zero; 
        Quaternion rotation = Quaternion.identity;
        int area = Random.Range(0,8);
        SpawnArea key;

        switch (area)
        {
            case 0:
                key = SpawnArea.Top1;
                break;

            case 1:
                key = SpawnArea.Top2;
                break;
            case 2:
                key = SpawnArea.Top3;
                break;
            case 3:
                key = SpawnArea.Top4;
                break;
            case 4:
                key = SpawnArea.Top5;
                break;
            case 5:
                key = SpawnArea.Top6;
                break;
            case 6:
                key = SpawnArea.Top7;
                break;
            case 7:
                key = SpawnArea.Top8;
                break;

            default:
                key = SpawnArea.Top1;
                break;
        }

        if (spawnLocations.TryGetValue(key, out (Vector3 position, Quaternion rotation) spawnData))
        {
         
            position = spawnData.position;
            rotation = spawnData.rotation;
         
            Debug.Log($"Position: {position}, Rotation: {rotation}");

            
        }
        else
        {
            Debug.LogError($"key {key} not found.");
        }

        return (position, rotation);
    }

}
