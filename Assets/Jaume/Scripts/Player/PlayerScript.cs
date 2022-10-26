using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 initialPosition;
    private bool isGrounded = true;

    public float speed = 2f;
    public float jumpForce = 2f;

    private int counter = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Moviment
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);

        if (moveDirection.magnitude >= 0.1f)
        {
            transform.Translate(moveDirection * Time.deltaTime * speed);
        }

        // Salt
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);

        }
    }

    // Fora del terra
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }
    // Toca el terra
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cookie")
        {
            Destroy(other.gameObject);
            counter++;
            Debug.Log(counter);
        }
    }
}
