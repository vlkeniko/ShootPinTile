using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isOnHole = false;
    public bool isOnTile = false;
    public float shootForce = 200f;
    public float friction = 0.1f;
    private Rigidbody2D rb;
    private bool canControl = false; // Contrôle si le joueur peut agir

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (canControl && Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        ApplyFriction();
    }

    public void EnablePlayerControl(bool enable)
    {
        canControl = enable;
    }

    private void Shoot()
    {
        rb.velocity = Vector2.up * shootForce; // Applique une force pour "tirer" le joueur vers le haut
    }

    private void ApplyFriction()
    {
        if (rb.velocity.magnitude > 0)
        {
            rb.velocity -= rb.velocity.normalized * friction * Time.deltaTime; // Applique la friction
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckCollision(collision, true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        CheckCollision(collision, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CheckCollision(collision, false);
    }

    void CheckCollision(Collider2D collision, bool isColliding)
    {
        if (collision.CompareTag("Hole"))
        {
            isOnHole = isColliding;  // Mettre à jour l'état basé sur la présence sur un Hole
        }
        else if (collision.CompareTag("Tile"))
        {
            isOnTile = isColliding;  // Mettre à jour l'état basé sur la présence sur un Tile
        }
    }

    public void ResetCollisionFlags()
    {
        isOnHole = false;
        isOnTile = false;
    }
}
