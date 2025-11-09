using System;
using DefaultNamespace;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField]
    private GameObject springBackground;
    [SerializeField]
    private GameObject winterBackground;

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
            winterBackground.SetActive(true);
            springBackground.SetActive(false);
        }
        else
        {
            winterBackground.SetActive(false);
            springBackground.SetActive(true);
        }
    }
}
