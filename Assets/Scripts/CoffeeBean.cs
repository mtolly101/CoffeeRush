using UnityEngine;

public class CoffeeBean : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool isCollected = false;
    
    void Start()
    {
        // Remember where this coffee bean was placed
        originalPosition = transform.position;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            Debug.Log("Coffee bean collected!");
            isCollected = true;
            
            // Add score
            GameObject scoreManagerObj = GameObject.Find("ScoreManager");
            if (scoreManagerObj != null)
            {
                ScoreManager scoreManager = scoreManagerObj.GetComponent<ScoreManager>();
                if (scoreManager != null)
                {
                    scoreManager.AddScore(10);
                }
            }
            
            // Hide the coffee bean
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            
            // Respawn after 5 seconds
            Invoke("RespawnCoffeeBean", 5f);
        }
    }
    
    void RespawnCoffeeBean()
    {
        // Show the coffee bean again at original position
        transform.position = originalPosition;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        isCollected = false;
        
        Debug.Log("Coffee bean respawned!");
    }
}