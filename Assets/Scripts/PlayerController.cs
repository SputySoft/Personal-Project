using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float xRange = 23;
    public float zRange = 13;
    public float speed = 10;
    public GameObject Projectile;
    public int powerStep = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Controls();
        Mouvements();

    }

    void Mouvements ()
    {
       

        // screen limits

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
    }

    private void Controls ()
    {
        // movements


        float zTrans = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float xTrans = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(xTrans, 0, zTrans );

        // fire action

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireShoot(powerStep);
        }
    }

    void FireShoot (int step) 
    {
        Instantiate(Projectile, transform.position + new Vector3(0, 0, 1), transform.rotation);
    }

}
