using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Object EnemyProjectile;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnProj", 2.0f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnProj ()
    {
        Instantiate(EnemyProjectile, transform.position, transform.rotation);
    }
}
