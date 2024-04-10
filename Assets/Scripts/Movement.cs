using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//abstraction
public class Movement : MonoBehaviour
{
    public int vSpeed = -5;
    public int hSpeed = 0;
    public int xOutRg = 30;
    public int zOutRg = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

       OutOfRange();

    }

    private void Move()
    {
        transform.Translate(new Vector3(1 * Time.deltaTime * hSpeed, 0, 1 * Time.deltaTime * vSpeed));

    }

    protected virtual void OutOfRange()
    {
        if (Mathf.Abs(transform.position.x) > xOutRg || Mathf.Abs(transform.position.z) > zOutRg)
        {
            Destroy(gameObject);
        }
    }
}

