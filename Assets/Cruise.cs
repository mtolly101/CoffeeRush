using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR.Haptics;

[RequireComponent(typeof(ParticleSystem))]
public class Cruise : MonoBehaviour
{
    [SerializeField] float currentSpeed = 5f;
    [SerializeField] float steerSpeed = 200f;

    [SerializeField] float boostSpeed = 10f;

    [SerializeField] float startingSpeed = 5f;

    [SerializeField] ParticleSystem ParticleSystem;

    [SerializeField] TMP_Text boostText = default!;

    public BoostBurst boostFx;



    void Start()
    {
        ParticleSystem = GetComponent<ParticleSystem>();


        boostText.text = string.Empty;
        // boostText = GetComponent<TMP_Text>();
        //boostText = FindAnyObjectByType< TMP_Text>();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        boostText.text = string.Empty;

        var emission = GetComponent<ParticleSystem>().emission;
        emission.enabled = false;
        currentSpeed = startingSpeed;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost"))
        {
            // boostText.text = "Boost!";
            // var emission = particleSystem.emission;
            // emission.enabled = true;

            // var main = particleSystem.main;
            // main.startSpeed = UnityEngine.Random.Range(2f, 5f);

            // currentSpeed = boostSpeed;
            // Destroy(collision.gameObject);

            if (collision.CompareTag("Boost"))
            {
                // Move/emit at the car (or other.transform.position if you prefer)
                boostFx.Play(transform.position);

                // your existing boost logic...
                Destroy(collision.gameObject);
            }
        }
    
}



    void Update()
    {
        var time = DateTime.Now;

        var expireTime = time.AddSeconds(5);

        if (DateTime.Now > expireTime)
        {

        }

        float move = 0f;
        float steer = 0f;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            move = 1f;
        }

        else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            move = -1f;
        }

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            steer = 1f;
        }

        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            steer = -1f;
        }

        float moveAmount = move * currentSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;

        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, steerAmount);
    }
}
