using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private GameObject adultMicePrefab;
    [SerializeField] 
    private GameObject youngMicePrefab;
    [SerializeField] 
    private GameObject initialSpawner;
    
    private SeasonManager _seasonManager;
    private PlayerAgeManager _playerAgeManager;
    private EventManager _eventManager;
    private GameObject _playerSpawner;
    
    public UnityEvent playerDeath;
    public bool isHiddenInBush;
    
    private void Awake()
    {
        _seasonManager = FindFirstObjectByType<SeasonManager>();
        _playerAgeManager = FindFirstObjectByType<PlayerAgeManager>();
        _eventManager = FindFirstObjectByType<EventManager>();
        _playerSpawner = initialSpawner;
        _playerAgeManager.ageChange.AddListener(OnAgeChange);
        _eventManager.bushEnteredByPlayer.AddListener((value)=>isHiddenInBush = value);
        _eventManager.checkpointCaptured.AddListener((checkpoint)=>_playerSpawner = checkpoint);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            _seasonManager.ToggleSeason();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StaticData.CheeseScore = StaticData.CheeseScoreBeforeReload;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
    public void Die(bool wasKilled = false)
    {
        // Instantiate corpse prefab at player's position, then move player at start with age = 0, as new mice
        playerDeath.Invoke();
        if (wasKilled)
        {
            transform.position = _playerSpawner.transform.position;
        }
        else {
            transform.position = _playerSpawner.transform.position;
        }
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
