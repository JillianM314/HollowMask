using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Idle(bool Idle)
    {
        anim.SetBool("Idle", true);
        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);
    }

    public void Walk(bool Walk) 
    {
        anim.SetBool("Idle", false);
        anim.SetBool("Walk",true);
        anim.SetBool("Run", false);
    }

    public void Run(bool Run)
    {
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Run", true);
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
        anim.SetBool("Idle", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);
    }

    public void Dead()
    {
        anim.SetTrigger("Death");
    }




}
