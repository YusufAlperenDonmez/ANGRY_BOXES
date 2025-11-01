using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBarOnStart : MonoBehaviour
{
    [SerializeField] private Canvas ARMagicBar;

    // Start is called before the first frame update
    void Start()
    {
        // Fix typo and subscribe to the correct events
        UIButtonHandler.OnUIStartButtonPressed += OnStartButtonPressed;
        UIButtonHandler.OnUIResetButtonPressed += OnResetButtonPressed;
    }

    private void OnStartButtonPressed()
    {
        if (ARMagicBar != null) ARMagicBar.enabled = false;
    }

    private void OnResetButtonPressed()
    {
        if (ARMagicBar != null) ARMagicBar.enabled = true;
    }

    private void OnDestroy()
    {
        // Unsubscribe to avoid leaks when object is destroyed
        UIButtonHandler.OnUIStartButtonPressed -= OnStartButtonPressed;
        UIButtonHandler.OnUIResetButtonPressed -= OnResetButtonPressed;
    }

}
