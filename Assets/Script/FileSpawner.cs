using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileSpawner : MonoBehaviour
{
    [SerializeField] private float spnTime;
    [SerializeField] private float timeEditor;
    [SerializeField] private float setTimeEditor;

    [SerializeField] private GameObject file;
    [SerializeField] private GameObject window;

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

    IEnumerator FileSpawnTimer()
    {
        timeEditor -= Time.deltaTime; // time editör slidera eşitlenecek
        yield return new WaitForSeconds(spnTime);
        Instantiate(file,window.transform);
        timeEditor = setTimeEditor;
    }
}
/*

 timeEditor -= Time.deltaTime;// time editör slidera eşitlenecek

       if (timeEditor == setTimeEditor - 0.1f)
       {
           Instantiate(file, window.transform);
       }
       if (timeEditor <= 0)
       {
           timeEditor = setTimeEditor;
       }
*/