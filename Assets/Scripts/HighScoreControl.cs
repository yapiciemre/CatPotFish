using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreControl : MonoBehaviour
{
    public TextMeshProUGUI highScore;

    void Start()
    {
        highScore.text = "" + Preferences.ReadScore();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
