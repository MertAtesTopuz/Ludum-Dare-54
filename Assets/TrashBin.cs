using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public FileSpawner manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<FileSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SystemFile")
        {
            manager.systemDeadCount += 1;
            Destroy(other.gameObject);
        }

        if (other.tag == "MalwareFile")
        {
            manager.malwareCount -= 1;
            manager.hddSlider.value -= 0.1f;
            Destroy(other.gameObject);
        }

        if (other.tag == "System32")
        {
            Destroy(other.gameObject);
            manager.isDelSystem32 = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "SystemFile")
        {
            manager.systemDeadCount += 1;
            Destroy(other.gameObject);
        }

        if (other.tag == "MalwareFile")
        {
            manager.malwareCount -= 1;
            Destroy(other.gameObject);
        }

        if (other.tag == "System32")
        {
            Destroy(other.gameObject);
            manager.isDelSystem32 = true;
        }
    }
}
