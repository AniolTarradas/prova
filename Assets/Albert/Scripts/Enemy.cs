using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
   
    public GameObject pe_explosion;
    public GameObject pe_wham;
   
    // Start is called before the first frame update
    void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" && Input.GetButton("Fire1"))
        {
            Instantiate(pe_explosion , transform.position + new Vector3(0, 1, 0), transform.rotation);
            Instantiate(pe_wham , transform.position + new Vector3(0, 2, 0), transform.rotation);
           
        }
    }
}
