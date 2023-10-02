using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FileSpawner : MonoBehaviour
{
    [SerializeField] private float spnTime;
    private float timeEditor;
    [SerializeField] private float setTimeEditor;

    [SerializeField] private Slider spawnSlider;
    public Slider hddSlider;

    [SerializeField] private TextMeshProUGUI systemDelCounter;

    private int random;

    [SerializeField] private GameObject file;
    [SerializeField] private GameObject window;
    [SerializeField] private GameObject malwareFile;
    [SerializeField] private GameObject systemFile;
    [SerializeField] private GameObject system32;

    public int malwareCount;
    public int systemDeadCount;

    public bool isDelSystem32;

    public bool FileControlBool;

    private void Start()
    {
       timeEditor = setTimeEditor;
        hddSlider.value = 0;
    }

    private void Update()
    {
        if (FileControlBool == false)
        {
            if (timeEditor == setTimeEditor)
            {
                StartCoroutine(FileSpawnTimer());
            }

            if (hddSlider.value == 1 || systemDeadCount >= 10 || isDelSystem32 == true)
            {
                GameOver();
            }

            spawnSlider.value -= Time.deltaTime / 3;

            systemDelCounter.text = systemDeadCount.ToString();
        }
    }

    private void SpawnSetter()
    {
        if (random == 0 || random == 1 || random == 2)
        {
            file = malwareFile;
            malwareCount += 1;
        }
        else if(random == 3 || random == 4 || random == 5)
        {
            file = systemFile;
        }
        else if (random == 6)
        {
            file = system32;
        }
    }

    private void HddSetter()
    {
        if (file == malwareFile)
        {
            hddSlider.value += 0.1f;
        }
    }

    private void GameOver()
    {
        GameEnd.instance.endControl = true;
        Debug.Log("gg"); //sonradan değiştirilecek
    }

    IEnumerator FileSpawnTimer()
    {
        random = Random.Range(0, 7);
        SpawnSetter();
        Debug.Log(random); //sonradan silinecek
        timeEditor -= Time.deltaTime;
        yield return new WaitForSeconds(spnTime);
        HddSetter();
        Instantiate(file,window.transform);
        timeEditor = setTimeEditor;
        spawnSlider.value = 1;
    }
}