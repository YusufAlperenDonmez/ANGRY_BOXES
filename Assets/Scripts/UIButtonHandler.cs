using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIButtonHandler : MonoBehaviour
{
    [SerializeField] private Button UIStartButton;
    [SerializeField] private Button UIShootButton;
    [SerializeField] private Button UIResetButton;

    // Events other systems can subscribe to
    public static event Action OnUIStartButtonPressed;
    public static event Action OnUIShootButtonPressed;
    public static event Action OnUIResetButtonPressed;

    private void Start()
    {
        UIStartButton?.onClick.AddListener(HandleStartButtonPressed);
        UIShootButton?.onClick.AddListener(HandleShootButtonPressed);
        UIResetButton?.onClick.AddListener(HandleResetButtonPressed);
        UIShootButton?.gameObject.SetActive(false);
    }

    private void HandleStartButtonPressed()
    {
        OnUIStartButtonPressed?.Invoke();
        UIStartButton?.gameObject.SetActive(false);
        UIShootButton?.gameObject.SetActive(true);
    }

    private void HandleShootButtonPressed()
    {
        OnUIShootButtonPressed?.Invoke();
    }

    private void HandleResetButtonPressed()
    {
        OnUIResetButtonPressed?.Invoke();
        UIStartButton?.gameObject.SetActive(true);
        UIShootButton?.gameObject.SetActive(false);
    }

}
