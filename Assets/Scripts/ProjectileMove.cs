using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : TopDownMove
{
    protected override void DestroyOutOfRange() 
    {

        if (Mathf.Abs(transform.position.x) > xOutRg || Mathf.Abs(transform.position.z) > zOutRg)
        {

            gameObject.SetActive(false);
        }
    }
}
