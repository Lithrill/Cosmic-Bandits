using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecondAIScript : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject ThePlayerObject, TheEnemy;

    public GameObject playerSound;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public GameObject gameOverCanvas;

    public bool isRoutineRunning = false;

    Coroutine lastRoutine = null;


    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("FPSController").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patroling();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if (playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();
        }

        if (Vector3.Distance(TheEnemy.transform.position, playerSound.transform.position) <= 17)
        {

            if (isRoutineRunning == false)
            {
                Debug.Log("SoundPlayed");
                FindObjectOfType<AudioManager>().Play("Monster_Scream");
                //FindObjectOfType<AudioManager>().Play("GunShot");
                lastRoutine = StartCoroutine(SpecialSound());
                isRoutineRunning = true;
            }
            
        }
    }

    IEnumerator SpecialSound()
    {
        Debug.Log("ST");
        yield return new WaitForSeconds(15);
        Debug.Log("ED");
        isRoutineRunning = false;
        StopCoroutine(lastRoutine);
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void Patroling()
    {
        //FindObjectOfType<AudioManager>().Play("Monster_Scream");
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);

        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        //FindObjectOfType<AudioManager>().Play("Monster_Scream");
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(player.position);

        transform.LookAt(player);
        //FindObjectOfType<AudioManager>().Play("Monster_Scream");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            gameOverCanvas.SetActive(true);
        }
    }


}
