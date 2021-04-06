using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public 


    void Awake()
    {
        if (instance != this)
            instance = this;
    }

    public void soundOn(string soundName,AudioClip clip)
    {
        GameObject imsiSound = new GameObject(soundName + "sound");
        AudioSource audio = imsiSound.AddComponent<AudioSource>();
        audio.clip = clip;
        audio.Play();

        Destroy(audio, clip.length);
    }

}
