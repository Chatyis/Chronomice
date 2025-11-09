using System;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class IcicleBehavior : MonoBehaviour
{
    private SeasonManager _seasonManager;
    private EventManager _eventManager;
    private Collider2D _collider2D;

    private void Awake()
    {
        _seasonManager = FindFirstObjectByType<SeasonManager>();
        _seasonManager.seasonChange.AddListener(OnSeasonChange);
        _collider2D = GetComponent<Collider2D>();
    }
    
    private void OnSeasonChange()
    {
        if (_seasonManager.CurrentSeason == Season.WINTER)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            _collider2D.enabled = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            _collider2D.enabled = false;
        }
    }
}
