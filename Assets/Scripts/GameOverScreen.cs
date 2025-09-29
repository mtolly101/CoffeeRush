using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI finalScoreText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
 
    }
    
    public void ShowWinScreen()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);

            if (gameOverText != null)
            {
                gameOverText.text = "You win :)";
            }

            if (finalScoreText != null)
            {
                ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
                if (scoreManager != null)
                {
                    finalScoreText.text = "Final Score: " + scoreManager.score;
                }
            }
        }
    }
    
    public void ShowLoseScreen()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        
            if (gameOverText != null)
            {
                gameOverText.text = "You lose :(";
            }
        
            if (finalScoreText != null)
            {
                ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
                if (scoreManager != null)
                {
                    finalScoreText.text = "Final Score: " + scoreManager.score;
                }
            }
        }
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}