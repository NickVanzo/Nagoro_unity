using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    // Start is called before the first frame update
    [SerializeField] private AudioClip drumEffectAudioClip;

    public void PlayDrumClip()
    {
        audioSource.clip = drumEffectAudioClip;
        audioSource.Play();
    }
}
