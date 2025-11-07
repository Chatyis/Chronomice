using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAgeManager : MonoBehaviour
{
    private int _age = 0;
    private SeasonManager _seasonManager;
    private PlayerController _playerController;

    public int Age
    {
        set
        {
            _age = value;
            ageChange.Invoke();
        }
        get => _age;
    }
    public UnityEvent ageChange;

    private void Awake()
    {
        _seasonManager = FindFirstObjectByType<SeasonManager>();
        _playerController = FindFirstObjectByType<PlayerController>();
        _seasonManager.seasonChange.AddListener(OnSeasonChange);
        _playerController.playerDeath.AddListener(OnPlayerDeath);
    }

    private void IncreaseAge(int amount)
    {
        Age += amount;
    }
    
    private void ResetAge()
    {
        Age = 0;
    }
    
    private void OnSeasonChange()
    {
        if (_seasonManager.CurrentSeason == Season.SPRING)
        {
            IncreaseAge(1);
        }
    }
    
    private void OnPlayerDeath()
    {
        ResetAge();
        ageChange.Invoke();
    }
}
