using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float maxSpeed = 8f;
    
    [Header("Health System")]
    public int maxHealth = 100;
    public int currentHealth;
    
    private Rigidbody2D rb;
    private GameManager gameManager;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        gameManager = FindObjectOfType<GameManager>();
        
        // Update UI at start
        if (gameManager != null)
            gameManager.UpdateHealthUI(currentHealth);
    }
    
    void Update()
    {
        HandleMovement();
    }
    
    void HandleMovement()
    {
        // Get input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        // Create movement vector
        Vector2 movement = new Vector2(horizontal, vertical).normalized;
        
        // Apply movement
        rb.velocity = movement * moveSpeed;
        
        // Limit maximum speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        // Update UI
        if (gameManager != null)
            gameManager.UpdateHealthUI(currentHealth);
        
        // Check for death
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        Debug.Log("Player died!");
        if (gameManager != null)
            gameManager.GameOver();
    }
}