using UnityEngine;

public class GoblinAI : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float chaseSpeed = 3.5f; // Speed when chasing
    public float attackRange = 2.0f; // Range to start attacking
    public float chaseRange = 10.0f; // Range to start chasing
    public int attackDamage = 10; // Damage per attack
    public float attackCooldown = 1.0f; // Time between attacks

    private Animator animator;
    private UnityEngine.AI.NavMeshAgent agent;
    private float lastAttackTime;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = chaseSpeed;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Chase the player if within chase range
        if (distanceToPlayer <= chaseRange && distanceToPlayer > attackRange)
        {
            animator.SetBool("IsChasing", true);
            animator.SetBool("IsAttacking", false);
            agent.SetDestination(player.position);
        }
        // Attack the player if within attack range
        else if (distanceToPlayer <= attackRange)
        {
            animator.SetBool("IsChasing", false);
            animator.SetBool("IsAttacking", true);
            agent.isStopped = true; // Stop moving when attacking

            // Attack the player
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                AttackPlayer();
                lastAttackTime = Time.time;
            }
        }
        // Stop chasing if the player is out of range
        else
        {
            animator.SetBool("IsChasing", false);
            animator.SetBool("IsAttacking", false);
            agent.isStopped = true;
        }
    }

    private void AttackPlayer()
    {
        Debug.Log("Goblin attacked the player!");
        // Deal damage to the player
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}