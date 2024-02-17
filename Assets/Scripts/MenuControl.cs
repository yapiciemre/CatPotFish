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

    void Start()
    {
        if (Preferences.AnyMuteOpen() == false)
        {
            Preferences.SelectedMuteOpen(1);
        }
        LookMuteOptions();
    }

    public void GameStart()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void HighScoreScene()
    {
        SceneManager.LoadScene("HighScore");
    }

    public void MuteButton()
    {
        if (Preferences.ReadMuteOpen() == 1)
        {
            Preferences.SelectedMuteOpen(0);
            MusicControl.instance.PlayMusic(false);
            muteButton.image.sprite = muteIcon[0];
        }
        else
        {
            Preferences.SelectedMuteOpen(1);
            MusicControl.instance.PlayMusic(true);
            muteButton.image.sprite = muteIcon[1];
        }
    }

    void LookMuteOptions()
    {
        if (Preferences.ReadMuteOpen() == 1)
        {
            muteButton.image.sprite = muteIcon[1];
            MusicControl.instance.PlayMusic(true);
        }
        else
        {
            muteButton.image.sprite = muteIcon[0];
            MusicControl.instance.PlayMusic(false);
        }
    }
}
