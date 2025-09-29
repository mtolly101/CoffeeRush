using UnityEngine;

public class CoffeeBean : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool isCollected = false;
    public ParticleSystem beanEffect;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPosition = transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;

            if (beanEffect != null)
            {
                Instantiate(beanEffect, transform.position, Quaternion.identity);
            }
            
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
            
            // Hide coffee bean
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            
            Invoke("RespawnCoffeeBean", 10f);
        }
    }
    
    // Respawn
    void RespawnCoffeeBean()
    {
        transform.position = originalPosition;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        isCollected = false;
    }
}