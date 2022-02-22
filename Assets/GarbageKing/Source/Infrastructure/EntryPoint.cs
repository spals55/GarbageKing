using PixupGames.Infrastracture.Services;
using System.Collections.Generic;
using UnityEngine;

namespace PixupGames.Infrastracture.Game
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private string _saveKey = "PixupDevelopment";
        [SerializeField] private UnityGameEngine _gameEngine;
        [SerializeField] private World _world;
        [SerializeField] private Player _player;

        private void Awake()
        {
            var dataPersistence = new DataPersistence(_saveKey);
            var assetsFactory = new AssetsFactory();

            _gameEngine.Init(dataPersistence);
            _world.Init(assetsFactory, dataPersistence);

            var game = new Game(dataPersistence, _world, _gameEngine, _player);
            game.Run();
        }
    }
}