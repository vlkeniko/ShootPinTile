using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Array of player names
    public string[] names = { "Player1", "Player2", "Player3", "Player4" };

    // Array of colors corresponding to each player name
    public Color[] colors = new Color[4];

    void Start()
    {
        // Assigning names and colors to players
        for (int i = 0; i < names.Length; i++)
        {
            GameObject player = new GameObject(names[i]);
            player.AddComponent<SpriteRenderer>().color = colors[i];
        }
    }
}
