using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager :Singleton<SoundManager>
{
    public AudioClip door;
    public AudioClip laser;
    public AudioClip smoke;
    public AudioClip fire;

    public void playDoorSound(AudioSource source)
    { 
        source.clip = door;
        source.Play(); 
    }
    public void playFireSound(AudioSource source)
    {
        source.clip = fire;
        source.Play();
        source.loop = true; 
    }
    public void playLaserSound(AudioSource source)
    {
        source.clip = laser;
        source.Play();
        source.loop = true; 
    }
    public void playSpreadingSmokeSound(AudioSource source)
    {
        source.clip = smoke;
        source.Play();
        source.loop = true;
    }
}
