using Unity.VisualScripting;
using UnityEngine;

public class WaterBehavior : MonoBehaviour
{
    private SeasonManager _seasonManager;
    private BoxCollider2D _boxCollider;
    
    private void Awake()
    {
        _seasonManager = FindFirstObjectByType<SeasonManager>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _seasonManager.seasonChange.AddListener(OnSeasonChange);
    }
    
    private void OnSeasonChange()
    {
        if (_seasonManager.CurrentSeason == DefaultNamespace.Season.WINTER)
        {
            GetComponent<SpriteRenderer>().color = (Color.blue + 0.5f * Color.white).WithAlpha(0.5f);
            _boxCollider.enabled = true;
            gameObject.layer = LayerMask.NameToLayer("Terrain");
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.blue.WithAlpha(0.5f);
            _boxCollider.enabled = false;
            gameObject.layer = LayerMask.NameToLayer("Water");
        }
    }
}
