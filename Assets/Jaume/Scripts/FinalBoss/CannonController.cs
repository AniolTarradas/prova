using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject bomb;

    public float force_x = 10;
    public float force_y = 0;
    public float force_z = 10;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Shot cannon");
            bomb.GetComponent<Rigidbody>().AddForce(force_x, force_y, force_z, ForceMode.Acceleration);
            
        }
    }
}


