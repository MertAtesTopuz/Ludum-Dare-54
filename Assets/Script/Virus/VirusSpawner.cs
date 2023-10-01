using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public float spawnInterval = 2.0f; 
    public Transform SpawnPosition;

    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0.0f; 
        }
    }

    void SpawnObject()
    {
        // Instantiate a new object at the spawner's position.
        GameObject newObj = Instantiate(objectPrefab, SpawnPosition.position, Quaternion.identity);
    }
}
