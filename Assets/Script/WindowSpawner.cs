using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSpawner : MonoBehaviour
{
    public GameObject[] windowPrefabs;
    public float minSpawnInterval = 1.0f;
    public float maxSpawnInterval = 3.0f;
    public float spawnRange = 5f;
    public int maxWindows = 10;

    public Controller cont;

    public Material windowMaterial;

    public AudioClip spawnSound;

    private float spawnTimer = 0f;
    private float currentSpawnInterval;
    private AudioSource audioSource;

    [SerializeField] private float OnOfTimer = 0f;

    public bool isSpawn;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found on this GameObject.");
        }

        currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void Update()
    {
        OnOfTimer += Time.deltaTime;
        if (OnOfTimer >= 13)
        {
            isSpawn = !isSpawn;
            OnOfTimer = 0f;
        }




        if (!isSpawn)
            return;
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= currentSpawnInterval && GameObject.FindGameObjectsWithTag("Window").Length < maxWindows)
        {
            SpawnWindow();

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
            Random.Range(-6.5f, 0.5f),
            Random.Range(-3.6f, 1.8f),
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
