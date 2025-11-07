using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public class SeasonManager : MonoBehaviour
{
    private Season _currentSeason = Season.SPRING;
    private PlayerAgeManager _playerAgeManager;
    
    public Season CurrentSeason => _currentSeason;
    public UnityEvent seasonChange;

    private void Awake()
    {
        _playerAgeManager = FindFirstObjectByType<PlayerAgeManager>();
    }
    
    public void ToggleSeason()
    {
        _currentSeason = _currentSeason == Season.SPRING ? Season.WINTER : Season.SPRING;
        
        seasonChange.Invoke();
    }
}
