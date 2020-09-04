using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack1 : MonoBehaviour
{
    static Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            anim.SetBool("isAttacking", true);
            
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
