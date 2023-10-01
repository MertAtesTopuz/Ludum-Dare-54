using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiVirSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform[] pathPoints;
    public float speed = 5.0f;

    private GameObject spawnedObject;
    private int currentWaypoint = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            SpawnObject();
        }

        if (spawnedObject != null)
        {
            MoveObject();
        }
    }

    void SpawnObject()
    {
        if (objectToSpawn != null && pathPoints.Length > 0)
        {
            spawnedObject = Instantiate(objectToSpawn, pathPoints[0].position, Quaternion.identity);
        }
    }

    void MoveObject()
    {
        if (currentWaypoint < pathPoints.Length)
        {
            Vector3 targetPosition = pathPoints[currentWaypoint].position;
            spawnedObject.transform.position = Vector3.MoveTowards(spawnedObject.transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(spawnedObject.transform.position, targetPosition) < 0.01f)
            {
                currentWaypoint++;
            }
        }
        else
        {
            Destroy(spawnedObject);
            currentWaypoint = 0;
        }
    }
}
