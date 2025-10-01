using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float gameTime = 60f;
    public TextMeshProUGUI timerText;

    private float timeLeft;
    private bool timerRunning = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeLeft = gameTime;
        UpdateTimerDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimerDisplay();

            // Check if time ran out
            if (timeLeft <= 0)
            {
                timeLeft = 0;
                timerRunning = false;
                TimeUp();
            }
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);

        if (timerText != null)
        {
            timerText.text = string.Format("Time: {1:00}", minutes, seconds);
        }
    }
    
    void TimeUp()
    {
        // Check if player won
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            if (scoreManager.score >= scoreManager.winScore)
            {
                
            }
            else
            {
                // Show lose screen
                GameOverScreen gameOverScreen = FindObjectOfType<GameOverScreen>();
                if (gameOverScreen != null)
                {
                    Time.timeScale = 0f;
                    gameOverScreen.ShowLoseScreen();
                }
            }
        }
    }
    
    public void StopTimer()
    {
        timerRunning = false;
    }
}