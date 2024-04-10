using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMovement : Movement
{
    protected override void OutOfRange() 
    {

        if (Mathf.Abs(transform.position.x) > xOutRg || Mathf.Abs(transform.position.z) > zOutRg)
        {

            gameObject.SetActive(false);
        }
    }
}
