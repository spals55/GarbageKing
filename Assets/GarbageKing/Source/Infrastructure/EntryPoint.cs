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
    [SerializeField] private Jetski _jetski;

    private Game _game;

    private void Awake()
    {
        var dataPersistence = new DataPersistence(_saveKey);

        _game = new Game(dataPersistence, _world, _gameEngine, _viewport);
        _gameEngine.Init(_game);
    }
}
