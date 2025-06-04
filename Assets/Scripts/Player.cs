using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 6f;
    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;

    [Header("Swimming Settings")]
    public float swimSpeed = 3f;
    public float swimUpSpeed = 2f;
    private bool isInWater = false;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    [Header("Stats")]
    public float wood;
    public float health = 20;
    public float hunger = 10;
    public Text healthText;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
      
    }

    void Update()
    {
        // Update health UI
        float roundedHealth = Mathf.Round(health);
        healthText.text = roundedHealth.ToString();

        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    
        if (isGrounded && velocity.y < 0)
        {
            // Strongly stick player to ground, avoid floating due to small velocity
            velocity.y = -2f;
        }

        // Movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (isInWater)
        {
            move.y = 0;

            if (Input.GetKey(KeyCode.Space))
            {
                move.y = swimUpSpeed;
            }
            else
            {
                // Apply slight downward force to simulate sinking/buoyancy
                move.y = -0.5f;  // tweak this value as needed
            }

            controller.Move(move * swimSpeed * Time.deltaTime);

            // Don't reset velocity to zero, or use velocity only for jumping/falling out of water
        }
        else
        {
            // Move horizontally
            controller.Move(move * speed * Time.deltaTime);

            // Jumping
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            // Apply gravity every frame (will pull player down if not grounded)
            velocity.y += gravity * Time.deltaTime;

            // Apply vertical movement (jump/fall)
            controller.Move(velocity * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = true;
            velocity = Vector3.zero; // reset vertical velocity

            // Snap player y position to water surface
            Vector3 pos = transform.position;
            pos.y = other.bounds.min.y + 0.1f;  // just a bit above water bottom
            transform.position = pos;
        }
        }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = false;
        }
    }
}