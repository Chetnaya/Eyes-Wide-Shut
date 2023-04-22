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
    bool already Attacked;
    /*--------------------------------------------------------------
    ----------------------------States------------------------------
    ---------------------------------------------------------------*/
    public float sightRange, attackRange; 
    public bool playerInSightRange, playerInAttackRange;
    





}
