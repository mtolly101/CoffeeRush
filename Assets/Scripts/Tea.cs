using UnityEngine;

public class Tea : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool isCollected = false;
    
    void Start()
    {
        // Remember where this tea spill was placed
        originalPosition = transform.position;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            Debug.Log("Tea spill hit!");
            isCollected = true;
            
            // Take damage
            GameObject healthManagerObj = GameObject.Find("HealthManager");
            if (healthManagerObj != null)
            {
                HealthManager healthManager = healthManagerObj.GetComponent<HealthManager>();
                if (healthManager != null)
                {
                    healthManager.TakeDamage(20);
                }
            }
            
            // Hide the tea spill
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            
            // Respawn after 5 seconds
            Invoke("RespawnTea", 5f);
        }
    }
    
    void RespawnTea()
    {
        // Show the tea spill again at original position
        transform.position = originalPosition;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        isCollected = false;
        
        Debug.Log("Tea spill respawned!");
    }
}