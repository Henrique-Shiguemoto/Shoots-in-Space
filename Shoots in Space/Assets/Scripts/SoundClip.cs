using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class SoundClip
{
    public AudioClip soundClip;
    public string soundName;
    [Range(0f, 1f)] public float volume;
    [Range(0.1f, 3f)] public float pitch;
    public bool looping;
    [HideInInspector] public AudioSource audioSource;

    public SoundClip (AudioClip soundClip, string soundName, float volume, float pitch, bool looping){
        this.soundClip = soundClip;
        this.soundName = soundName;
        this.volume = volume;
        this.pitch = pitch;
        this.looping = looping;
    }
}
