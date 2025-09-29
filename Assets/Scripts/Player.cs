using UnityEngine;
using System;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR.Haptics;

public class Player : MonoBehaviour
{
    [SerializeField] float currentSpeed = 5f;
    [SerializeField] float steerSpeed = 200f;
    private bool isGrounded;
    private Rigidbody2D rb;
    public float jumpUp = 6.7f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        float steer = 0f;

        if ((Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) && isGrounded)
        {
            //move = jumpUp;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpUp);
        }

        // else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        // {
        //     move = -5f;
        // }

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            rb.linearVelocity = new Vector2(-currentSpeed, rb.linearVelocity.y);
        }

        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            rb.linearVelocity = new Vector2(currentSpeed, rb.linearVelocity.y);
        }

        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        //float moveAmount = move * currentSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;

        transform.Translate(steer, 0, 0);
        // transform.Rotate(0, 0, steerAmount);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }
}