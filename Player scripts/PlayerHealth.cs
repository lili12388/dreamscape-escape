using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Player's max health
    private int currentHealth; // Player's current health
    public Text deathText; // UI text to display "You Died!"

    void Start()
    {
        currentHealth = maxHealth; // Set initial health
        deathText.gameObject.SetActive(false); // Hide the death text initially
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce health
        Debug.Log("Player took damage! Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // Call the Die function
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");
        deathText.gameObject.SetActive(true); // Show the death text
        deathText.text = "You Died!"; // Set the text
        Time.timeScale = 0; // Pause the game
    }
}