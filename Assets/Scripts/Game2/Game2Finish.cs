using System;
using UnityEngine;

public class Game2Finish : MonoBehaviour
{
    public static event Action OnGameEnded;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnGameEnded.Invoke();
        }
    }
}
