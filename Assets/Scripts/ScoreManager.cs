using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public int winScore = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreDisplay();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore(int points)
    {
        score = score + points;
        Debug.Log("Score is now: " + score);
        UpdateScoreDisplay();

        if (score >= winScore)
        {
            YouWin();
        }
    }

    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
            Debug.Log("Updated score display to: Score: " + score);
        }
        else
        {
            Debug.Log("ERROR: scoreText is null!");
        }
    }

    void YouWin()
    {
        Debug.Log("YOU WIN!");

        // Stop the game
        Time.timeScale = 0f;

        // Find and show win screen
        GameOverScreen gameOverScreen = FindObjectOfType<GameOverScreen>();
        if (gameOverScreen != null)
        {
            gameOverScreen.ShowWinScreen();
        }
    }
}