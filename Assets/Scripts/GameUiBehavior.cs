using TMPro;
using UnityEngine;

public class GameUiBehavior : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI cheeseScoreText;
    [SerializeField]
    private TextMeshProUGUI deathsText;
    
    private void Awake()
    {
        InitScoreText();
    }

    public void OnScorePickedUp()
    {
        cheeseScoreText.text = "x " + StaticData.CheeseScore;
    }
    
    public void OnPlayerDeath()
    {
        deathsText.text = "x " + StaticData.Deaths;
    }

    private void InitScoreText()
    {
        deathsText.text = "x " + StaticData.Deaths;
        cheeseScoreText.text = "x " + StaticData.CheeseScore;
    }
}
