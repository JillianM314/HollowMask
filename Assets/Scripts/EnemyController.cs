using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    PATROL,
    CHASE,
    ATTACK,
    DEATH
}

public class EnemyController : MonoBehaviour
{
    private EnemyAnimation enemyAnim;
    private NavMeshAgent navAgent;

    private EnemyState enemyState;

    public float walkSpeed = 1f;
    public float runSpeed = 3f;

    public float chaseDistance = 8f;
    public float currentChaseDistance;

    public float attackDistance = 1.8f;
    public float chaseAfterAttackDistance;

    public float patrolRadiusMin = 10f, patrolRadiusMax = 30f;
    public float patrolForThisTime = 15f;
    private float patrolTimer;

    public float waitBeforeAttack = 1f;
    private float attackTimer;

    private Transform target;


    private void Awake()
    {
        enemyAnim = GetComponent<EnemyAnimation>();

        navAgent = GetComponent<NavMeshAgent>();

        target = GameObject.FindWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyState = EnemyState.PATROL;

        patrolTimer = patrolForThisTime;

        attackTimer = waitBeforeAttack;

        currentChaseDistance = chaseDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyState == EnemyState.PATROL)
        {
            Patrol();
        }

        if(enemyState == EnemyState.CHASE)
        {
            Chase();
        }

        if(enemyState == EnemyState.ATTACK)
        {
            Attack();
        }
    }

    void Patrol()
    {
        navAgent.isStopped = false;
        navAgent.speed = walkSpeed;

        patrolTimer += Time.deltaTime;

        if(patrolTimer > patrolForThisTime)
        {
            SetNewRandomDestination();

            //Reset Patrol timer
            patrolTimer = 0f;
        }

        if (navAgent.velocity.sqrMagnitude > 0)
        {
            enemyAnim.Walk(true);
            enemyAnim.Run(false);
            enemyAnim.Idle(false);
        }
        else
        {
            enemyAnim.Walk(false);
            enemyAnim.Run(false);
           
        }

        if(Vector3.Distance(transform.position, target.position) <= chaseDistance)
        {
            enemyAnim.Walk(false);
            enemyAnim.Idle(false);
            enemyAnim.Run(true);

            enemyState = EnemyState.CHASE;

            //PLAY SPOTTED AUDIO
        }

        if(Vector3.Distance(transform.position, target.position) <= attackDistance)
        {
            enemyAnim.Walk(false);
            enemyAnim.Idle(false);
            enemyAnim.Run(false);

            enemyState = EnemyState.ATTACK;

            if(chaseDistance != currentChaseDistance)
            {
                chaseDistance = currentChaseDistance;
            }
            else if(Vector3.Distance(transform.position, target.position) > chaseDistance )
            {
                enemyAnim.Run(false);
                enemyState = EnemyState.PATROL;

                patrolTimer = patrolForThisTime;
                if (chaseDistance != currentChaseDistance)
                {
                    chaseDistance = currentChaseDistance;
                }
            }
        }
    }

    void Chase()
    {
        navAgent.isStopped = false;
        navAgent.speed = runSpeed;

        navAgent.SetDestination(target.position);
    }

    void Attack()
    {
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;

        attackTimer += Time.deltaTime;

        if(attackTimer > waitBeforeAttack)
        {
            enemyAnim.Attack();

            attackTimer = 0f;

            //play attack sound
        }

    if(Vector3.Distance(transform.position, target.position) > attackDistance + chaseAfterAttackDistance)
        {
            enemyState = EnemyState.CHASE;
        }
       
    }

    void SetNewRandomDestination()
    {
        float randomRadius = Random.Range(patrolRadiusMin, patrolRadiusMax);

        Vector3 randomDirection = Random.insideUnitSphere * randomRadius;

        randomDirection += transform.position;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, randomRadius, -1);

        navAgent.SetDestination(navHit.position);
    }
}
