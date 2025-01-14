using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLines : MonoBehaviour
{
    public AudioClip startClip;

    public AudioClip[] atkClips;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        source.clip = startClip;
        source.Play();
    }

    public void PlayRandomClip()
    {
        source.clip = atkClips[Random.Range(0, atkClips.Length - 1)];
        source.Play();
    }
}
