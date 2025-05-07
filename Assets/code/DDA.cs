using UnityEngine;

public class attack : MonoBehaviour
{
    public int normalAttackDamage = 5; // Damage dealt by the normal attack
    public int slashAttackDamage = 20; // Damage dealt by the slash attack
    public float slashRange = 2f; // Range of the slash attack
    public float normalAttackRange = 1f; // Range of the normal attack
    public LayerMask enemyLayer; // Layer for enemies to detect

    void Update()
    {
        // Check for normal attack input (e.g., left mouse button or "Q" key)
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            PerformNormalAttack();
        }
        else if (Input.GetKeyDown(KeyCode.Q)) // "Q" key
        {
            PerformNormalAttack();
        }

        // Check for slash input (e.g., "E" key)
        if (Input.GetKeyDown(KeyCode.R))
        {
            PerformSlash();
        }
    }

    void PerformNormalAttack()
    {
        // Detect all enemies within the normal attack range
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, normalAttackRange, enemyLayer);

        // Apply damage to each enemy
        foreach (Collider enemy in hitEnemies)
        {
            Health targetHealth = enemy.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(normalAttackDamage);
            }
        }
    }

    void PerformSlash()
    {
        // Detect all enemies within the slash range
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, slashRange, enemyLayer);

        // Apply damage to each enemy
        foreach (Collider enemy in hitEnemies)
        {
            Health targetHealth = enemy.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(slashAttackDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw the normal attack range in the editor for visualization
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, normalAttackRange);

        // Draw the slash range in the editor for visualization
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, slashRange);
    }
}