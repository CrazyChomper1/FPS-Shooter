using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] weapons;
    public GameObject currentWeapon;
    private int currWeapon;

    void Start()
    {
        selectWeapon();
    }

    public void selectWeapon()
    {
        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
        weapons[currWeapon].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currWeapon = 2;
        }

        selectWeapon();

    }
}