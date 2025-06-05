using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 6f;
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float gravity = -9.81f;

    [Header("Swimming Settings")]
    [SerializeField] private float swimSpeed = 3f;
    [SerializeField] private float swimUpSpeed = 2f;
    [SerializeField] private float waterBuoyancy = -0.5f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.4f;
    [SerializeField] private LayerMask groundMask;

    [Header("Stats")]
    public float wood;
    public float health = 20f;
    public float hunger = 10f;
    public Text healthText;

    private CharacterController controller;
    public Vector3 velocity;
    public bool isGrounded;
    public bool isInWater;
    public GravityWork gravityWork;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (gravityWork.work == true)
        {
            Vector3 currentP = transform.position;
            Vector3 newPosition = new Vector3(currentP.x, 1, currentP.z);
            transform.position = newPosition;
        }
        UpdateUI();
        CheckGroundStatus();

        if (isInWater)
        {
            Swim();
        }
        else
        {
            MoveAndJump();
        }
    }

    private void UpdateUI()
    {
        healthText.text = Mathf.Round(health).ToString();
    }

    private void CheckGroundStatus()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Stick to ground
        }
    }

    private void MoveAndJump()
    {
        Vector3 input = GetMovementInput();
        controller.Move(input * walkSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Swim()
    {
        Vector3 move = GetMovementInput();
        move.y = Input.GetKey(KeyCode.Space) ? swimUpSpeed : waterBuoyancy;
        controller.Move(move * swimSpeed * Time.deltaTime);
    }

    private Vector3 GetMovementInput()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        return transform.right * x + transform.forward * z;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = true;
            velocity = Vector3.zero;

            // Optional: Snap to water surface
            Vector3 pos = transform.position;
            pos.y = other.bounds.min.y + 0.1f;
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