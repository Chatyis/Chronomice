using Unity.VisualScripting;
using UnityEngine;

public class WaterBehavior : MonoBehaviour
{
    private PlayerController _playerController;
    
    private void Awake()
    {
        _playerController = FindFirstObjectByType<PlayerController>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            _playerController.Die(true);
        }
    }
}
