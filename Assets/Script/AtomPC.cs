using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomPC : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Virus")
        {
            Destroy(collision.gameObject);  
        }
    }
}
