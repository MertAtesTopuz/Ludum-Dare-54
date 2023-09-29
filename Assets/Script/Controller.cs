using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public int maxRAM = 100;
    private int currRAM;

    private void Start()
    {
        currRAM = maxRAM;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

           // Debug.Log("click");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {

                Debug.Log("Hit");
                if (hit.collider.CompareTag("Window"))
                {
                    Destroy(hit.collider.gameObject);
                    currRAM += 10; 
                }
            }
        }
    }
}
