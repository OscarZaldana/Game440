using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


[RequireComponent(typeof(AudioEvents))]
public class AudioManager : MonoSingleton<AudioManager>
{
    AudioSource sfxSource;
    //AudioSource source;
    //AudioSource[] musicSources;
    //int activeMusicSourceIndex = 0;


    AudioListener audioListener;

    SoundList library;

    Dictionary<System.Type, AudioClip> clipLibrary;
    Dictionary<AudioClip, float> volumeLibrary;

    public virtual void Awake()
    {
        GameObject instance = Instantiate(Resources.Load("Audio/SoundList", typeof(GameObject))) as GameObject;
        library = FindObjectOfType<SoundList>();
        GameObject newSfxsource = new GameObject("sfx source");
        sfxSource = newSfxsource.AddComponent<AudioSource>();
        newSfxsource.transform.parent = transform;

        audioListener = FindObjectOfType<AudioListener>();
    }



    public void PlaySound(string soundName, float lowPitch)
    {
        sfxSource.pitch = Random.Range(lowPitch, 1);
        sfxSource.PlayOneShot(library.GetClipFromName(soundName), 1f);
    }
}
