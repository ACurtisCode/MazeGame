using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rollForce = 1.5f;
    private float spaceBound = 24.0f;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {

        MovePlayer();
        PlayerConstraints();

    }
    // Moves player based on keyboard input
    void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.transform.Translate(Vector3.forward * rollForce * verticalInput * Time.deltaTime);
        playerRb.transform.Translate(Vector3.right * horizontalInput * rollForce * Time.deltaTime);

    }
    // Movement constraints based on position
    void PlayerConstraints()
    {
        if(transform.position.z > spaceBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, spaceBound);
        }       
        if(transform.position.z < -spaceBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -spaceBound);
        }
        if(transform.position.x > spaceBound)
        {
            transform.position = new Vector3(spaceBound, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -spaceBound)
        {
            transform.position = new Vector3(-spaceBound, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Token"))
        {
            Destroy(other.gameObject);
        }
    }
}
