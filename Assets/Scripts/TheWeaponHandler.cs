using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponAim
{
    NONE,
    SELF_AIM,
    AIM
}

public enum WeaponFireType
{
    SINGLE,
    MULTIPLE
}

public enum WeaponBulletType
{
    NONE
}
    

public class TheWeaponHandler : MonoBehaviour
{
    private Animator anim;

    public GameObject attackPoint;

    public WeaponAim weaponAim;

    public WeaponFireType fireType;

    public WeaponBulletType bulletType;

    [SerializeField]
    private AudioSource audioSound;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void ShootAnimation()
    {
        anim.SetTrigger("Shoot");
    }

    void TurnOnAttackPoint()
    {
        attackPoint.SetActive(true);
    }

    void PlayAttackSound()
    {
        audioSound.Play();
    }

    void TurnOffAttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }
}
