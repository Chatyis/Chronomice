using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private readonly string[] _scenes = {"Level1", "Level2", "Level3", "Level4"};
    
    private PlayerController _playerController;
    private EventManager _eventManager;
    private GameUiBehavior _gameUiBehavior;

    private void Awake()
    {
        _playerController = FindFirstObjectByType<PlayerController>();
        _eventManager = FindFirstObjectByType<EventManager>();
        _gameUiBehavior = FindFirstObjectByType<GameUiBehavior>();
        _playerController.playerDeath.AddListener(OnPlayerDeath);
        _eventManager.scorePickedUp.AddListener(OnScorePickedUp);
        _eventManager.levelCompleted.AddListener(OnLevelCompleted);
    }
    
    private void OnPlayerDeath()
    {
        StaticData.Deaths += 1;
        _gameUiBehavior.OnPlayerDeath();
    }
    
    private void OnScorePickedUp()
    {
        StaticData.CheeseScore += 1;
        _gameUiBehavior.OnScorePickedUp();
    }
    
    private void OnLevelCompleted()
    {
        StaticData.CurrentLevelIndex += 1;
        
        if(StaticData.CurrentLevelIndex >= _scenes.Length)
        {
            SceneManager.LoadScene("EndScene");
            return;
        }
        
        StaticData.CheeseScoreBeforeReload = StaticData.CheeseScore;
        SceneManager.LoadScene(_scenes[StaticData.CurrentLevelIndex]);
    }
}
