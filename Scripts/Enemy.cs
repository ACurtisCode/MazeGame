using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    public float detectionRadius = 10.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    private float playerDistance;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = (player.transform.position - transform.position).magnitude;
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        if(playerDistance < detectionRadius)
        {
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime, ForceMode.Impulse);
        }

    }
}
