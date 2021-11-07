using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume : MonoBehaviour
{
    private AudioSource audioSrc;
    
    private float musicVolume = 1f;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.loop = true;
        audioSrc.Play();
    }
}
