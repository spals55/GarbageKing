using PixupGames.Infrastracture.Game;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour, IPanel
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitSettingsButton;

    private void OnEnable()
    {
        _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        _exitSettingsButton.onClick.AddListener(OnExitSettingsButtonClicked);

    }

    private void OnDisable()
    {
        _settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
        _exitSettingsButton.onClick.RemoveListener(OnExitSettingsButtonClicked);

    }

    private void OnExitSettingsButtonClicked()
    {
        Hide();
    }

    private void OnSettingsButtonClicked()
    {
        Show();
    }

    public void Show()
    {
        _canvasGroup.Open();
    }

    public void Hide()
    {
        _canvasGroup.Close();
    }
}