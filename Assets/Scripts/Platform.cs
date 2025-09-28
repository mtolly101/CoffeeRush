using UnityEngine;

public class Platform : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool movingRight = true;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        rb.linearVelocity = new Vector2(moveSpeed, 0);
        rb.mass = 1000f;
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Left"))
        {
            rb.linearVelocity = new Vector2(moveSpeed, 0);
        }
        else if (other.gameObject.CompareTag("Right"))
        {
            rb.linearVelocity = new Vector2(-moveSpeed, 0);
        }
    }
}