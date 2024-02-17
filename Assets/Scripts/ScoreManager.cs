using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton oluþturmak için kullanýlýr
    public TextMeshProUGUI totalCoinsText;

    private int totalCoins = 0;

    int highScore;

    [SerializeField]
    TextMeshProUGUI gameOverScoreText = default;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateTotalCoinsText();
    }

    public void AddCoins(int coinsToAdd)
    {
        totalCoins += coinsToAdd;
        UpdateTotalCoinsText();
        PlayerPrefs.SetInt("total_coins", totalCoins); 
    }

    private void UpdateTotalCoinsText()
    {
        totalCoinsText.text = totalCoins.ToString("0");
    }

    public void GameOver()
    {
        highScore = Preferences.ReadScore();
        if (totalCoins > highScore)
        {
            Preferences.SelectedScore(totalCoins);
        }
        gameOverScoreText.text = "Score: " + totalCoins;
    }
}
