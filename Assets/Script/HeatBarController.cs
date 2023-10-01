using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeatBarController : MonoBehaviour
{
    public Scrollbar heatBar1;
    public TextMeshProUGUI heatText;

    [SerializeField] private float heatValue;

    [SerializeField] private float heatTime1;

    void Update()
    {
        if (heatBar1.value >= 0.95f)
        {
            StartCoroutine(BarChanger1());
        }
        else
        {
            StopAllCoroutines();
        }

        if (heatBar1.value >= 0.95)
        {
            heatBar1.value = 1;
        }

        heatValue = 30 + heatBar1.value * 100f;

        heatBar1.value += Time.deltaTime / 20;

        heatText.text = heatValue.ToString("00") +"C";
    }

    
    IEnumerator BarChanger1()
    {
        yield return new WaitForSeconds(heatTime1);
        GameOver();
    }

    private void GameOver()
    {
        Debug.Log("gg");
    }
}
