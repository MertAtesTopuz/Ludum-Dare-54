using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    //public int maxRAM = 100;
    public Slider RamSlider;
    public int currRAM;

    public AudioClip spawnSound;
    public AudioClip Xerror;

    private AudioSource audioSource;

    public AtomVirus AtomVirus;
    public GameObject VirusMiniGameWindowPopUp;
    public GameObject VirusMiniGameWindow;
    public GameObject PC;

    private void Start()
    {
        currRAM = 0;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {

        RamSlider.value = currRAM;
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
                    if (audioSource != null && spawnSound != null)
                    {
                        audioSource.PlayOneShot(spawnSound);
                        Debug.Log("ses");
                    }
                }

                if (hit.collider.CompareTag("VirusMiniGame"))
                {
                    AtomVirus.isSpawn = true;
                    VirusMiniGameWindowPopUp.SetActive(false);
                    VirusMiniGameWindow.SetActive(true);
                    PC.SetActive(true);
                }
                if (hit.collider.CompareTag("X"))
                {


                    if (audioSource != null && Xerror != null)
                    {
                        audioSource.PlayOneShot(Xerror);
                        Debug.Log("ses");
                    }
                }

            }
        }

        if (!AtomVirus.isSpawn)
        {
            VirusMiniGameWindow.SetActive(false);
            //VirusMiniGameWindowPopUp.SetActive(false);
            PC.SetActive(false);
        }
    }
}
