using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(BoostBurst))]
public class Driver : MonoBehaviour
{
    [Header("Speed Settings")]
    public float CurrentSpeed = 5f;
    public float SteerSpeed = 200f;
    public float BoostSpeed = 10f;
    public float StartingSpeed = 5f;

    [Header("Boost Effects")]
    public BoostBurst BoostBurst = default!;
    public TMP_Text BoostText = default!;

    void Start()
    {
        Debug.Log("Driver script started.");
        BoostBurst.Stop();
        BoostText.text = string.Empty;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float move = Keyboard.current switch
        {
            { wKey: { isPressed: true } } or { upArrowKey: { isPressed: true } } => 1f,
            { sKey: { isPressed: true } } or { downArrowKey: { isPressed: true } } => -1f,
            _ => 0f
        };

        float steer = Keyboard.current switch
        {
            { aKey: { isPressed: true } } or { leftArrowKey: { isPressed: true } } => 1f,
            { dKey: { isPressed: true } } or { rightArrowKey: { isPressed: true } } => -1f,
            _ => 0f
        };

        float moveAmount = move * CurrentSpeed * Time.deltaTime;
        float steerAmount = steer * SteerSpeed * Time.deltaTime;

        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, steerAmount);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost"))
        {
            BoostBurst.Play(transform.position);
            Destroy(collision.gameObject);

            BoostText.text = "Warp Speeeeed!";
            CurrentSpeed = BoostSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Collide with anything will stop the boost!
        BoostBurst.Stop();
        BoostText.text = string.Empty;
        CurrentSpeed = StartingSpeed;

        BoostText.text = "Dang it!";
    }

}
