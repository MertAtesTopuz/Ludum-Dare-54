using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileSpawner : MonoBehaviour
{
    [SerializeField] private float spnTime;
    [SerializeField] private float timeEditor;
    [SerializeField] private float setTimeEditor;

    private int random;

    [SerializeField] private GameObject file;
    [SerializeField] private GameObject window;
    [SerializeField] private GameObject malwareFile;
    [SerializeField] private GameObject systemFile;


    private void Start()
    {
       timeEditor = setTimeEditor;
    }

    private void Update()
    {
        if (timeEditor == setTimeEditor)
        {
            StartCoroutine(FileSpawnTimer());
        }
    }

    private void SpawnSetter()
    {
        

        if (random == 0)
        {
            file = malwareFile;
        }
        else if(random == 1)
        {
            file = systemFile;
        }
    }

    IEnumerator FileSpawnTimer()
    {
        random = Random.Range(0, 2);
        SpawnSetter();
        Debug.Log(random);
        timeEditor -= Time.deltaTime; // time editör slidera eşitlenecek
        
        yield return new WaitForSeconds(spnTime);
        Instantiate(file,window.transform);
        timeEditor = setTimeEditor;
    }
}