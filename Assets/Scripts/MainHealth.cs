using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    public int health
    {
        get { return _health; }
        private set { _health = value; }
    }
    [SerializeField] private float damageSpeed = 0.5f;
    [SerializeField] private List<string> DamagerList;
    [SerializeField] private bool temporary = false;
    [SerializeField] private int lifeTime = 20;
    
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
     
    }

    private void OnCollisionStay(Collision collision)
    {
        if (DamagerList.Contains(collision.gameObject.tag))
        {
            health--;
            Death();
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

    protected virtual void Death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
