using System;
using UnityEngine;

public class Game2Start : MonoBehaviour
{

    public static event Action OnGameStarted;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnGameStarted.Invoke();
        }
    }
}
