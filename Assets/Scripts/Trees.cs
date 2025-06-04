using UnityEngine;

public class Trees : MonoBehaviour
{
    public float detectionRange = 2f;
    public Camera playerCamera;
    public OnTrigger onTrigger;
    public float health = 5f;
    public float rotationDuration = 2f;
    public Player player;
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private float rotationTime = 0f;
    private bool isRotating = false;
    public bool Bigtree = false;
    private Rigidbody rb;

    void Start()
    {
        // Cache Rigidbody once
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.freezeRotation = true;
           
        }
        if(Bigtree == true)
        {
            health = 10;
        }
        if(Bigtree == false)
        {
            detectionRange = 2.5f;
        }
    }

    void Update()
    {
        
        if (Vector3.Distance(playerCamera.transform.position, transform.position) <= detectionRange)
        {
            if (onTrigger.isColliding && Input.GetMouseButtonDown(0))
            {
                health -= 1f;
            }
        }

        // Trigger rotation once when health reaches 0 or below
        if (health <= 0 && !isRotating)
        {
            isRotating = true;
            rotationTime = 0f;

            // Unfreeze Rigidbody so physics can affect it if needed
            if (rb != null)
                rb.freezeRotation = false;

            initialRotation = transform.rotation;
            targetRotation = Quaternion.Euler(90f, transform.eulerAngles.y, transform.eulerAngles.z);
        }

        // Smooth rotation logic
        if (isRotating)
        {
            rotationTime += Time.deltaTime;
            float t = Mathf.Clamp01(rotationTime / rotationDuration);
            transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, t);

            if (t >= 1f)
            {
                isRotating = false;
                if (Bigtree == false) { player.wood += 3; } 
                if(Bigtree== true)
                {
                    player.wood += 6;
                }
                Invoke("Disable", 0.5f);
            }
        }
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
}