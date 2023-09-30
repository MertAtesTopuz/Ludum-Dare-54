using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    //public int maxRAM = 100;
    public Slider RamSlider;
    public int currRAM;

    private void Start()
    {
        currRAM = 0;
    }

    private void Update()
    {

        RamSlider .value = currRAM;
        if (Input.GetMouseButtonDown(0))
        {

            Debug.Log("click");
            Debug.Log(currRAM);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {

                Debug.Log("Hit");
                if (hit.collider.CompareTag("Window"))
                {
                    Destroy(hit.collider.gameObject);
                    currRAM -= 10; 
                }
            }
        }
    }
}
