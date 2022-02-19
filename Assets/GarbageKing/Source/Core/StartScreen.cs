using PixupGames.Infrastracture.Game;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixupGames.UI
{
    public class StartScreen : MonoBehaviour, IScreen, IGameStartButton
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Button _startGameButton;

        public event Action GameStartButtonClick;

        private void OnEnable()
        {
            _startGameButton.onClick.AddListener(() => GameStartButtonClick?.Invoke());
        }

        private void OnDisable()
        {
            _startGameButton.onClick.RemoveListener(() => GameStartButtonClick?.Invoke());

        }

        public void Hide()
        {
            _canvasGroup.Close();
        }

        public void Show()
        {
            _canvasGroup.Open();
        }
    }
}