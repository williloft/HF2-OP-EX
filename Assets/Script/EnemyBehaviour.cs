
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform hero;

    public LayerMask isGround, isHero;

    public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //angriber
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool heroInSightRange, heroInAttackRange;

    private void Awake()
    {
        hero = GameObject.Find("Hero").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        //checkker om spilleren er i sigte
        heroInSightRange = Physics.CheckSphere(transform.position, sightRange, isHero);
        heroInAttackRange = Physics.CheckSphere(transform.position, attackRange, isHero);

        if (!heroInSightRange && !heroInAttackRange) Patroling();
        if (heroInSightRange && !heroInAttackRange) ChaseHero();
        if (heroInSightRange && heroInAttackRange) AttackHero();


    }

    public void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //når walkPoint er nået
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, isGround))
            walkPointSet = true;
    }
    public void ChaseHero()
    {
        agent.SetDestination(hero.position);
    }

    public void AttackHero()
    {
        //for at være sikker på at enemy ikke bevægers sig når den slår
        agent.SetDestination(transform.position);

        transform.LookAt(hero);


        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(KillEnemy), 0.5f);

            
       
        
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

}
