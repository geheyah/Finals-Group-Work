using System.Collections;
using UnityEngine;


public class EnemyCombat : MonoBehaviour
{
    public float attackRange = 1f;
    public int attackDamage = 10;
    public float attackDelay = 1f;
    public Transform attackPoint;

    private bool canAttack = true;

    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = PlayerHealth.instance;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is within attack range and if the enemy can currently attack
        if (Vector3.Distance(transform.position, PlayerProperties.instance.transform.position) <= attackRange && canAttack)
        {
            Attack();
        }
    }

    void Attack()
    {
        canAttack = false;

        PlayerHealth.instance.TakeDamage(attackDamage);

        StartCoroutine(AttackDelay());

        Debug.Log("Enemy Attacks");
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackDelay);

        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
