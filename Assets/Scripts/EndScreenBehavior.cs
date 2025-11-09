using TMPro;
using UnityEngine;

public class EndScreenBehavior : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI cheeseScoreText;
    [SerializeField]
    private TextMeshProUGUI deathsText;
    
    void Awake()
    {
        deathsText.text = "x " + StaticData.Deaths;
        cheeseScoreText.text = "x " + StaticData.CheeseScore;
    }
}
