using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMove : BckgrndMove
{

    // Start is called before the first frame update
    protected override void OutOfRange()
    {
        if (gameObject.transform.position.z <= zOutRg)
        {
            Destroy(gameObject);
        }
    }
}
