using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSpawner : MonoBehaviour
{
    public GameObject windowPrefab;
    public float spawnInterval = 2f; 
    public float spawnRange = 5f;    
    public int maxWindows = 10;

    public Controller cont;

    private float spawnTimer = 0f;

    private void Update()
    {
        Debug.Log(cont.currRAM);
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval && GameObject.FindGameObjectsWithTag("Window").Length < maxWindows)
        {
            SpawnWindow();
            spawnTimer = 0f;
        }
    }

    private void SpawnWindow()
    {
        
        Vector3 spawnPosition = new Vector3(
            Random.Range(0, 8),
            Random.Range(-5, 0),
            0f
        );

        
        GameObject newWindow = Instantiate(windowPrefab, spawnPosition, Quaternion.identity);

        cont.currRAM += 10;

        newWindow.tag = "Window";
    }
}
