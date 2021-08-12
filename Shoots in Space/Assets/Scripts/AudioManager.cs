using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<SoundClip> soundClips;

    void Awake()
    {
        foreach(SoundClip sound in soundClips){
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.soundClip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.looping;
        }
    }

    void Start()
    {
        PlaySound("LevelSong");
    }
    
    public bool PlaySound(string name){
        foreach(SoundClip sound in soundClips){
            if(sound.soundName == name){
                sound.audioSource.Play();
                return true;
            }
        }
        Debug.LogError("Sound name not found!");
        return false;
    }
}
