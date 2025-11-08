using UnityEngine;
using UnityEngine.Events;

public class PlayerDetectorController : MonoBehaviour
{
    public UnityEvent playerDetected;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerDetected.Invoke();
    }
}
