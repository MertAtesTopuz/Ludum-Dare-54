using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public float minSpawnInterval = 2.0f;
    public float maxSpawnInterval = 4.0f;
    public Transform SpawnPosition;

    private float timer = 0.0f;
    private float currentSpawnInterval;

    void Start()
    {
        currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= currentSpawnInterval)
        {
            SpawnObject();
            timer = 0.0f;

            currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

    void SpawnObject()
    {
        GameObject newObj = Instantiate(objectPrefab, SpawnPosition.position, Quaternion.identity);
    }
}
