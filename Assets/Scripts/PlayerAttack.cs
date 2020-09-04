using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private TheWeaponManager weaponManager;

    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;


    private void Awake()
    {
        weaponManager = GetComponent<TheWeaponManager>();
    }

    private void Update()
    {
        WeaponShoot();
    }

    void WeaponShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (weaponManager.GetCurrentSelectedWeapon().tag == "Axe" )
            {
                weaponManager.GetCurrentSelectedWeapon().ShootAnimation();
            }
        }
    }
}
