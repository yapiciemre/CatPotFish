using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton oluþturmak için kullanýlýr
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
        // Baþlangýçta UI metnini güncelleyin
        UpdateTotalCoinsText();
    }

    // Madeni paralarý eklemek için kullanýlýr
    public void AddCoins(int coinsToAdd)
    {
        totalCoins += coinsToAdd;
        UpdateTotalCoinsText();
        PlayerPrefs.SetInt("total_coins", totalCoins); // Skoru PlayerPrefs ile kaydet
    }

    // Toplam madeni paralarý güncellemek için kullanýlýr
    private void UpdateTotalCoinsText()
    {
        totalCoinsText.text = totalCoins.ToString("0");
    }
}
