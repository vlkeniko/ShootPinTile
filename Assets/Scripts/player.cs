using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float shootForce = 200f;
    public float friction = 0.1f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Skyd
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * shootForce; // Sæt spillerens hastighed til at skyde opad
        }

        // Anvend friktion
        if (rb.velocity.magnitude > 0)
        {
            rb.velocity -= rb.velocity.normalized * friction * Time.deltaTime;
        }
    }
}
