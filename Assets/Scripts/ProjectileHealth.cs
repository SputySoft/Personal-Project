using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHealth : MainHealth
{
    // Start is called before the first frame update

    protected override void Death()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
