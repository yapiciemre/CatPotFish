using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preferences : MonoBehaviour
{
    public static string totalCoins = "totalCoins";

    public static string muteOpen = "muteOpen";


    public static void SelectedScore(int totalCoins)
    {
        PlayerPrefs.SetInt(Preferences.totalCoins, totalCoins);
    }

    public static int ReadScore()
    {
        return PlayerPrefs.GetInt(Preferences.totalCoins);
    }

    public static void SelectedMuteOpen(int muteOpen)
    {
        PlayerPrefs.SetInt(Preferences.muteOpen, muteOpen);
    }

    public static int ReadMuteOpen()
    {
        return PlayerPrefs.GetInt(Preferences.muteOpen);
    }

    public static bool AnyMuteOpen()
    {
        if (PlayerPrefs.HasKey(Preferences.muteOpen))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
