using PixupGames.Core;
using PixupGames.Infrastracture.Services;
using System.Collections.Generic;
using UnityEngine;

namespace PixupGames.Infrastracture.Game
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private string _saveKey = "PixupDevelopment";
        [SerializeField] private UnityGameEngine _gameEngine;
        [SerializeField] private List<Region> _regions;

        private Game _game;

        private void Awake()
        {
            var dataPersistence = new DataPersistence(_saveKey);
            var world = new World(_regions);

            _game = new Game(dataPersistence, world, _gameEngine);
            _gameEngine.Init(_game);
        }
    }
}