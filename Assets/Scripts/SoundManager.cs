using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource audioSourceInCar;
    // Start is called before the first frame update
    [SerializeField] private AudioClip drumEffectAudioClip;
    [SerializeField] private AudioClip carEngineLoopClip;

    void Start()
    {
        LevelManager.OnSceneEnded += StartCarEngineLoopClip;
    }

    public void PlayDrumClip()
    {
        audioSource.clip = drumEffectAudioClip;
        audioSource.Play();
    }

    public void StartCarEngineLoopClip()
    {
        audioSourceInCar.clip = carEngineLoopClip;
        audioSourceInCar.Play();
    }
}
