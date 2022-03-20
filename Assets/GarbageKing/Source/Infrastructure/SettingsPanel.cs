using PixupGames.Infrastracture.Game;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour, IPanel
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _restartGameButton;

    private void OnEnable()
    {
        _settingsButton.onClick.AddListener(OnSettingsButtonClick);
        _restartGameButton.onClick.AddListener(OnRestartGameButtonClick);
    }

    private void OnRestartGameButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDisable()
    {
        _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
        _restartGameButton.onClick.RemoveListener(OnRestartGameButtonClick);
    }

    private void OnSettingsButtonClick()
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