using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBallScript : MonoBehaviour
{
    private Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }
    void Update()
    {
        if (transform.position.y <= -10)
        {
            transform.position = initialPosition;
        }
    }
}
