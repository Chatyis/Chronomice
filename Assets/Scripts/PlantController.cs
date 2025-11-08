using UnityEngine;

public class PlantController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] growthStages;
    
    private SeasonManager _seasonManager;
    private int _currentStage = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _seasonManager = FindFirstObjectByType<SeasonManager>();
        _seasonManager.seasonChange.AddListener(GrowToNextStage);
    }

    private void GrowToNextStage()
    {
        if(_currentStage < growthStages.Length - 1)
        {
            growthStages[_currentStage].SetActive(false);
            _currentStage++;
            growthStages[_currentStage].SetActive(true);
        }
    }
}
