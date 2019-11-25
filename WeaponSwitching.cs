using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    int j = 0;
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        selectedWeapon = j;
        

        //if (selectedWeapon >= transform.childCount - 1)
        //    selectedWeapon = 0;
        //else
        //    selectedWeapon--;
        //if (selectedWeapon <= 0)
        //    selectedWeapon = transform.childCount - 1;
        //else
        //    selectedWeapon--;

        if (previousSelectedWeapon != selectedWeapon)
            SelectWeapon();

    }
    void SelectWeapon()
    {

        int i = 0;

        foreach (Transform weapon in transform)
        {

            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
            
        }
    }
    public void Selected()
    {
        j++;
        if (j > 1)
            j = 0;
    }
}
