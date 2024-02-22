using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float slowness = 10f;
    public GameObject gameOverPanel;
    public GameObject scoreObjectPanel;

    private bool gameEnded = false; // Flag to track if the game has ended

    private void Start()
    {
        // Disable the game over panel initially
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    public void EndGame()
    {
        FindObjectOfType<FxControl>().GameOverSound();
        if (!gameEnded) // Ensure that the game ends only once
        {
            gameEnded = true;
            StartCoroutine(RestartLevel());
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    IEnumerator RestartLevel()
    {
        // Slow down time
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

        yield return new WaitForSeconds(1f / slowness);

        // Reset time
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;

        // Pause the game
        Time.timeScale = 0f;

        // Activate Game Over Panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            FindObjectOfType<ScoreManager>()?.GameOver(); // Ensure ScoreManager is found
        }

        // Deactivate score panel if it exists
        if (scoreObjectPanel != null)
        {
            scoreObjectPanel.SetActive(false);
        }
    }
}
