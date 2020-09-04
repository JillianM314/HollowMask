using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float damage = 2f;

    public float radius = 1f;

    public LayerMask layermask;

    void Update()
    {
        Collider [] hits = Physics.OverlapSphere(transform.position, radius, layermask);

        if(hits.Length > 0)
        {
            Debug.Log("Touched the :" + hits[0].gameObject.tag);

            gameObject.SetActive(false);
        }
        
    }
}
