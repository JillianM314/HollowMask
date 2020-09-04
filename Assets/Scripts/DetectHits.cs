using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHits : MonoBehaviour
{
    public float enemyHealth;


    private void Awake()
    {
        enemyHealth = 20f;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit!");

        enemyHealth -= 5f;

        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
