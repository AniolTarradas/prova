using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour
{
    private Rigidbody rb;
    private float HEIGHT_GROUND = 0;

    private Vector3 initialPosition;

    public Rigidbody player; 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position.y <= HEIGHT_GROUND)
        {
            transform.position = initialPosition;
            rb.isKinematic = true;

            //player.AddForce(0f, 2, -2, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb.isKinematic = false;
        }
    }
}
