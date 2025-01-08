using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudio : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    public AudioClip mainMenuMusic;


    private void Awake()
    {
        audio.PlayOneShot(mainMenuMusic);
    }
}
