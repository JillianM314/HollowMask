using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWeaponManager : MonoBehaviour
{
    [SerializeField]
    private TheWeaponHandler[] weapons;

    private int currentWeaponIndex;


    // Start is called before the first frame update
    void Start()
    {
        currentWeaponIndex = 0;
        weapons[currentWeaponIndex].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TurnOnSelectedWeapon(0);
        }
    }

    void TurnOnSelectedWeapon(int weaponIndex)
    {
        if (currentWeaponIndex == weaponIndex)
            return;

        weapons[currentWeaponIndex].gameObject.SetActive(false);

        weapons[weaponIndex].gameObject.SetActive(true);

        currentWeaponIndex = weaponIndex;
    }

    public TheWeaponHandler GetCurrentSelectedWeapon()
    {
        return weapons[currentWeaponIndex];
    }
}
