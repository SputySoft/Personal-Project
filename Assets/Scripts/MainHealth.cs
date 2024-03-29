using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHealth : MonoBehaviour
{
    public int health = 1;
    public float damageSpeed = 0.5f;
    public List<string> DamagerList;
    public bool temporary = false;
    public int lifeTime = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        if (temporary) 
        { 
            StartCoroutine(DeathCountdown());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (DamagerList.Contains(collision.gameObject.tag))
        {
            health--;
        }
    }

    IEnumerator DeathCountdown()
    {
        int currentTime = lifeTime;

        while (currentTime > 0)
        {
            Debug.Log("Time remaining: " + currentTime + " seconds");
            yield return new WaitForSeconds(1f);
            currentTime--;
        }

        yield return health=0;

    }

}
