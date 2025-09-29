using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public int health = 100;
    public TextMeshProUGUI healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateHealthDisplay();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;

        if (health < 0)
        {
            health = 0;
        }

        UpdateHealthDisplay();

        // See if player died
        if (health <= 0)
        {
            YouLose();
        }
    }

    void UpdateHealthDisplay()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }
        else
        {
            Debug.Log("Error in health");
        }
    }
    
    void YouLose()
    {
        TimerManager timer = FindObjectOfType<TimerManager>();
        if (timer != null) timer.StopTimer();

        // Stop the game
        Time.timeScale = 0f;
        
        // Lose :(
        GameOverScreen gameOverScreen = FindObjectOfType<GameOverScreen>();
        if (gameOverScreen != null)
        {
            gameOverScreen.ShowLoseScreen();
        }
    }
}