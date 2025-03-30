using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public enum ESounds
    {
        Background,
        bass0,
        bass1,
        bass2,
        bass3
    }

    public static AudioManager Instance { get; private set; }
    
    [Header("General")]
    [SerializeField] private AudioMixerGroup _SFXGroup;
    [SerializeField] private AudioMixerGroup _MusicGroup;
    
    [Header("Music")]
    [SerializeField] private AudioClip _backgroundClip;
    
    [Header("SFX")]
    [SerializeField] private AudioClip[] _bassSounds;

    public Dictionary<ESounds, AudioClip> Sounds { get; } = new();

    private void Awake()
    {
        //handle singleton
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
        SoundsZIP();
    }
    
    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject gameObject = new GameObject("TempAudio");
        gameObject.transform.position = pos;
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = _SFXGroup;
        audioSource.Play();
        Destroy(gameObject, clip.length);
        return audioSource;
    }

    public AudioSource PlaySound(ESounds sound)
    {
        AudioClip clip = Sounds[sound];
        if (clip != null)
            return PlayClipAt(clip, Vector3.zero);

        return null;
    }

    /// <summary>
    /// The library of all game sounds. If u add new
    /// sound, add an enum variable and put it in
    /// the Sounds Dictionary
    /// </summary>
    private void SoundsZIP()
    {
        Sounds.Add(ESounds.Background, _backgroundClip);
        Sounds.Add(ESounds.bass0, _bassSounds[0]);
        Sounds.Add(ESounds.bass1, _bassSounds[1]);
        Sounds.Add(ESounds.bass2, _bassSounds[2]);
        Sounds.Add(ESounds.bass3, _bassSounds[3]);
    }
}
