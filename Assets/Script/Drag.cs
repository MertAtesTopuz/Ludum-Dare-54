using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Drag : MonoBehaviour
{
    Vector2 difference = Vector2.zero;
    public bool onDrag;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("up");
            onDrag = false;
        }
    }

    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        Debug.Log("draggable");
        onDrag = true;
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }


    public void OnCollisionStay2D(Collision2D collision)
    {

        Debug.Log("collide");

        if (!onDrag)
        {
            if (collision.collider.tag == "trsh")
            {
                Debug.Log("col");

                Destroy(gameObject);
            }
        }


    }


}
