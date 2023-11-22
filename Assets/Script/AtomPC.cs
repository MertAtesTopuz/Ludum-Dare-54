using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomPC : MonoBehaviour
{


    public AudioClip VirusSound;
    public AudioClip AntiVirusSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Virus")
        {
            Destroy(collision.gameObject);
            if (audioSource != null && VirusSound != null)
            {
                audioSource.PlayOneShot(VirusSound);
                Debug.Log("ses");
            }
        }

        if (collision.collider.tag == "antiVir")
        {
            Destroy(collision.gameObject);
            if (audioSource != null && AntiVirusSound != null)
            {
                audioSource.PlayOneShot(AntiVirusSound);
                Debug.Log("ses");
            }
        }
    }
}
