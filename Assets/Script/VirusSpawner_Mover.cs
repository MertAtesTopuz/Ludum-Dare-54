using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner_Mover : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform[] pathPoints;
    public float speed = 5.0f;

    private int currentWaypoint = 0;
    private Transform currentTarget;

    private GameObject spawnedObject;

    void Start()
    {
        SpawnObject();
    }

    void Update()
    {

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
            currentTarget = pathPoints[0];
        }
    }

    void MoveObject()
    {
        spawnedObject.transform.position = Vector3.MoveTowards(spawnedObject.transform.position, currentTarget.position, speed * Time.deltaTime);

        if (Vector3.Distance(spawnedObject.transform.position, currentTarget.position) < 0.01f)
        {
            currentWaypoint++;
            if (currentWaypoint < pathPoints.Length)
            {
                currentTarget = pathPoints[currentWaypoint];
            }
            else
            {
                Destroy(spawnedObject);
            }
        }
    }
}
