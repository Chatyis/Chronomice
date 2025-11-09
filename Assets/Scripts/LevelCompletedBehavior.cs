using UnityEngine;

public class LevelCompletedBehavior : MonoBehaviour
{
    private EventManager _eventManager;
    
    private void Awake()
    {
        _eventManager = FindFirstObjectByType<EventManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _eventManager.levelCompleted.Invoke();
        }
    }
}
