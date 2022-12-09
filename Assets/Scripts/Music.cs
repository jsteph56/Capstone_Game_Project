using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip startMusic;

    void Start()
    {
        audioSource.clip = startMusic;
        audioSource.Play();
    }
}
