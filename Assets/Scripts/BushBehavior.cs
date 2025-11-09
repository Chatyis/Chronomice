using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public class BushBehavior : MonoBehaviour
{
    [SerializeField] private Sprite springSprite;
    [SerializeField] private Sprite winterSprite;
    [SerializeField] private bool overrideSpringEffect = false;
    
    private SeasonManager _seasonManager;
    private EventManager _eventManager;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _seasonManager = FindFirstObjectByType<SeasonManager>();
        _eventManager = FindFirstObjectByType<EventManager>();
        _seasonManager.seasonChange.AddListener(OnSeasonChange);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        OnSeasonChange();
    }
    
    private void OnSeasonChange()
    {
        if (_seasonManager.CurrentSeason == Season.WINTER && !overrideSpringEffect)
        {
            _spriteRenderer.sprite = winterSprite;
            _eventManager.bushEnteredByPlayer.Invoke(false);
        }
        else
        {
            _spriteRenderer.sprite = springSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if((_seasonManager.CurrentSeason == Season.SPRING || overrideSpringEffect) && other.CompareTag("Player"))
        {
            _eventManager.bushEnteredByPlayer.Invoke(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            _eventManager.bushEnteredByPlayer.Invoke(false);
        }
    }
}
