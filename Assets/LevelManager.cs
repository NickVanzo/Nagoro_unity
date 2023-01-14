using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject blackStartingScreen = null;
    [SerializeField] private TextMeshProUGUI firstTitle = null;
    [SerializeField] private TextMeshProUGUI secondTitle = null;
    [SerializeField] private GameObject player = null;

    [SerializeField] private float startingScreenDuration = 4f;
    [SerializeField] private float durationOfEachTitle = 2f;

    void Start()
    {
        secondTitle.gameObject.SetActive(false);
        StartCoroutine(nameof(ShowTitle));
        StartCoroutine(nameof(WaitAndHideBlackScreen));
    }

    IEnumerator WaitAndHideBlackScreen()
    {
        yield return new WaitForSeconds(startingScreenDuration);
        this.blackStartingScreen.gameObject.SetActive(false);
        this.secondTitle.gameObject.SetActive(false);
    }

    IEnumerator ShowTitle()
    {
        yield return new WaitForSeconds(durationOfEachTitle);
        this.firstTitle.gameObject.SetActive(false);
        this.secondTitle.gameObject.SetActive(true);
    }
}
