using PixupGames.Core;
using PixupGames.Infrastracture.Game;
using PixupGames.Infrastracture.Services;
using UnityEngine;


public class EntryPoint : MonoBehaviour
{
    [SerializeField] private string _saveKey = "PixupDevelopment";
    [SerializeField] private UnityGameEngine _gameEngine;
    [SerializeField] private World _world;
    [SerializeField] private Viewport _viewport;
    [SerializeField] private Shop _shop;

    private Game _game;

    private void Awake()
    {
        _game = new Game(_world, _gameEngine, _viewport, _shop);
        _gameEngine.Init(_game);
    }
}
