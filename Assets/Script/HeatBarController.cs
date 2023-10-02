using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeatBarController : MonoBehaviour
{
    public Scrollbar heatBar1;
    public Scrollbar heatBar2;
    public TextMeshProUGUI heatText1;
    public TextMeshProUGUI heatText2;

    [SerializeField] private float heatValue1;
    [SerializeField] private float heatTime1;
    [SerializeField] private float heatValue2;
    [SerializeField] private float heatTime2;
    [SerializeField] private float spinSpeed;

    public GameObject fan1;

    private float rotZ;


    void Update()
    {
        HeatBar1();
        HeatBar2();

        rotZ += Time.deltaTime * spinSpeed;

        fan1.transform.rotation = Quaternion.Euler(fan1.transform.rotation.x, fan1.transform.rotation.y , rotZ );
    }

    private void HeatBar1()
    {
        if (heatBar1.value >= 0.95f)
        {
            StartCoroutine(BarChanger1());
        }
        else
        {
            StopCoroutine(BarChanger1());
        }

        if (heatBar1.value >= 0.95)
        {
            heatBar1.value = 1;
        }

        heatValue1 = 30 + heatBar1.value * 100f;

        heatBar1.value += Time.deltaTime / 20;

        heatText1.text = heatValue1.ToString("00") + "C";
    }

    
    IEnumerator BarChanger1()
    {
        yield return new WaitForSeconds(heatTime1);
        GameOver();
    }

    private void HeatBar2()
    {
        if (heatBar2.value >= 0.95f)
        {
            StartCoroutine(BarChanger2());
        }
        else
        {
            StopCoroutine(BarChanger2());
        }

        if (heatBar2.value >= 0.95)
        {
            heatBar2.value = 1;
        }

        heatValue2 = 30 + heatBar2.value * 100f;

        heatBar2.value += Time.deltaTime / 20;

        heatText2.text = heatValue2.ToString("00") + "C";
    }


    IEnumerator BarChanger2()
    {
        yield return new WaitForSeconds(heatTime2);
        GameOver();
    }

    private void GameOver()
    {
        GameEnd.instance.endControl = true;
    }
}
