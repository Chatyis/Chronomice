using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public class BushBehavior : MonoBehaviour
{
    private SeasonManager _seasonManager;
    private EventManager _eventManager;

    private void Awake()
    {
        _seasonManager = FindFirstObjectByType<SeasonManager>();
        _eventManager = FindFirstObjectByType<EventManager>();
        _seasonManager.seasonChange.AddListener(OnSeasonChange);
    }
    
    private void OnSeasonChange()
    {
        if (_seasonManager.CurrentSeason == Season.WINTER)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.darkGreen;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(_seasonManager.CurrentSeason == Season.SPRING && other.CompareTag("Player"))
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
