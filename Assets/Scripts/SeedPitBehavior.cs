using System;
using DefaultNamespace;
using UnityEngine;

public class SeedPitBehavior : MonoBehaviour
{
    [SerializeField] private GameObject plantPrefab;
    [SerializeField] private Sprite fullSeedPitSprite;
    
    private bool _isSeedInside;
    private SeasonManager _seasonManager;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _seasonManager = FindFirstObjectByType<SeasonManager>();
        _seasonManager.seasonChange.AddListener(OnSeasonChange);
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Seed")) return;
        
        _isSeedInside = true;
        _spriteRenderer.sprite = fullSeedPitSprite;
        
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
