using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject blackStartingScreen = null;
    [SerializeField] private TextMeshProUGUI firstTitle = null;
    [SerializeField] private SoundManager soundManager = null;
    [SerializeField] private TextMeshProUGUI secondTitle = null;
    [SerializeField] private GameObject cameraCanvas = null;
    [SerializeField] private float startingScreenDuration = 4f;
    [SerializeField] private float durationOfEachTitle = 2f;
    [SerializeField] private GameObject pauseMenuUI = null;
    [SerializeField] private StarterAssetsInputs starterAssetsInputs = null;
    [SerializeField] private GameObject settingsMenuUI = null;
    private bool isPaused = false;
    private bool optionsMenuOpen = false;
    private bool isSceneEnded = false;
    public static event Action OnSceneEnded;
    public static event Action OnEnterPause;
    public static event Action OnQuitPause;

    void Start()
    {
        Cursor.visible = false;
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
        else
        {
            Debug.LogError("Pause menu is null");
        }

        if (cameraCanvas != null)
        {
            Debug.Log("Camera canvas is not null");
            cameraCanvas.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Camera canvas is null");
        }
        if (firstTitle != null && secondTitle != null)
        {
            Debug.Log("Titles are not null");
            secondTitle.gameObject.SetActive(false);
            StartCoroutine(nameof(ShowTitle));
            StartCoroutine(nameof(WaitAndHideBlackScreen));

        }
        else
        {
            Debug.LogError("Titles are null");
        }
    }

    void Update()
    {
        HandleTogglePauseMenu();
    }

    public void HandleTogglePauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isSceneEnded)
        {
            TogglePauseMenu();

        }
    }

    public void TogglePauseMenu()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Debug.Log("Open Menu Pause");
            Time.timeScale = 1;
            OnQuitPause?.Invoke();
        }
        else
        {
            Debug.Log("Close Menu Pause");
            Time.timeScale = 0;
            OnEnterPause?.Invoke();
        }
        Cursor.visible = !isPaused;
        settingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(!isPaused);
        cameraCanvas.SetActive(isPaused);
    }

    public void ToggleOptionsMenu()
    {
        optionsMenuOpen = !optionsMenuOpen;
        pauseMenuUI.SetActive(!optionsMenuOpen);
        settingsMenuUI.SetActive(optionsMenuOpen);
    }


    IEnumerator WaitAndHideBlackScreen()
    {
        soundManager.PlayDrumClip();
        yield return new WaitForSeconds(startingScreenDuration);
        this.blackStartingScreen.gameObject.SetActive(false);
        this.secondTitle.gameObject.SetActive(false);
        OnSceneEnded.Invoke();
        cameraCanvas.gameObject.SetActive(true);
        isSceneEnded = true;
    }

    IEnumerator ShowTitle()
    {
        yield return new WaitForSeconds(durationOfEachTitle);
        this.firstTitle.gameObject.SetActive(false);
        this.secondTitle.gameObject.SetActive(true);
        soundManager.PlayDrumClip();
    }
}

