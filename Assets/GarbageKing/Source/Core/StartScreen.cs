using PixupGames.Infrastracture.Game;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixupGames.UI
{
    public class StartScreen : MonoBehaviour, IScreen
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Button _startGameButton;

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