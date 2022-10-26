using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UI;

public class PlatformScript : MonoBehaviour
{

    public PathScript movementPath;

    public float speed;

    private int pathIndex;

    private Transform previousPoint;
    private Transform nextPoint;

    private float timeBetweenPoints;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        TargetNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        float elapsedPercentage = elapsedTime / timeBetweenPoints;

        elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);

        transform.position = Vector3.Lerp(previousPoint.position, nextPoint.position, elapsedPercentage);

        transform.rotation = Quaternion.Lerp(previousPoint.rotation, nextPoint.rotation, elapsedPercentage);

        if (elapsedPercentage >= 1)
        {
            TargetNextWaypoint();
        }
    }

    private void TargetNextWaypoint()
    {
        previousPoint = movementPath.GetPoint(pathIndex);
        pathIndex = movementPath.GetNextPointIndex(pathIndex);
        nextPoint = movementPath.GetPoint(pathIndex);

        elapsedTime = 0;
        
        float distanceToPoint = Vector3.Distance(previousPoint.position, nextPoint.position);

        timeBetweenPoints = distanceToPoint / speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
