using System;
using DefaultNamespace;
using UnityEngine;

public class SeedPitBehavior : MonoBehaviour
{
    [SerializeField] private GameObject plantPrefab;
    
    private bool _isSeedInside;
    private SeasonManager _seasonManager;

    private void Awake()
    {
        _seasonManager = FindFirstObjectByType<SeasonManager>();
        _seasonManager.seasonChange.AddListener(OnSeasonChange);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Seed")) return;
        
        _isSeedInside = true;
        //TODO Change sprite to a planted seed pit
        Destroy(other.gameObject);
    }
    
    private void OnSeasonChange()
    {
        if (_seasonManager.CurrentSeason == Season.SPRING && _isSeedInside)
        {
            Instantiate(plantPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
