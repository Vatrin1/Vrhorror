using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Attacking
    bool jumpscare = false;

    //States
    public float attackRange;
    public bool playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("XR Origin").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInAttackRange) ChasePlayer();
        if (playerInAttackRange) AttackPlayer();

    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        jumpscare = true;
        print(jumpscare);
        Invoke(nameof(DestroyEnemy), .1f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
