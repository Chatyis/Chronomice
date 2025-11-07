using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private GameObject adultMicePrefab;
    [SerializeField] 
    private GameObject youngMicePrefab;
    
    private SeasonManager _seasonManager;
    private PlayerAgeManager _playerAgeManager;
    
    public UnityEvent playerDeath;
    
    private void Awake()
    {
        _seasonManager = FindFirstObjectByType<SeasonManager>();
        _playerAgeManager = FindFirstObjectByType<PlayerAgeManager>();
        _playerAgeManager.ageChange.AddListener(OnAgeChange);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            _seasonManager.ToggleSeason();
        }
    }
    
    public void Die()
    {
        // Instantiate corpse prefab at player's position, then move player at start with age = 0, as new mice
        playerDeath.Invoke();
        
        Debug.Log("Player has died of old age.");
    }
    
    private void OnAgeChange()
    {
        if (_playerAgeManager.Age == 0)
        {
            adultMicePrefab.SetActive(false);
            youngMicePrefab.SetActive(true);
        }
        if (_playerAgeManager.Age == 1)
        {
            adultMicePrefab.SetActive(true);
            youngMicePrefab.SetActive(false);
        }
        if(_playerAgeManager.Age >= 2)
        {
            Die();
        }
    }
}
