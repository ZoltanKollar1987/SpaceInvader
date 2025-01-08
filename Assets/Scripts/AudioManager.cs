using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;
    

    public AudioClip playerShoot;
    public AudioClip playerDestroy;

    public AudioClip enemyShoot;
    public AudioClip enemyDestroy;
    public AudioClip enemyMove;

    public AudioClip ufoMove;
    public AudioClip ufoDestroy;

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
        

        if(Time.timeScale == 0)
        {
            SFXSource.Stop();
        }
        else
        {
            SFXSource.Play();
        }
    }

}
