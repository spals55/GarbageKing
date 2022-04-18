using PixupGames.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetskiPort : MonoBehaviour
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Transform _exitPoint;
    [SerializeField] private MainCamera _mainCamera;

    private Jetski _jetski;

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(OnExitButtonClicked);
    }

    private void OnExitButtonClicked()
    {
        _jetski.Driver.ExitVehicle(_exitPoint.position);
        _jetski.Exit();
        _mainCamera.ResetOffset();
        _exitButton.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Jetski jetski))
        {
            if (jetski.HasDriver)
            {
                _jetski = jetski;
                _exitButton.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Jetski jetski))
        {
            if (jetski.HasDriver)
            {
                _exitButton.gameObject.SetActive(false);
            }
        }
    }
}
