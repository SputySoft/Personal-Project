using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BckgrndMove : MonoBehaviour
{
    public float vSpeed = -5;
    public int zOutRg = -30;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        OutOfRange();

    }

    private void Move()
    {
        transform.Translate(new Vector3(0, 0, 1 * Time.fixedDeltaTime * vSpeed));
    }

    protected virtual void OutOfRange()
    {
        if (gameObject.transform.position.z <= zOutRg)
        {
            gameObject.transform.position = new Vector3(0, 0, 30);
        }
    }
}
