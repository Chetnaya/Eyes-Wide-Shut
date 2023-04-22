using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    /*--------------------------------------------------------------
    -----------------------Static Variables-------------------------
    ---------------------------------------------------------------*/
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask Groundlayer, Playerlayer;
    /*--------------------------------------------------------------
    --------------------------Patrolling----------------------------
    ---------------------------------------------------------------*/
    public Vector3 walkPoint;
    bool isWalkPointSet;
    public float walkPointRange;
    /*--------------------------------------------------------------
    --------------------------Attacking-----------------------------
    ---------------------------------------------------------------*/
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    /*--------------------------------------------------------------
    ----------------------------States------------------------------
    ---------------------------------------------------------------*/
    public float sightRange, attackRange; 
    public bool playerInSightRange, playerInAttackRange;
    /*--------------------------------------------------------------
    ----------------------------------------------------------------
    ---------------------------------------------------------------*/
    void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        //Check if the player is in SIGHT or ATTACk range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Playerlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange , Playerlayer);

        if(!playerInAttackRange && !playerInSightRange) Patroling();
        if(!playerInAttackRange && playerInSightRange) ChasePlayer();
        if(playerInAttackRange && playerInSightRange) AttackPlayer(); 
    }
    /*--------------------------------------------------------------
    ----------------------State Functions---------------------------
    ---------------------------------------------------------------*/
    private void Patroling()
    {
        if(!isWalkPointSet) SearchWalkPoint();

        if(isWalkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
        
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if(distanceToWalkPoint.magnitude < 1f)
        {
            isWalkPointSet = false;
        }
    }

    private void ChasePlayer()
    {

    }

    private void AttackPlayer()
    {

    }
    /*--------------------------------------------------------------
    ----------------------------------------------------------------
    ---------------------------------------------------------------*/
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX , transform.position.y, transform.position.z + randomZ);

        //If the point is outside of the map, check is raycast of point is on the ground
        if(Physics.Raycast(walkPoint, -transform.up, 2f, Groundlayer))
        {
            isWalkPointSet = true; 
        }
    }

    






}
