using UnityEngine;

public class Tea : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool isCollected = false;
    public ParticleSystem teaEffect;
    
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

            if (teaEffect != null)
            {
                Instantiate(teaEffect, transform.position, Quaternion.identity);
            }
            
            // Damage
            GameObject healthManagerObj = GameObject.Find("HealthManager");
            if (healthManagerObj != null)
            {
                HealthManager healthManager = healthManagerObj.GetComponent<HealthManager>();
                if (healthManager != null)
                {
                    healthManager.TakeDamage(20);
                }
            }
            
            // Hide teas
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            
            Invoke("RespawnTea", 10f);
        }
    }
    
    // Respawn teas
    void RespawnTea()
    {
        transform.position = originalPosition;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        isCollected = false;
    }
}