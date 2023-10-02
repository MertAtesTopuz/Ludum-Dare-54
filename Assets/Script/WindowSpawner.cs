using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSpawner : MonoBehaviour
{
    public GameObject[] windowPrefabs;
    public float spawnInterval = 2f;
    public float spawnRange = 5f;
    public int maxWindows = 10;

    public Controller cont;

    public Material windowMaterial;

    private float spawnTimer = 0f;

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval && GameObject.FindGameObjectsWithTag("Window").Length < maxWindows)
        {
            SpawnWindow();
            spawnTimer = 0f;
        }
    }

    private void SpawnWindow()
    {
        if (windowPrefabs.Length == 0)
        {
            Debug.LogError("No window prefabs assigned.");
            return;
        }

        Vector3 spawnPosition = new Vector3(
            Random.Range(0, 8),
            Random.Range(-5, 0),
            0f
        );

        GameObject randomWindowPrefab = windowPrefabs[Random.Range(0, windowPrefabs.Length)];

        GameObject newWindow = Instantiate(randomWindowPrefab, spawnPosition, Quaternion.identity);

        cont.currRAM += 10;

        newWindow.tag = "Window";

        

    }
}
