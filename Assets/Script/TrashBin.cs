using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    public FileSpawner manager;
    public AudioSource source;
    public AudioClip trash;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<FileSpawner>();
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SystemFile")
        {
            manager.systemDeadCount += 1;
            Destroy(other.gameObject);
            source.PlayOneShot(trash);
        }

        if (other.tag == "MalwareFile")
        {
            manager.malwareCount -= 1;
            manager.hddSlider.value -= 0.1f;
            Destroy(other.gameObject);
            source.PlayOneShot(trash);
        }

        if (other.tag == "System32")
        {
            Destroy(other.gameObject);
            manager.isDelSystem32 = true;
            source.PlayOneShot(trash);
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

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "SystemFile")
        {
            // animasyon eklenecek
        }

        if (other.tag == "MalwareFile")
        {
            // animasyon eklenecek
        }

        if (other.tag == "System32")
        {
            // animasyon eklenecek
        }
    }
}
