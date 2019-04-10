using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepScript : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioClip[] waterClips;
    public AudioSource audioSource;
    public bool isInWater;
    
    void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        if (isInWater)
         return waterClips[UnityEngine.Random.Range(0,waterClips.Length)];
        else
         return clips[UnityEngine.Random.Range(0,clips.Length)];
    }
}
