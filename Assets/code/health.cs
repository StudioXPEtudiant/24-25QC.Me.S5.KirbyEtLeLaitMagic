using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the object
    private int currentHealth;  // Current health of the object

    void Start()
    {
        // Initialize current health to max health
        currentHealth = maxHealth;
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce health by the damage amount

        // Check if health is zero or below
        if (currentHealth <= 0)
        {
            Die(); // Call the Die method
        }
    }

    // Method to handle object death
    void Die()
    {
        // Destroy the object
        Destroy(gameObject);
    }
}
