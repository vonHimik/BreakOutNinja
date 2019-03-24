using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;
    public bool played;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    void Update ()
    {
        if (!played)
        {
            played = true;
            audioSource.clip = (audioClips[Random.Range(0, audioClips.Length)]);
            audioSource.Play();
        }

        Wait();
    }

    void Wait()
    {
        if(!audioSource.isPlaying)
        {
            played = false;
        }
    }
}
