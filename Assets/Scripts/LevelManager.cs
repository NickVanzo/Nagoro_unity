using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject blackStartingScreen = null;
    [SerializeField] private TextMeshProUGUI firstTitle = null;
    [SerializeField] private SoundManager soundManager = null;
    [SerializeField] private TextMeshProUGUI secondTitle = null;
    [SerializeField] private float startingScreenDuration = 4f;
    [SerializeField] private float durationOfEachTitle = 2f;
    public static event Action OnSceneEnded;

    void Start()
    {
        secondTitle.gameObject.SetActive(false);
        StartCoroutine(nameof(ShowTitle));
        StartCoroutine(nameof(WaitAndHideBlackScreen));
    }

    IEnumerator WaitAndHideBlackScreen()
    {
        soundManager.PlayDrumClip();
        yield return new WaitForSeconds(startingScreenDuration);
        this.blackStartingScreen.gameObject.SetActive(false);
        this.secondTitle.gameObject.SetActive(false);
        OnSceneEnded.Invoke();
    }

    IEnumerator ShowTitle()
    {
        yield return new WaitForSeconds(durationOfEachTitle);
        this.firstTitle.gameObject.SetActive(false);
        this.secondTitle.gameObject.SetActive(true);
        soundManager.PlayDrumClip();
    }
}
