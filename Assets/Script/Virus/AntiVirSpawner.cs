using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiVirSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform SpawnPosition;



    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //SpawnObject();
        }
    }

    public virtual void SpawnObject()
    {
        GameObject newObj = Instantiate(objectPrefab, SpawnPosition.position, Quaternion.identity);
    }
}
