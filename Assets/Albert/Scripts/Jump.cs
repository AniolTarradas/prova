using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private Animator animator;
    public float rotationspeed = 180;
    private Vector3 rotation;
    private Vector3 last_position = new Vector3 (0f, 0f, 0f);
    

    private void Start()
    {
        
        animator = GetComponent<Animator>();
    }
    IEnumerator waiter()
    {

        animator.SetBool("jump", true);
        yield return new WaitForSeconds(0.8f);
        moveDirection.y = jumpSpeed;
        animator.SetBool("jump", false);
        
    }

    IEnumerator Attack()
    {
        animator.SetBool("punch", true);
        yield return new WaitForSeconds(0.4f);
        animator.SetBool("punch", false);
    }

   

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        if (controller.isGrounded)
        {
            this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * rotationspeed * Time.deltaTime, 0);
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            this.transform.Rotate(this.rotation);
            
            if (Input.GetButton("Jump"))
            {
                StartCoroutine(waiter());

            }
            

        }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        if(last_position != gameObject.transform.position)
        {
            animator.SetBool("walk", true);
            if (Input.GetButton("Fire1"))
            {
                StartCoroutine(Attack());

            }
        }
        else
        {
            animator.SetBool("walk", false);
        }
        last_position = gameObject.transform.position;
        if(Input.GetButton("Fire1"))
        {

            StartCoroutine(Attack());
            
        }
        
    }
    
    private void OnTriggerStay(Collider other)
    {
        IEnumerator Die()
        {
          
            yield return new WaitForSeconds(0.8f);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Enemy" && Input.GetButton("Fire1"))
        {

            StartCoroutine(Die());
        }
    }

}

