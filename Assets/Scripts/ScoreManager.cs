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
        }
        else
        {
            Debug.Log("Error in score");
        }
    }

    void YouWin()
    {
        TimerManager timer = FindObjectOfType<TimerManager>();
        if (timer != null) timer.StopTimer();

        // Stop the game
        Time.timeScale = 0f;

        // Win!!
        GameOverScreen gameOverScreen = FindObjectOfType<GameOverScreen>();
        if (gameOverScreen != null)
        {
            gameOverScreen.ShowWinScreen();
        }
    }
}