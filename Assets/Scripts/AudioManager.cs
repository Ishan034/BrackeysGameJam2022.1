using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;

            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;
        }
    }

    private void Start()
    {
        PlaySound("Background");
    }

    public void PlaySound(string name)
    {
        Sound sound =  Array.Find(sounds, sound => sound.name == name);

        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!"); 

            return;
        }

        sound.audioSource.Play();
    }
}
