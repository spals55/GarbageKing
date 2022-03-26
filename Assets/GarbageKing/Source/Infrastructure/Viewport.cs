using PixupGames.Infrastracture.Game;
using UnityEngine;

public class Viewport : MonoBehaviour, IViewport
{
    [SerializeField] private PlayGameWindow _playGameWindow;
    [SerializeField] private StartGameWindow _startGameWindow;

    public IPlayGameWindow GetPlayGameWindow() => _playGameWindow;
    public IStartGameWindow GetStartGameWindow() => _startGameWindow;
}
