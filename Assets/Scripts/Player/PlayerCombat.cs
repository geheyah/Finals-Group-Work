using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int attackDamage = 20;
    public float attackRange = 2f;
    public float attackDelay = 1f;
    public float knockbackForce = 100f; // The force applied to enemies when hit
    public GameObject attackEffect;
    public Transform attackPoint;

    private FirstPersonMovement playerMovement;

    private bool canAttack = true;

    void Start()
    {
        // Get a reference to the player's movement script
        playerMovement = GetComponent<FirstPersonMovement>();
    }

    void Update()
    {
        // Attack with left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            Debug.Log("Attack");
        }
    }

    public void Attack()
    {
        if (canAttack)
        {
            // Perform attack
            Instantiate(attackEffect, attackPoint.position, attackPoint.rotation);
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange);

            foreach (Collider enemy in hitEnemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                    enemyHealth.TakeDamage(attackDamage);

                    // Apply knockback to enemy
                    Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();
                    if (enemyRigidbody != null)
                    {
                        Vector3 knockbackDirection = (enemy.transform.position - transform.position).normalized;
                        enemyRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
                    }
                }
            }

            // Set cooldown
            canAttack = false;
            Invoke("ResetAttack", attackDelay);
        }
    }

    private void ResetAttack()
    {
        canAttack = true;
    }
}
