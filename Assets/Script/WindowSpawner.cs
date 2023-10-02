using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSpawner : MonoBehaviour
{
    public GameObject[] windowPrefabs;
    public float minSpawnInterval = 1.0f; // Minimum spawn interval.
    public float maxSpawnInterval = 3.0f; // Maximum spawn interval.
    public float spawnRange = 5f;
    public int maxWindows = 10;

    public Controller cont;

    public Material windowMaterial;

    public AudioClip spawnSound;

    private float spawnTimer = 0f;
    private float currentSpawnInterval; // Current spawn interval.
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found on this GameObject.");
        }

        // Initialize the current spawn interval.
        currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        // If the spawnTimer exceeds the currentSpawnInterval, spawn a window.
        if (spawnTimer >= currentSpawnInterval && GameObject.FindGameObjectsWithTag("Window").Length < maxWindows)
        {
            SpawnWindow();
            // Generate a new random currentSpawnInterval.
            currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
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

        if (audioSource != null && spawnSound != null)
        {
            audioSource.PlayOneShot(spawnSound);
            Debug.Log("Spawn sound played.");
        }
    }
}
