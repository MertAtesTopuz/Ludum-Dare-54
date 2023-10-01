using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusMovment : MonoBehaviour
{
    public Transform[] waypoints; 
    public float speed = 2.0f; 
    private int currentWaypoint = 0;

    void Update()
    {
        if (currentWaypoint < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[currentWaypoint].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            float distanceToWaypoint = Vector3.Distance(transform.position, targetPosition);
            if (distanceToWaypoint < 0.1f)
            {
                currentWaypoint++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
