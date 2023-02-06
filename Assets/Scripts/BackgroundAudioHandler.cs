using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioHandler : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        audioSource.playOnAwake = false;
        audioSource.loop = true;
        UIManager.OnSceneEnded += StartAudioClip;
        UIManager.OnEnterPause += StopAudioClip;
        UIManager.OnQuitPause += StartAudioClip;
    }

    void StartAudioClip()
    {
        audioSource.Play();
    }

    void StopAudioClip() {
        audioSource.Pause();
    }
}
