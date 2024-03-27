using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusToPlr : MonoBehaviour
{
    public GameObject player;
    private Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        

        if (player != null)
        {
            playerPos = player.transform;

            Vector3 toPlayer = playerPos.position-transform.position;

            Quaternion targetRotattion = Quaternion.LookRotation(toPlayer);

            transform.rotation = Quaternion.Euler(0f, targetRotattion.eulerAngles.y, 0f);
        }

    }
}
