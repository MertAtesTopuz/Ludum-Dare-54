using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Animator uiAnim;

    public float animTimer;

    public GameObject border;
    public GameObject spnPanel;
    public GameObject trash;
    public GameObject menuUI;
    public GameObject pc;

    public void StartBtn()
    {

        border.SetActive(true);
        spnPanel.SetActive(true);
        trash.SetActive(true);
        menuUI.SetActive(false);
        pc.transform.position = new Vector3(-317f, pc.transform.position.y, pc.transform.position.z);
        //StartCoroutine(SetActive());
    }

    IEnumerator SetActive()
    {
        uiAnim.SetBool("isStart", true);
        yield return new WaitForSeconds(animTimer);
        uiAnim.SetBool("isStart", false);
    }
}
