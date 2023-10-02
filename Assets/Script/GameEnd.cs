using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public GameObject endPnl;
    public bool endControl = false;

    public static GameEnd instance;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (endControl == true)
        {
            endPnl.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void RetryBtn()
    {
        endControl = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
