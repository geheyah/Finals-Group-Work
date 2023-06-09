using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy health: " + currentHealth);

        if (currentHealth <= 0)
        {
            PlayerProperties.instance.enemiesSlain++;
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy Unalived");
        Destroy(gameObject);
    }
}
