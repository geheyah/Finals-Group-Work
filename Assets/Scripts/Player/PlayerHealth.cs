using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public static PlayerHealth instance;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Awake()
    {
        instance = this;
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player Unalived");
        Destroy(gameObject);
    }
}
