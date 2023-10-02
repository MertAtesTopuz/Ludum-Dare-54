using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtAntiVirus : MonoBehaviour
{
    public GameObject objectPrefab;
    public float spawnInterval = 2.0f;
    public float spawnSpeed = 2.0f;
    public int maxObjects = 10;
    public float gameDuration = 60.0f;

    private float timer = 0.0f;
    private Camera mainCamera;

    public float spawnBoxMinX = -10f;
    public float spawnBoxMaxX = 10f;
    public float spawnBoxMinY = -6f;
    public float spawnBoxMaxY = 6f;

    public AudioClip spawnSound;
    public AudioClip deadSound;

    private AudioSource audioSource;

    public bool isSpawn;
    public AtomVirus AtomVirus;

    public FileSpawner file;

    //private bool isAnimating = false;

    void Start()
    {
        mainCamera = Camera.main;
        //currentSpawnInterval = spawnInterval;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        isSpawn = AtomVirus.isSpawn;
        if (!isSpawn)
            return;
        timer += Time.deltaTime;

        spawnInterval -= Time.deltaTime / 40;
        if (spawnInterval <= 0.6f)
        {
            spawnInterval = 0.6f;
        }


        if (timer >= spawnInterval && GameObject.FindGameObjectsWithTag("antiVir").Length < maxObjects)
        {
            SpawnObject();
            timer = 0.0f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }

        gameDuration -= Time.deltaTime;

        if (gameDuration <= 0)
        {
            EndGame();
        }
    }

    void SpawnObject()
    {
        float spawnX, spawnY;

        if (Random.value < 0.5f)
        {
            spawnX = Random.Range(spawnBoxMinX, spawnBoxMaxX);
            spawnY = Random.value < 0.5f ? spawnBoxMaxY + 1 : spawnBoxMinY - 1;
        }
        else
        {
            spawnX = Random.value < 0.5f ? spawnBoxMaxX + 1 : spawnBoxMinX - 1;
            spawnY = Random.Range(spawnBoxMinY, spawnBoxMaxY);
        }

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

        GameObject newObj = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        newObj.GetComponent<Rigidbody2D>().velocity = (Vector3.zero - spawnPosition).normalized * spawnSpeed;
        newObj.tag = "antiVir";

        if (audioSource != null && spawnSound != null)
        {
            audioSource.PlayOneShot(spawnSound);
            Debug.Log("ses");
        }
    }

    void HandleMouseClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && hit.collider.CompareTag("antiVir"))
        {
            Animator anim = hit.collider.gameObject.GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetTrigger("Destroy");
                //isAnimating = true;

                Destroy(hit.collider.gameObject, 0.1f);

                file.systemDeadCount += 1;

                if (audioSource != null && deadSound != null)
                {
                    audioSource.PlayOneShot(deadSound);
                    Debug.Log("ses");
                }
            }
        }
    }

    void EndGame()
    {
        Debug.Log("Game Over!");
    }
}
