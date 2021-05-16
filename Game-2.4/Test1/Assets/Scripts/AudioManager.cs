using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audiosource;
    private int musicIndex = 0;

    void Start()
    {
        audiosource.clip = playlist[0];
        audiosource.Play();
    }

    
    void Update()
    {
        if(!audiosource.isPlaying)
        {
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audiosource.clip = playlist[musicIndex];
        audiosource.Play();
    }
}
