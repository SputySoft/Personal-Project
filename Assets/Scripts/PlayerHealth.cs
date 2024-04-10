using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MainHealth
{
    [SerializeField] private ParticleSystem explosion;

    protected override void Death()
    {
        if (health <= 0)
        {
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.localRotation);
            Destroy(gameObject);
        }
    }
}
