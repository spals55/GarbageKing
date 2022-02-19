using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixupGames.UI
{
    public class WinScreen : MonoBehaviour, IScreen
    {
        [SerializeField] private CanvasGroup _canvasGroup;

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