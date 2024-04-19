using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isOnHole = false;
    public bool isOnTile = false;

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
            isOnHole = isColliding;  // Mettre � jour l'�tat bas� sur la pr�sence sur un Hole
        }
        else if (collision.CompareTag("Tile"))
        {
            isOnTile = isColliding;  // Mettre � jour l'�tat bas� sur la pr�sence sur un Tile
        }
    }

    public void ResetCollisionFlags()
    {
        isOnHole = false;
        isOnTile = false;
    }
}
