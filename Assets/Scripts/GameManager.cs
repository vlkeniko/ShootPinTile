using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;
    private Dictionary<GameObject, int> playerScores = new Dictionary<GameObject, int>();

    void Start()
    {
        InitializeScores();
        StartRound();
    }

    void InitializeScores()
    {
        foreach (GameObject player in players)
        {
            playerScores[player] = 0;
        }
    }

    void StartRound()
    {
        StartCoroutine(RoundRoutine());
    }

    IEnumerator RoundRoutine()
    {
        foreach (var player in players)
        {
            yield return StartCoroutine(PlayerShoot(player));
        }
        EvaluateCollisions();  // Évaluer les collisions après que tous les joueurs ont tiré
        EndRound();
    }

    IEnumerator PlayerShoot(GameObject player)
    {
        PlayerController controller = player.GetComponent<PlayerController>();
        controller.ResetCollisionFlags();  // Réinitialiser les drapeaux avant le tir

        KeyCode shootKey = player == players[0] ? KeyCode.Q : KeyCode.W;
        bool hasShot = false;

        Debug.Log(player.name + " is ready to shoot. Press " + shootKey + " to shoot.");

        while (!hasShot)
        {
            if (Input.GetKeyDown(shootKey))
            {
                Debug.Log(player.name + " has shot the ball!");
                hasShot = true;
            }
            yield return null;
        }
    }

    void EvaluateCollisions()
    {
        foreach (GameObject player in players)
        {
            PlayerController controller = player.GetComponent<PlayerController>();
            if (controller.isOnHole)
            {
                playerScores[player] -= 1;
                Debug.Log(player.name + " fell into a hole. Score: " + playerScores[player]);
            }
            if (controller.isOnTile)
            {
                playerScores[player] += 1;
                Debug.Log(player.name + " landed on a tile. Score: " + playerScores[player]);
            }
        }
    }

    void EndRound()
    {
        Debug.Log("Round ended. Resetting positions...");
        // Vous pouvez réinitialiser les positions des joueurs ici si nécessaire
        StartRound(); // Starts the next round
    }
}
