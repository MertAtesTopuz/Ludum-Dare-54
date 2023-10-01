using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    [SerializeField]private float mana = 50;
    [SerializeField]private bool isDecreasing = true;
    public Slider manaSlider;

    public Button manaIncreaseButton;
    [SerializeField]private AntiVirSpawner AntiVirSpawner;

    void Start()
    {
       manaSlider.value = mana;

        manaIncreaseButton.onClick.AddListener(IncreaseMana);
        manaIncreaseButton.onClick.AddListener(ToggleManaDecrease);
    }

    void Update()
    {

        manaSlider.value = mana;

        if (mana >= 103)
        {
            mana = 100;
        }

        if (mana >= 98)
        {
            AntiVirSpawner.SpawnObject();
            mana = 0;
        }

        if (Input.GetMouseButton(0))
        {
            isDecreasing = false;
        }
        else
        {
            isDecreasing = true;    
        }

        if (isDecreasing && mana > 0)
        {

            Debug.Log(mana);
            mana -= 10*Time.deltaTime;
        }
    }

    public void IncreaseMana()
    {
        Debug.Log("click");
        mana += 10;
    }

    public void ToggleManaDecrease()
    {
        isDecreasing = !isDecreasing;
    }

}
