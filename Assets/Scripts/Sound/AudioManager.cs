using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource, uiSource;

    public void Start()
    {
        PlayMusic("Lebarde");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, m => m.name == name);

        if (s == null){
            Debug.Log($"Sound {name} not found");
            return;
        }

        musicSource.clip = s.clip;
        musicSource.Play();
    }

    public void PlayUISound(string name)
    {
        Sound s = Array.Find(sfxSounds, m => m.name == name);

        if (s == null){
            Debug.Log($"SFX {name} not found");
            return;
        }

        sfxSource.PlayOneShot(s.clip);
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, m => m.name == name);

        if (s == null){
            Debug.Log($"SFX {name} not found");
            return;
        }

        sfxSource.PlayOneShot(s.clip);
    }
}
