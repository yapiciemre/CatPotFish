using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [SerializeField]
    Sprite[] muteIcon = default;

    [SerializeField]
    Button muteButton = default;

    bool muteOpen = true;

    public void GameStart()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void HighScoreScene()
    {
        SceneManager.LoadScene("HighScore");
    }

    public void OptionsScene()
    {
        SceneManager.LoadScene("Options");
    }

    public void MuteButton()
    {
        if (muteOpen)
        {
            muteOpen = false;
            muteButton.image.sprite = muteIcon[0];
        }
        else
        {
            muteOpen=true;
            muteButton.image.sprite = muteIcon[1];
        }
    }
}
