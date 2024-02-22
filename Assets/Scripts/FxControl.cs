using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxControl : MonoBehaviour
{
    public AudioClip fish;
    public AudioClip gameOver;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void FishSound()
    {
        audioSource.clip = fish;
        audioSource.Play();
    }

    public void GameOverSound()
    {
        audioSource.clip = gameOver;
        audioSource.Play();
    }
}
