
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.AI;

public class Eremita : UnitStats
{
    [SerializeField]
    public GameObject Unit;

    float porcent;

    int powerUp;

    float DanoInicial;

    private float cooldownHeal;
    private bool IscooldownHeal;

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
        Unit = GameObject.FindGameObjectWithTag("Azul");
        DanoInicial = Unit.GetComponent<UnitStats>().DanoStats;
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Units);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, Units);

        if (playerInAttackRange && playerInSightRange)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Unit.GetComponent<UnitStats>().LevarDano(50);
                gameObject.SetActive(false);
            }
            if (VidaAtual <= 0)
            {
                Unit.GetComponent<UnitStats>().LevarDano(50);
                gameObject.SetActive(false);
            }
        }
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
}
