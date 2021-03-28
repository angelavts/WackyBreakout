using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Gets whether or not the audio manager has been initialized
    /// </summary>
    public static bool Initialized
    {
        get { return initialized; }
    }

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.BlockBreaking, 
            Resources.Load<AudioClip>("BlockBreaking"));
        audioClips.Add(AudioClipName.ButtonClick,
            Resources.Load<AudioClip>("ButtonClick"));
        audioClips.Add(AudioClipName.NewBall,
            Resources.Load<AudioClip>("NewBall"));
        audioClips.Add(AudioClipName.NewGame,
            Resources.Load<AudioClip>("NewGame"));
        audioClips.Add(AudioClipName.PaddleTouch,
             Resources.Load<AudioClip>("PaddleTouch"));
        audioClips.Add(AudioClipName.PickupBlockBreaking,
             Resources.Load<AudioClip>("PickupBlockBreaking"));
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
