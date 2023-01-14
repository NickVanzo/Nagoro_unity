using UnityEngine;
using UnityEngine.InputSystem;

public class FlashlightHandler : MonoBehaviour
{
    [SerializeField] private Light spotlight;
    [SerializeField] private GameObject mainCamera;
    private bool isTorchActive = false;


    void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame && !isTorchActive)
        {
            spotlight.gameObject.SetActive(true);
            isTorchActive = true;
        }
        else if (Keyboard.current.tKey.wasPressedThisFrame && isTorchActive)
        {
            spotlight.gameObject.SetActive(false);
            isTorchActive = false;
        }
        spotlight.transform.rotation = mainCamera.transform.rotation;
    }

}
