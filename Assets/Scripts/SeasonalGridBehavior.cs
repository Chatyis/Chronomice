using DefaultNamespace;
using UnityEngine;

public class SeasonalGridBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject snowGrid;
    [SerializeField]
    private GameObject iceGrid;
    [SerializeField]
    private GameObject waterGrid;
    
    private SeasonManager _seasonManager;
    
    private void Awake()
    {
        _seasonManager = FindFirstObjectByType<SeasonManager>();
        _seasonManager.seasonChange.AddListener(OnSeasonChange);
        OnSeasonChange();
    }
    
    private void OnSeasonChange()
    {
        if (_seasonManager.CurrentSeason == Season.WINTER)
        {
            snowGrid.SetActive(true);
            iceGrid.SetActive(true);
            waterGrid.SetActive(false);
        }
        else
        {
            snowGrid.SetActive(false);
            iceGrid.SetActive(false);
            waterGrid.SetActive(true);
        }
    }
}
