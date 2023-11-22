using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerTxt;
    public TextMeshProUGUI endTxt;
    [SerializeField] private float timeCounter;

    void Update()
    {
        timeCounter += Time.deltaTime;

        timerTxt.text = timeCounter.ToString("00");
        endTxt.text = "Your Score : " + timeCounter.ToString("00");
    }
}
