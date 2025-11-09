using UnityEngine;

public class PlayerSpawnerBehavior : MonoBehaviour
{
    [SerializeField]
    private Sprite capturedSpawnerSprite;
    
    private SpriteRenderer _spriteRenderer;
    private EventManager _eventManager;
    
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _eventManager = FindFirstObjectByType<EventManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        _spriteRenderer.sprite = capturedSpawnerSprite;
        _eventManager.checkpointCaptured.Invoke(gameObject);
    }
}
