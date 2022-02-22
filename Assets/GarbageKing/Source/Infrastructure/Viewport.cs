using UnityEngine;

namespace PixupGames.Infrastracture.Game
{
    public class Viewport : MonoBehaviour, IViewport
    {
        [SerializeField] private StartGameWindow _startGameWindow;
        [SerializeField] private PlayGameWindow _playGameWindow;

        public IPlayGameWindow GetPlayGameWindow() => _playGameWindow;

        public IStartGameWindow GetStartGameWindow() => _startGameWindow;
    }
}