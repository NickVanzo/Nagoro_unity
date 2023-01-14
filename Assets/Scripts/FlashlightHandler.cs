using UnityEngine;
using UnityEngine.InputSystem;

public class FlashlightHandler : MonoBehaviour
{
    [SerializeField] private Light spotlight;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickAudioClip;
    private bool isTorchActive = false;


    void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame && !isTorchActive)
        {
            spotlight.gameObject.SetActive(true);
            isTorchActive = true;
            audioSource.PlayOneShot(clickAudioClip);
        }
        else if (Keyboard.current.tKey.wasPressedThisFrame && isTorchActive)
        {
            audioSource.PlayOneShot(clickAudioClip);
            spotlight.gameObject.SetActive(false);
            isTorchActive = false;
        }

        spotlight.transform.rotation = mainCamera.transform.rotation;
    }

}
