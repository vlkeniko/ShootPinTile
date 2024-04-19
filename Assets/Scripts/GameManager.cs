using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;
    private Dictionary<GameObject, int> playerScores = new Dictionary<GameObject, int>();
    private int currentPlayerIndex = 0;  // Index pour suivre quel joueur est en train de tirer

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
        currentPlayerIndex = 0;  // Commence avec le premier joueur
        StartCoroutine(RoundRoutine());
    }

    IEnumerator RoundRoutine()
    {
        foreach (var player in players)
        {
            yield return StartCoroutine(PlayerShoot(player));
            currentPlayerIndex++;  // Passer au joueur suivant après chaque tir
        }
        EvaluateCollisions();  // Évaluer les collisions après que tous les joueurs ont tiré
        EndRound();
    }

    IEnumerator PlayerShoot(GameObject player)
    {
        PlayerController controller = player.GetComponent<PlayerController>();
        controller.EnablePlayerControl(true);  // Activer le contrôle pour le joueur actuel
        Debug.Log(player.name + " is ready to shoot. Press Space to shoot.");

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space)); // Attendre que la touche espace soit pressée

        Debug.Log(player.name + " has shot the ball!");
        controller.EnablePlayerControl(false);  // Désactiver le contrôle après le tir
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
