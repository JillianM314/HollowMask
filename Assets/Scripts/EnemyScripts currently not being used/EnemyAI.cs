using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent navAgent;

    [SerializeField] float chaseRange = 5f;
    float distanceToTarget = Mathf.Infinity;

    private bool isProvoked = false;

    Animator anim;

    [SerializeField] float turnSpeed;


    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        
        if(isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

   private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void ChaseTarget()
    {
        navAgent.isStopped = false;
        anim.SetBool("isAttacking", false);
        anim.SetBool("isWalking", true);
        navAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        navAgent.isStopped = true;
        anim.SetBool("isAttacking", true);
        anim.SetBool("isWalking", false);
        anim.SetBool("isIdle", false);
        //Debug.Log("Attacked Target!");
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed); //current rotation, look rotation , time or speed
    }
}
