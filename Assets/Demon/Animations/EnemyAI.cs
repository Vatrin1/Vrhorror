using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    private Player player;
    private JumpscareProf JumpscareEnemy;
    public AudioClip step;

    public LayerMask whatIsGround, whatIsPlayer;

    //Attacking
    bool jumpscare = false;

    //States
    public float attackRange;
    public bool playerInAttackRange;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
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
        agent.SetDestination(player.transform.position);
        GetComponent<AudioSource>().clip = step;
        GetComponent<AudioSource>().Play();
    }
    private void AttackPlayer()
    {
        jumpscare = true;
        print(jumpscare);
        Invoke(nameof(DestroyEnemy), .1f);
        player.transform.position = new Vector3(16f, 0f, 1f);
        player.transform.LookAt(JumpscareEnemy.transform);
        GetComponent<AudioSource>().clip = step;
        GetComponent<AudioSource>().Stop();
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
        GetComponent<AudioSource>().clip = step;
        GetComponent<AudioSource>().Stop();
    }
}
