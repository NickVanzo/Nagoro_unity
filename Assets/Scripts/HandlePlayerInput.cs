using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandlePlayerInput : MonoBehaviour
{
    GameObject canvas = null;
    bool isUIOpen = false;

    void Start()
    {
        canvas = GameObject.Find("Canvas/Inventory");
    }

    void Update()
    {
        ToggleInventoryUI();
    }

    void ToggleInventoryUI()
    {
        if (canvas == null) return;
        bool userPressedIKey = Keyboard.current.iKey.wasPressedThisFrame;
        if (userPressedIKey && !isUIOpen)
        {
            Logger.Log("Opening the ui for inventory");
            canvas.SetActive(true);
            isUIOpen = true;
            return;
        }

        if (userPressedIKey && isUIOpen)
        {
            Logger.Log("Closing the ui for inventory");
            canvas.SetActive(false);
            isUIOpen = false;
            return;
        }
    }
}
