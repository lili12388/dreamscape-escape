using UnityEngine;
using UnityEngine.UI;

public class GoblinHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Slider healthBar;  // Assign in Inspector
    public Transform healthBarPosition;  // Empty GameObject above Goblin’s head

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    void Update()
    {
        // Ensure health bar follows the Goblin
        if (healthBar != null && healthBarPosition != null)
        {
            healthBar.transform.position = Camera.main.WorldToScreenPoint(healthBarPosition.position);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Destroy(healthBar.gameObject);  // Remove health bar when Goblin dies
    }
}
