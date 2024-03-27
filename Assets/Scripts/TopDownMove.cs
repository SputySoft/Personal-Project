using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMove : MonoBehaviour
{
    public float vSpeed = -5;
    public float hSpeed = 0;
    public float xOutRg = 30;
    public float zOutRg = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1*Time.deltaTime*hSpeed, 0,1*Time.deltaTime*vSpeed));

        if(Mathf.Abs(transform.position.x) > xOutRg || Mathf.Abs(transform.position.z) > zOutRg)
        {
            Destroy(gameObject);
        }

    }
}
