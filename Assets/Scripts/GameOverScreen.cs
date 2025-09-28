using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI finalScoreText;
    
    void Start()
    {
        // Hide game over screen at start
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
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
    
    // Call this from a button
    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume game time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    // Call this from a button  
    public void QuitGame()
    {
        Application.Quit();
    }
}