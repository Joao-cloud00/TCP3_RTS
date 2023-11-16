
using UnityEngine;
using UnityEngine.AI;

public class ZeGota : UnitStats
{

    public Transform enemy;


    public LayerMask whatIsGround, Units;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Unit").transform;
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Units);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, Units);

        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }


    private void AttackPlayer()
    {

        transform.LookAt(enemy);

        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Agua")
        {
            timeBetweenAttacks = 1;
        }
        else
        {
            timeBetweenAttacks = 2;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.name == "Ilha")
        {
            LevarDano(1);
        }
    }
}
