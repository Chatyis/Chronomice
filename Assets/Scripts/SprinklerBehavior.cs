using System.Collections;
using DefaultNamespace;
using UnityEngine;

public class SprinklerBehavior : MonoBehaviour
{
    [SerializeField]
    private float sprinkleForce = 45f;
    
    private SeasonManager _seasonManager;
    private PlayerAgeManager _playerAgeManager;
    private Rigidbody2D _playerRb;
    private IEnumerator _coroutine;
    
    void Awake()
    {
        _coroutine = SprinkleWater();
        _seasonManager = FindFirstObjectByType<SeasonManager>();
        _seasonManager.seasonChange.AddListener(OnSeasonChange);
        _playerAgeManager = FindFirstObjectByType<PlayerAgeManager>();
        OnSeasonChange();
    }
    
    private void OnSeasonChange()
    {
        if (_seasonManager.CurrentSeason == Season.SPRING)
        {
            StartCoroutine(_coroutine);
            //TODO Change sprite to an active sprinkler
        }
        else
        {
            StopCoroutine(_coroutine);
            //TODO Change sprite to a frozen sprinkler
        }
    }
    
    private IEnumerator SprinkleWater()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            if (_playerRb)
            {
                _playerRb.AddForce(Vector2.up * (sprinkleForce * (_playerAgeManager.Age == 1 ? 0.75f : 1f)), ForceMode2D.Impulse);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        _playerRb = other.gameObject.transform.parent.GetComponent<Rigidbody2D>();
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        _playerRb = null;
    }
}
