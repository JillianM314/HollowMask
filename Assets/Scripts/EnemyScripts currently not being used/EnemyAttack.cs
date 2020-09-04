using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;

    [SerializeField] float damage = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void OnDamageTaken()
    {
        Debug.Log("I took damage");
    }

    public void AttackHitEvent()
    {
        if (target == null)
        {
            return;
        }
        target.GetComponent<PlayerHealth>().TakeDamage(damage);
        Debug.Log("Hit Player");
    }
}
