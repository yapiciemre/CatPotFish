using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton olu�turmak i�in kullan�l�r
    public TextMeshProUGUI totalCoinsText;

    private int totalCoins = 0;

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
        // Ba�lang��ta UI metnini g�ncelleyin
        UpdateTotalCoinsText();
    }

    // Madeni paralar� eklemek i�in kullan�l�r
    public void AddCoins(int coinsToAdd)
    {
        totalCoins += coinsToAdd;
        UpdateTotalCoinsText();
        PlayerPrefs.SetInt("total_coins", totalCoins); // Skoru PlayerPrefs ile kaydet
    }

    // Toplam madeni paralar� g�ncellemek i�in kullan�l�r
    private void UpdateTotalCoinsText()
    {
        totalCoinsText.text = totalCoins.ToString("0");
    }
}
