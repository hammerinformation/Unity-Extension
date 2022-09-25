using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    public static SoundManager Instance;

    private void Awake()
    {
        Instance = this;

        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip, float volume = 1f, bool randomPitch = false)
    {
        audioSource.volume = volume;
        audioSource.pitch = randomPitch ? Random.Range(1f, 1.25f) : 1f;

        audioSource.PlayOneShot(clip);
    }
}
