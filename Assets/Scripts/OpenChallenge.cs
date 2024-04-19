using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject uiSquarePrefab;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Challenge") && other.transform.parent.CompareTag("Player"))
        {
            ShowUISquare();
        }
    }

    void ShowUISquare()
    {
        Instantiate(uiSquarePrefab, Vector3.zero, Quaternion.identity);
    }
}