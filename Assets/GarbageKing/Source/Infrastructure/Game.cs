using PixupGames.Infrastracture.Services;
using System;
using UnityEngine;

namespace PixupGames.Infrastracture.Game
{
    public class Game : IGame
    {
        private readonly IDataPersistence _dataPersistence;
        private readonly IAssetsFactory _assetsFactory;
        private readonly IGameEngine _gameEngine;
        private readonly IViewport _viewport;
        private readonly IWorld _world;

        public Game(IDataPersistence dataPersistence, IWorld world, IGameEngine gameEngine, IAssetsFactory assetsFactory)
        {
            _world = world;
            _dataPersistence = dataPersistence;
            _gameEngine = gameEngine;
            _assetsFactory = assetsFactory;
            _viewport = _gameEngine.GetViewport();
        }

        public void Run()
        {
            _viewport.GetStartGameWindow().Show();
            CreateWorld();
            UnlockRegions();
        }

        private void CreateWorld()
        {          
            ICamera camera = _world.CreateCamera();
            IPlayer player = _world.CreatePlayer();
            IWallet wallet = new Wallet(2500);
            IPlayGameWindow playGameWindow = _gameEngine.GetViewport().GetPlayGameWindow();

            player.Init(_gameEngine.GetInputDevice(), playGameWindow, wallet);
            camera.SetTarget(player);

            UnlockRegions();
        }

        private void UnlockRegions()
        {
            return;

            foreach (var region in _dataPersistence.Data.World.Regions)
            {
                if (region.IsOpen)
                {
                    _world.UnlockRegion(region.Id);
                }
            }
        }
    }
}