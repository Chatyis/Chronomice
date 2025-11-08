using System;
using UnityEngine;

public class ScoreBehavior : MonoBehaviour
{
    private EventManager _eventManager;

    private void Awake()
    {
        _eventManager = FindFirstObjectByType<EventManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        _eventManager.scorePickedUp.Invoke(true);
        Destroy(gameObject);
    }
}
