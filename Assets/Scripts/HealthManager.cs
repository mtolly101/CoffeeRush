using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public int health = 100;
    public TextMeshProUGUI healthText;

    void Start()
    {
        UpdateHealthDisplay();
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;

        // Don't let health go below 0
        if (health < 0)
        {
            health = 0;
        }

        Debug.Log("Health is now: " + health);
        UpdateHealthDisplay();

        // Check if player died
        if (health <= 0)
        {
            YouLose();
            // You can add game over screen here later
        }
    }

    void UpdateHealthDisplay()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health;
            Debug.Log("Updated health display to: Health: " + health);
        }
        else
        {
            Debug.Log("ERROR: healthText is null!");
        }
    }
    
    void YouLose()
    {
        Debug.Log("GAME OVER! You died!");
        
        // Stop the game
        Time.timeScale = 0f;
        
        // Find and show lose screen
        GameOverScreen gameOverScreen = FindObjectOfType<GameOverScreen>();
        if (gameOverScreen != null)
        {
            gameOverScreen.ShowLoseScreen();
        }
    }
}